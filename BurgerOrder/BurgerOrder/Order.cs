using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Order
{
    public partial class Order : Form
    {

        //DECLARATIONS

        bool takeOut;
        
        int pattyNum;
        string orderStep; //keeps track of current panel

        string bunType;
        string cheeseType;
        string[] toppings = new string[] {};
        string[] sauce = new string[] {}; //{} allow user input to populate when you do not know length of array
        string[] optionsArray = new string[4]; //lists what has been selected/ordered in the build





        public Order()
        {
            InitializeComponent();
        }


        //APPLICATION LOAD EVENT
        private void Order_Load(object sender, EventArgs e)
        {

            pnlStart.Visible = true;
            pnlLocation.Visible = false;
            pnlOrderType.Visible = false;
            pnlBuild.Visible = false;
            pnlPreviousNext.Visible = true;
            pnlStack.Visible = true;
            pnlTopNav.Visible = true;
            pnlBun.Visible = false;
            pnlCheese.Visible = false;
            pnlToppings.Visible = false;
            pnlSauce.Visible = false;
            pnlSummary.Visible = false;
            pnlComplete.Visible = false;
            btnNavBun.Enabled = false;
            btnNavCheese.Enabled = false;
            btnNavSauce.Enabled = false;
            btnNavTopping.Enabled = false;
            
            

            lblStack.Text = "";


        }



        //PANEL VISIBLE CHANGED EVENTS  //panel start is the object, changes from load event to true, one for each pnl
        private void pnlStart_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlStart.Visible == true)
            {
                orderStep = "start";
            }

            btnNavBun.Enabled = true;
            btnNavCheese.Enabled = true;
            btnNavSauce.Enabled = true;
            btnNavTopping.Enabled = true;
        }


        private void pnlLocation_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlLocation.Visible == true)
            {
                orderStep = "location";
            }

            btnNext.Visible = true;
            btnPrevious.Enabled = true;
            btnNavBun.Enabled = true;
            btnNavCheese.Enabled = true;
            btnNavSauce.Enabled = true;
            btnNavTopping.Enabled = true;
           
        }

        private void pnlOrderType_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlOrderType.Visible == true)
            {
                orderStep = "ordertype";
            }
            btnNext.Visible = true;
            btnPrevious.Enabled = true;
            btnNavBun.Enabled = true;
            btnNavCheese.Enabled = true;
            btnNavSauce.Enabled = true;
            btnNavTopping.Enabled = true;
        }
        
        private void pnlBuild_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlBuild.Visible == true)
            {
                orderStep = "build";
            }

            btnNext.Visible = true;
            btnPrevious.Enabled = true;
            btnNavBun.Enabled = true;
            btnNavCheese.Enabled = true;
            btnNavSauce.Enabled = true;
            btnNavTopping.Enabled = true;
        }

        private void pnlBun_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlBun.Visible == true)
            {
                orderStep = "bun";
                btnNext.Enabled = false;//false so you must select bun type before moving forward

                if (optionsArray[0] == "")
                {
                    btnNext.Enabled = true;
                    btnPrevious.Enabled = true;                    
                    btnNavCheese.Enabled = true;
                    btnNavSauce.Enabled = true;
                    btnNavTopping.Enabled = true;
                }
                
            }
        }
        
        private void pnlCheese_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlCheese.Visible == true)
            {
                orderStep = "cheese";
                btnNext.Enabled = false;//false so you must select type before moving forward

                if (optionsArray[1] == "")
                {
                    btnNext.Enabled = true;
                    btnPrevious.Enabled = true;
                    btnNavBun.Enabled = true;
                    btnNavSauce.Enabled = true;
                    btnNavTopping.Enabled = true;
                }

            }
        }

        private void pnlToppings_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlToppings.Visible == true)
            {
                orderStep = "toppings";
                btnNext.Enabled = false;//false so you must select toppings before moving forward

                if (optionsArray[2] == "")
                {
                    btnNext.Enabled = true;
                    btnPrevious.Enabled = true;
                    btnNavBun.Enabled = true;
                    btnNavCheese.Enabled = true;
                    btnNavSauce.Enabled = true;            

                }
            }
        }

        private void pnlSauce_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlSauce.Visible == true)
            {
                orderStep = "sauce";
                btnNext.Enabled = false;//false so you must select type before moving forward

                if (optionsArray[3] == "")
                {
                    btnNext.Enabled = true;
                    btnPrevious.Enabled = true;
                    btnNavBun.Enabled = true;
                    btnNavCheese.Enabled = true;
                    btnNavTopping.Enabled = true;
                }
            }
        }

       
        private void pnlSummary_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlSummary.Visible == true)
            {
                orderStep = "summary";
                
                {
                    btnNext.Enabled = true;
                    btnPrevious.Enabled = true;
                    btnNavBun.Enabled = true;
                    btnNavCheese.Enabled = true;
                    btnNavSauce.Enabled = true;
                    btnNavTopping.Enabled = true;
                }
            }
        }






        //PANEL < PREVIOUS > NEXT EVENTS occur on Previous button click
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            switch (orderStep)
            {
                case "location": // dine in or take out  //current panel                   
                    pnlStart.Visible = true;  // panel moving to
                    pnlLocation.Visible = false;  //curent pannel, need to move to previous
                    break;

                case "orderType": //build or specialty //curent panel
                    pnlLocation.Visible = true;
                    pnlOrderType.Visible = false;                      
                    break;

                case "build": //click to begin  
                    pnlOrderType.Visible = true; 
                    pnlBuild.Visible = false; 
                    break;
         
                case "bun": //current panel 
                    pnlBuild.Visible = true; //curent pannel, need to move to previous
                    pnlBun.Visible = false; // panel moving to
                    break;

                case "cheese": //current panel
                    pnlBun.Visible = true; // panel move to
                    pnlCheese.Visible = false; // panel moving from
                    break;

                case "toppings": //panel moving to 
                    pnlCheese.Visible = true; //curent pannel, need to move to previous
                    pnlToppings.Visible = false; // panel moving to
                    break;

                case "sauce": //panel moving to 
                    pnlToppings.Visible = true; //curent pannel, need to move to previous
                    pnlSauce.Visible = false; // panel moving to
                    break;
                    
                case "summary":
                    pnlSauce.Visible = true;
                    pnlSummary.Visible = false;
                    break;


                default:
                    pnlStart.Visible = true;
                    break;

            }
        }

        //PANEL PREVIOUS < NEXT > EVENTS happen on Next button click
        private void btnNext_Click(object sender, EventArgs e)
        {
            switch (orderStep)
            {

                case "location":
                    pnlLocation.Visible = false;
                    pnlOrderType.Visible = true;
                    break;

                case "orderType":                    
                    pnlOrderType.Visible = false;
                    pnlBuild.Visible = true;
                    break;
                
                case "build"://current panel
                    pnlBuild.Visible = false; //panel moving from
                    pnlBun.Visible = true; // panel moving to
                    break;               

                case "bun": //current panel
                    pnlBun.Visible = false; //panel moving from
                    btnNext.Enabled = false; //must make selection before proceeding
                    pnlCheese.Visible = true;//panel moving to
                    break;

                case "cheese":// current panel
                    pnlCheese.Visible = false; //panel moving from
                    pnlToppings.Visible = true;//panel moving to
                    //btnNext.Enabled = false; //must make selection before proceeding
                    break;

                case "toppings": // current panel
                    pnlToppings.Visible = false; //panel moving from
                    pnlSauce.Visible = true; //panel moving to
                    //btnNext.Enabled = true; //must make selection before proceeding
                    break;

                case "sauce"://current panel
                    pnlSauce.Visible = false; //panel moving from
                    pnlSummary.Visible = true; //panel moving to
                    //btnNext.Enabled = false; //must make selection before proceeding
                    break;

                case "summary"://current panel
                    pnlComplete.Visible = true; //panel moving from
                    pnlSummary.Visible = false; //panel moving to
                    break;

                default:
                    pnlStart.Visible = true;
                    break;

            }

        }

        //1 START PANEL EVENTS
        private void btnStart_Click(object sender, EventArgs e)
        {
            pnlStart.Visible = false;
            pnlLocation.Visible = true;
            pnlTopNav.Visible = true;
            pnlStack.Visible = true;
            pnlPreviousNext.Visible = true;
            btnNavBun.Enabled = true;
            btnNavCheese.Enabled = true;
            btnNavSauce.Enabled = true;
            btnNavTopping.Enabled = true;
          
        }


        //2 LOCATION PANEL EVENTS
        private void btnIn_Click(object sender, EventArgs e)
        {
            takeOut = false;
            pnlLocation.Visible = false; //false because becomes previoius panel, need to move to next panel
            pnlOrderType.Visible = true;
            pnlPreviousNext.Visible = true;
            pnlTopNav.Visible = true;
            pnlStack.Visible = true;
            btnNavBun.Enabled = true;
            btnNavCheese.Enabled = true;
            btnNavSauce.Enabled = true;
            btnNavTopping.Enabled = true;
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            takeOut = true;
            pnlLocation.Visible = false;
            pnlOrderType.Visible = true;
            pnlPreviousNext.Visible = true;
        }

        //3 PANEL ORDER TYPE EVENTS
        private void btnBuild_Click(object sender, EventArgs e)
        {
            pnlOrderType.Visible = false;//false because previoius panel, need to move to next panel           
            pnlBuild.Visible = true;
            pnlTopNav.Visible = true;
            pnlStack.Visible = true;
            pnlPreviousNext.Visible = true;
            btnNavBun.Enabled = true;
            btnNavCheese.Enabled = true;
            btnNavSauce.Enabled = true;
            btnNavTopping.Enabled = true;
        }

        private void btnSpecialty_Click(object sender, EventArgs e)
        {
            pnlOrderType.Visible = false;
            pnlTopNav.Visible = true;
            pnlStack.Visible = true;
            pnlPreviousNext.Visible = true;
        }
              

        //4 PANEL BUILD EVENTS

        private void btnBuildBegin_Click(object sender, EventArgs e)
        {
            pnlBuild.Visible = false;
            pnlBun.Visible = true;
            pnlPreviousNext.Visible = true;
            pnlTopNav.Visible = true;
            pnlStack.Visible = true;
        }


        //5 PANEL BUN EVENTS
        private void btnWhite_Click(object sender, EventArgs e) //click event - requires a click action to load event
        {
            optionsArray[0] = "White Bun\n";
            lblStack.Text = optionsArray[0];
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
            
        }

        private void btnWheat_Click(object sender, EventArgs e)
        {
            optionsArray[0] = "Wheat Bun\n";
            lblStack.Text = optionsArray[0];
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
        }

        private void btnPotato_Click(object sender, EventArgs e)
        {
            optionsArray[0] = "Potato Bun\n";
            lblStack.Text = optionsArray[0];
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
        }

        //6 PANEL CHEESE EVENTS
        private void btnAmerican_Click(object sender, EventArgs e)
        {
            optionsArray[1] = "American Cheese\n";
            lblStack.Text += optionsArray[1];
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
        }

       
        private void btnCheddar_Click(object sender, EventArgs e)
        {
            optionsArray[1] = "Cheddar Cheese\n";
            lblStack.Text += optionsArray[1];
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
        }

        private void btnSwiss_Click(object sender, EventArgs e)
        {
            optionsArray[1] = "Swiss Cheese\n";
            lblStack.Text += optionsArray[1];
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
        }

        private void btnNoCheese_Click(object sender, EventArgs e)
        {
            optionsArray[1] = "No Cheese\n";
            lblStack.Text += optionsArray[1];
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
        }

        //7 PANEL TOPPINGS BUTTON EVENTS
        private void btnLettuce_Click(object sender, EventArgs e)
        {
            optionsArray[2] = "Lettuce\n";
            lblStack.Text += optionsArray[2];
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
        }

        private void btnOnion_Click(object sender, EventArgs e)
        {
            optionsArray[2] = "Onion\n";
            lblStack.Text += optionsArray[2];
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
        }

        private void btnTomatoe_Click(object sender, EventArgs e)
        {
            optionsArray[2] = "Tomato\n";
            lblStack.Text += optionsArray[2];
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
        }

        private void btnPickle_Click(object sender, EventArgs e)
        {
            optionsArray[2] = "Pickle\n";
            lblStack.Text += optionsArray[2];
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
        }
        
        // 8 PANEL SAUCE BUTTONS
        private void btnKetchup_Click(object sender, EventArgs e)
        {
            optionsArray[3] = "Ketchup\n";
            lblStack.Text += optionsArray[3];
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
        }

        private void btnMustard_Click(object sender, EventArgs e)
        {
            optionsArray[3] = "Mustard\n";
            lblStack.Text += optionsArray[3];
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
        }


        private void btnMayo_Click(object sender, EventArgs e)
        {
            optionsArray[3] = "Mayo\n";
            lblStack.Text += optionsArray[3];
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
        }

        



        //11 PANEL TOP NAV BUN BUTTON
        private void btnNavBun_Click(object sender, EventArgs e)
        {         
            pnlBun.Visible = true;
            pnlPreviousNext.Visible = true;
            pnlTopNav.Visible = true;
            pnlStack.Visible = true;
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
            btnNavCheese.Enabled = true;
            btnNavSauce.Enabled = true;
            btnNavTopping.Enabled = true;
            btnNavBun.Enabled = true;

        }


        // 11 PANEL TOP NAV CHEESE BUTTON
        private void btnNavCheese_Click(object sender, EventArgs e)
        {
            pnlCheese.Visible = true;
            pnlPreviousNext.Visible = true;
            pnlTopNav.Visible = true;
            pnlStack.Visible = true;
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
            btnNavBun.Enabled = true;
            btnNavSauce.Enabled = true;
            btnNavTopping.Enabled = true;
            btnNavCheese.Enabled = true;
        }

        // 11 PANEL TOP NAV TOPPING BUTTON
        private void btnNavTopping_Click(object sender, EventArgs e)
        {
            pnlToppings.Visible = true;
            pnlPreviousNext.Visible = true;
            pnlTopNav.Visible = true;
            pnlStack.Visible = true;
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
            btnNavBun.Enabled = true;
            btnNavCheese.Enabled = true;
            btnNavSauce.Enabled = true;
            btnNavTopping.Enabled = true;
        }

        // 11 PANEL TOP NAV SAUCE BUTTON
        private void btnNavSauce_Click(object sender, EventArgs e)
        {
            pnlSauce.Visible = true;
            pnlPreviousNext.Visible = true;
            pnlTopNav.Visible = true;
            pnlStack.Visible = true;
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
            btnNavBun.Enabled = true;
            btnNavCheese.Enabled = true;
            btnNavTopping.Enabled = true;
            btnNavSauce.Enabled = true;
        }

        

       

       

        

        
        






        

       





    }
}
