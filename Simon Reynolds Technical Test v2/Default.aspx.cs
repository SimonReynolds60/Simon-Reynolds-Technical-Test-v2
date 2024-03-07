using Simon_Reynolds_Technical_Test_v2.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Simon_Reynolds_Technical_Test_v2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if not a post Load the grid
            if (!IsPostBack)
            {
                LoadGrid();
            }
            
        }

        //Build the customer list
        public List<Customer> customerList = new List<Customer>
        {
            new Customer{Name = "Simon Reynolds", Age=35, PostCode="PL5 1BH", Height=1.2},
            new Customer{Name="Arthur Christmas", Age=25, PostCode="NP1 1SC", Height=1.1},
            new Customer{Name="Tammy Shanter", Age=57, PostCode="TS1 1HH", Height=0.92 },
            new Customer{Name="Sally Smith", Age=23, PostCode="PL99 2BB", Height=1.02},
            new Customer{Name="Francis McFrank", Age=93, PostCode="TG6 8YY", Height=0.85}

        };

        //save and databind the Grid
        public void LoadGrid()
        {
            lvCustomerDetails.DataSource = customerList;
            lvCustomerDetails.DataBind();
        }

      
        
        protected void lvCustomerDetails_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if(e.CommandName == "EditRow")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                string name = customerList[index].Name;
                int age = customerList[index].Age;
                string postCode  = customerList[index].PostCode;
                double height = customerList[index].Height;

                divEditPanel.Visible = true;
                txtCustomerName.Text = name;
                txtAge.Text = age.ToString();
                txtPostCode.Text = postCode;
                txtHeight.Text = height.ToString();

                //Add selected row index into viewstate so it doesnt reset on postback
                ViewState["SelectedRowIndex"] = index;
                ViewState["Action"] = "Edit";
                btnSubmitAdd.Text = "Edit";
            }


        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            
            divEditPanel.Visible = true;
            //Save action into viewstate so it isnt wiped on postback
            ViewState["Action"] = "Add";
            //rename button text as using same button for both update and add actions
            btnSubmitAdd.Text = "Add";


        }

        //On cancel button click - clear the textboxes and hide the div
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtCustomerName.Text = "";
            txtAge.Text = "";
            txtHeight.Text = "";
            txtPostCode.Text = "";
            divEditPanel.Visible = false;
        }

        //Validation has already been completed by the Javascript so values should be valid when submitting
        protected void btnSubmitAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //logic for adding a new row
                if (ViewState["Action"].ToString() == "Add")
                {
                    decimal heightTemp = Decimal.Round(Convert.ToDecimal(txtHeight.Text), 2);


                    customerList.Add(new Customer
                    {
                        Name = txtCustomerName.Text,
                        Age = Convert.ToInt32(txtAge.Text),
                        PostCode = txtPostCode.Text,
                        Height = Convert.ToDouble(heightTemp)
                    }); ;

                    //lvCustomerDetails.DataSource = customerList;
                    LoadGrid();
                }
                else
                {
                    //else Update the selected row
                    int index = Convert.ToInt32(ViewState["SelectedRowIndex"]);
                    customerList[index].Name = txtCustomerName.Text;
                    customerList[index].Age = Convert.ToInt32(txtAge.Text);
                    customerList[index].PostCode = txtPostCode.Text;
                    customerList[index].Height = Convert.ToDouble(txtHeight.Text);

                    //lvCustomerDetails.DataSource = customerList;
                    LoadGrid();
                }        


            }
            catch(Exception error)
            {

            }
        }

        protected void btnSubmitUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}