/*
 * Ken Macneal
 * 11/19/2019
 * Northwind Data Entity Assignment
 */ 


using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace NorthWindDataEntity
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        NorthwindEntities dbNorthwindContext = new NorthwindEntities();

        private void Form1_Load(object sender, EventArgs e)
        {
            dbNorthwindContext.Products.Load();

            productBindingSource.DataSource = dbNorthwindContext.Products.Local;
        }

        #region Navigation Button Events

        private void navBtnReorderFilter_Click(object sender, EventArgs e)
        {
            //note for self for future reference with using entity filter
            /*
             *  Filtering can be done by filtering in the dbContext locally and directly
             *  using a where method that acts as the syntax for the sql and performs the
             *  logic for filtering directly. 
             */ 
            productBindingSource.DataSource = dbNorthwindContext.Products.Local.Where
                (record => record.ReorderLevel > record.UnitsInStock && record.UnitsOnOrder == 0);                
        }

        private void navBtnDiscontinued_Click(object sender, EventArgs e)
        {
            productBindingSource.DataSource = dbNorthwindContext.Products.Local.Where
                (record => record.Discontinued == true);
        }

        private void navBtnAllProducts_Click(object sender, EventArgs e)
        {
            //products.load loads all the products to the database context,and then the binding source
            //is placed to equal to everything loaded locally into the context. 
            dbNorthwindContext.Products.Load();
            productBindingSource.DataSource = dbNorthwindContext.Products.Local;
        }

        #endregion Navigation Button events
    }
}
