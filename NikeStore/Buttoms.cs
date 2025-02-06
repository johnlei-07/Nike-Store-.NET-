using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NikeStore
{
    public partial class Buttoms : Form
    {
        Order order = new Order();
        public Buttoms()
        {
            InitializeComponent();
        }

        private void label38_Click(object sender, EventArgs e)
        {
            Category c = new Category();
            c.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            tops t = new tops();
            t.Show();
            this.Hide();
        }

        private void Buttoms_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add(new ProductList()
            {
                Price = 0,
                ProductName = "",
                Category = "",

            });

            comboBox1.Items.Add(new ProductList()
            {
                Price = 3399,
                ProductName = "1.Nike Men's Jogger Grey",
                Category = "Buttoms",
            });
            comboBox1.Items.Add(new ProductList()
            {
                Price = 2699,
                ProductName = "2.Termal Jogger Pants",
                Category = "Buttoms",
            });
            comboBox1.Items.Add(new ProductList()
            {
                Price = 4299,
                ProductName = "3.Nike Air Fleece Waist",
                Category = "Buttoms",
            });
            comboBox1.Items.Add(new ProductList()
            {
                Price = 2399,
                ProductName = "4.Nike Air Max Pants",
                Category = "Buttoms",
            });
            comboBox1.Items.Add(new ProductList()
            {
                Price = 2700,
                ProductName = "5.Swoosh Woven Men's Short ",
                Category = "Buttoms",
            });
            comboBox1.Items.Add(new ProductList()
            {
                Price = 1699,
                ProductName = "6.Nike High Rise Short",
                Category = "Buttoms",
            });
            comboBox1.Items.Add(new ProductList()
            {
                Price = 2499,
                ProductName = "7.Alumni Men's Short",
                Category = "Buttoms",
            });
            comboBox1.Items.Add(new ProductList()
            {
                Price = 3499,
                ProductName = "8.Younger Boys Big Logo",
                Category = "Buttoms",
            });

            comboBox1.SelectedIndex = 0;




        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            ProductList pl = comboBox1.SelectedItem as ProductList;

            tb_price.Text = pl.Price.ToString();
            tb_productname.Text = pl.ProductName;
            tb_category.Text = pl.Category;
        }

        public class Order
        {
            private static string myConn = "Data Source=.\\sqlexpress;Initial Catalog=OrderDetails;Integrated Security=True;Encrypt=False";

            public string CustomerName { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public string ProductName { get; set; }
            public string Category { get; set; }
            public string Size { get; set; }
            public string OrderDate { get; set; }
            public string OrderReceive { get; set; }
            public int Price { get; set; }
            public int Quantity { get; set; }
            public int Total { get; set; }

            private const string SelectQuery = "Select * from Order_Details1";
            private const string InsertQuery = "Insert into Order_Details1 (CustomerName,Address,Phone,ProductName, Category,Size,OrderDate,OrderReceive,Price, Quantity,Total) Values (@CustomerName, @Address, @Phone,@ProductName,@Category,@Size,@OrderDate,@OrderReceive,@Price,@Quantity,@Total)";
            private const string UpdateQuery = "Update Order_Details1 set Address = @Address, Phone = @Phone, ProductName = @ProductName, Category = @Category, Size = @Size, OrderDate = @OrderDate, OrderReceive = @OrderReceive, Price = @Price, Quantity = @Quantity, Total = @Total where CustomerName = @CustomerName";
            private const string DeleteQuery = "Delete from Order_Details1 where CustomerName = @CustomerName";
            public DataTable GetOrder()
            {
                var datatable = new DataTable();
                using (SqlConnection con = new SqlConnection(myConn))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(SelectQuery, con))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                        {
                            adapter.Fill(datatable);
                        }
                    }
                }
                return datatable;
            }

            public bool InsertOrder(Order order)
            {
                int rows;
                using (SqlConnection con = new SqlConnection(myConn))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(InsertQuery, con))
                    {
                        com.Parameters.AddWithValue("@CustomerName", order.CustomerName);
                        com.Parameters.AddWithValue("@Address", order.Address);
                        com.Parameters.AddWithValue("@Phone", order.Phone);
                        com.Parameters.AddWithValue("@ProductName", order.ProductName);
                        com.Parameters.AddWithValue("@Category", order.Category);
                        com.Parameters.AddWithValue("@Size", order.Size);
                        com.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                        com.Parameters.AddWithValue("@OrderReceive", order.OrderReceive);
                        com.Parameters.AddWithValue("@Price", order.Price);
                        com.Parameters.AddWithValue("@Quantity", order.Quantity);
                        com.Parameters.AddWithValue("@Total", order.Total);
                        rows = com.ExecuteNonQuery();
                    }
                }
                return (rows > 0) ? true : false;
            }

            public bool UpdateOrder(Order order)
            {
                int rows;
                using (SqlConnection con = new SqlConnection(myConn))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(UpdateQuery, con))
                    {

                        com.Parameters.AddWithValue("@Address", order.Address);
                        com.Parameters.AddWithValue("@Phone", order.Phone);
                        com.Parameters.AddWithValue("@ProductName", order.ProductName);
                        com.Parameters.AddWithValue("@Category", order.Category);
                        com.Parameters.AddWithValue("@Size", order.Size);
                        com.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                        com.Parameters.AddWithValue("@OrderReceive", order.OrderReceive);
                        com.Parameters.AddWithValue("@Price", order.Price);
                        com.Parameters.AddWithValue("@Quantity", order.Quantity);
                        com.Parameters.AddWithValue("@Total", order.Total);
                        com.Parameters.AddWithValue("@CustomerName", order.CustomerName);

                        rows = com.ExecuteNonQuery();
                    }
                }
                return (rows > 0) ? true : false;
            }
            public bool DeleteOrder(Order order)
            {
                int rows;
                using (SqlConnection con = new SqlConnection(myConn))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(DeleteQuery, con))
                    {
                        com.Parameters.AddWithValue("@CustomerName", order.CustomerName);
                        rows = com.ExecuteNonQuery();
                    }
                }
                return (rows > 0) ? true : false;

            }

        }

        private void ClearControls()
        {
            tb_CustomerName.Text = "";
            tb_address.Text = "";
            tb_contact.Text = "";
            tb_productname.Text = "";
            tb_category.Text = "";
            cb_size.Text = "";
            tb_price.Text = "";
            quantity.Text = "";
        }

        private void btn_buynow_Click_1(object sender, EventArgs e)
        {
            if (quantity.Value == 0)
            {
                MessageBox.Show("Quantity cannot be zero. PLEASE UPDATE YOUR ORDER");
            }
            else if (cb_size.Text.Equals(""))
            {
                MessageBox.Show("Select your size. PLEASE UPDATE YOUR ORDER");
            }
            else if (comboBox1.Text.Equals(""))
            {
                MessageBox.Show("Select the product. PLEASE UPDATE YOUR ORDER");
            }
            else if (tb_contact.Text.Equals(""))
            {
                MessageBox.Show("Provide Contact no. PLEASE UPDATE YOUR ORDER");
            }
            else if (tb_CustomerName.Text.Equals(""))
            {
                MessageBox.Show("Provide Name. PLEASE UPDATE YOUR ORDER");
            }
            else if (tb_address.Text.Equals(""))
            {
                MessageBox.Show("Provide Address. PLEASE UPDATE YOUR ORDER");
            }

            order.CustomerName = tb_CustomerName.Text;
            order.Address = tb_address.Text;
            order.Phone = tb_contact.Text;
            order.ProductName = tb_productname.Text;
            order.Category = tb_category.Text;
            order.Size = cb_size.Text;
            order.OrderDate = dtp.Value.ToShortDateString();
            order.OrderReceive = "3-5 Days";
            //order.Price = int.Parse(tb_price.Text);
            if (!string.IsNullOrEmpty(tb_price.Text))
            {
                // Attempt to parse the text from tb_price.Text into an integer
                if (int.TryParse(tb_price.Text, out int price))
                {
                    // Parsing successful, assign the parsed value to order.Price
                    order.Price = price;

                    // Proceed with the rest of your logic
                    // ...
                }
                else
                {
                    // Display an error message if parsing fails
                    MessageBox.Show("Price must be a valid integer.");
                    // Optionally, clear the text box or take other action
                }
            }
            else
            {
                // Handle the case where tb_price.Text is empty
                MessageBox.Show("Price cannot be empty.");
                // Optionally, clear the text box or take other action
            }
            order.Quantity = int.Parse(quantity.Text);
            int result = order.Price * order.Quantity;
            order.Total = result;
            var success = order.InsertOrder(order);

            dgv_Orders.DataSource = order.GetOrder();
            if (success)
            {
                ClearControls();
                MessageBox.Show("Order has been added successfully");
            }
            else
            {
                MessageBox.Show("Error occured. Please try again...");
            }

        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

       
        private void label6_Click(object sender, EventArgs e)
        {
            Buttoms b = new Buttoms();
            b.Show();
            this.Hide();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            order.CustomerName = tb_CustomerName.Text;
            order.Address = tb_address.Text;
            order.Phone = tb_contact.Text;

            order.ProductName = tb_productname.Text;
            order.Category = tb_category.Text;
            order.Size = cb_size.Text;
            order.OrderDate = dtp.Value.ToShortDateString();
            order.OrderReceive = "3-5 Days";
            //order.Price = int.Parse(tb_price.Text);
            if (!string.IsNullOrEmpty(tb_price.Text))
            {
                // Attempt to parse the text from tb_price.Text into an integer
                if (int.TryParse(tb_price.Text, out int price))
                {
                    // Parsing successful, assign the parsed value to order.Price
                    order.Price = price;
                    order.Quantity = int.Parse(quantity.Text);
                    int result = order.Price * order.Quantity;
                    order.Total = result;
                    // Proceed with the rest of your logic
                    // ...
                }
                else
                {
                    // Display an error message if parsing fails
                    MessageBox.Show("Price must be a valid integer.");
                    // Optionally, clear the text box or take other action
                }
            }
            else
            {
                // Handle the case where tb_price.Text is empty
                MessageBox.Show("Price cannot be empty.");
                // Optionally, clear the text box or take other action
            }

            var success = order.UpdateOrder(order);

            dgv_Orders.DataSource = order.GetOrder();
            if (success)
            {
                ClearControls();
                MessageBox.Show("Order has been added successfully");
            }
            else
            {
                MessageBox.Show("Error occured. Please try again...");
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            order.CustomerName = tb_CustomerName.Text;
            var success = order.DeleteOrder(order);

            dgv_Orders.DataSource = order.GetOrder();
            if (success)
            {
                // Clear controls once the employee is inserted successfully
                ClearControls();
                MessageBox.Show("Order has been added successfully");
            }
            else
                MessageBox.Show("Error occured. Please try again...");
        }

        private void dgv_Orders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_Orders_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            var index = e.RowIndex;
            tb_CustomerName.Text = dgv_Orders.Rows[index].Cells[0].Value.ToString();
            tb_address.Text = dgv_Orders.Rows[index].Cells[1].Value.ToString();
            tb_contact.Text = dgv_Orders.Rows[index].Cells[2].Value.ToString();
            tb_productname.Text = dgv_Orders.Rows[index].Cells[3].Value.ToString();
            tb_category.Text = dgv_Orders.Rows[index].Cells[4].Value.ToString();
            cb_size.Text = dgv_Orders.Rows[index].Cells[5].Value.ToString();


            quantity.Text = dgv_Orders.Rows[index].Cells[7].Value.ToString();
            tb_price.Text = dgv_Orders.Rows[index].Cells[8].Value.ToString();
            //dtp.Text = dgv_Orders.Rows[index].Cells[6].Value.ToString();
            // tb_price.Text = dgv_Orders.Rows[index].Cells[6].Value.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            shoes s = new shoes();
            s.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            jersey j = new jersey();
            j.Show();
            this.Hide();
        }
    }
}
    
    

