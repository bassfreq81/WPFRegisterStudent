using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFRegisterStudent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Course choice;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Course course1 = new Course("IT 145");
            Course course2 = new Course("IT 200");
            Course course3 = new Course("IT 201");
            Course course4 = new Course("IT 270");
            Course course5 = new Course("IT 315");
            Course course6 = new Course("IT 328");
            Course course7 = new Course("IT 330");


            this.comboBox.Items.Add(course1);
            this.comboBox.Items.Add(course2);
            this.comboBox.Items.Add(course3);
            this.comboBox.Items.Add(course4);
            this.comboBox.Items.Add(course5);
            this.comboBox.Items.Add(course6);
            this.comboBox.Items.Add(course7);


            this.textBox.Text = "";
        }

#pragma warning disable IDE1006 // Naming Styles
        private void button_Click(object sender, RoutedEventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            //Adds the choice to the registered courses textbox
            choice = (Course)(this.comboBox.SelectedItem);

            //Performs the validation

            //Starts a nested if statement that first checks if class
            //has already been registered
            if (choice.IsRegisteredAlready() == true)

                label3.Content = ("You have already registered for this course " + choice +".");

            //Validates no more that 9 credits have been chosen
            else if (this.textBox.Text == "9")

                label3.Content = ("You cannot register for more than 9 credit hours.");

            //If class is not registered it performs this else statement
            else
            {
                //Adds choice to list box
                this.listBox.Items.Add(choice);
                //Assigns course to registered
                choice.SetToRegistered();

                //Starts the Total credit hours to 0
                //If credit hours is 0 once course is registered it adds 3 credits
                if (this.textBox.Text == "")

                    this.textBox.Text = "3";

                //If credit hours is 3 once course is registered it adds 3 credits
                else if (this.textBox.Text == "3")

                    this.textBox.Text = "6";

                //If credit hours is 6 once course is registered it adds 3 credits
                else if (this.textBox.Text == "6")

                    this.textBox.Text = "9";

                //After course is sucessfully registered it displays confirmation
                label3.Content = ("Registration confirmed for course " + choice + ".");
            }
        }

#pragma warning disable IDE1006 // Naming Styles
        //This adds a Close button which allows users to exit
        private void exit_Click_1(object sender, RoutedEventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            this.Close();
        }
    }   
}
