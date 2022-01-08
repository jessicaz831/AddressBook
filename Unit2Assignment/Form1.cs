// Jessica Zhu
// Mar 21, 2019
// Create an address book with unlimited arrays
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unit2Assignment
{
    public partial class Form1 : Form
    {
        // declare length of array as a constant integer
        const int ARRAY_LENGTH = 0;

        // declare arrays with length 0 for all info
        string[] firstName = new string[ARRAY_LENGTH];
        string[] lastName = new string[ARRAY_LENGTH];
        string[] gender = new string[ARRAY_LENGTH];
        string[] phone = new string[ARRAY_LENGTH];
        string[] address = new string[ARRAY_LENGTH];
        int[] age = new int[ARRAY_LENGTH];
        string[] email = new string[ARRAY_LENGTH];
        bool[] favourite = new bool[ARRAY_LENGTH];

        // make a copy of each array for resizing
        string[] copyFirstName;
        string[] copyLastName;
        string[] copyGender;
        string[] copyPhone;
        string[] copyAddress;
        int[] copyAge;
        string[] copyEmail;
        bool[] copyFavourite;

        // declare array and copy for searching
        int[] search = new int[ARRAY_LENGTH];
        int[] copySearch;

        // save length of array, starting at 0
        int arraySize = 0;
        int favouriteArraySize = 0;
        int searchArraySize = 0;
        // save if contact is favourited or not, starting at false
        bool favourited = false;
        // save if a search is being made or not, starting at false
        bool searching = false;
        bool searchingFavourites = false;

        // save displayed contact index, starting at 0
        int display = 0;
        int searchDisplay = 0;

        // declare genders as constant strings
        const string MALE = "Male";
        const string FEMALE = "Female";
        const string OTHER = "Other";
        const string NONE = "";
        
        // save selected gender for contact
        string selectedGender;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // hide contact displaying labels, unnecessary buttons and picture boxes
            lblFirstName.Hide();
            lblLastName.Hide();
            lblGender.Hide();
            lblPhone.Hide();
            lblAddress.Hide();
            lblAge.Hide();
            lblEmail.Hide();
            lblWarning.Hide();
            btnSubmit.Hide();
            btnEdit.Hide();
            btnRoulette.Hide();
            picGender.Hide();
            picStar.Hide();
            picStar2.Hide();
            btnSave.Hide();
            lblBirthday.Hide();
            btnLeft.Hide();
            btnRight.Hide();

            // hide textboxes and gender selection
            txtFirstName.Hide();
            txtLastName.Hide();
            lblMale.Hide();
            lblFemale.Hide();
            lblOther.Hide();
            txtPhone.Hide();
            txtAddress.Hide();
            txtAge.Hide();
            txtEmail.Hide();
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            // show labels, hide unnecessary buttons and picture boxes
            lblFirstName.Show();
            lblLastName.Show();
            lblGender.Show();
            lblPhone.Show();
            lblAddress.Show();
            lblAge.Show();
            lblEmail.Show();
            lblNoContact.Hide();
            btnAddContact.Hide();
            btnEdit.Hide();
            btnRight.Hide();
            btnLeft.Hide();
            picGender.Hide();
            btnRoulette.Hide();
            picStar2.Hide();
            txtSearch.Hide();
            btnSearch.Hide();
            btnFavourites.Hide();
            btnAllContacts.Hide();

            // show textboxes and gender selection for user to input info
            txtFirstName.Show();
            txtLastName.Show();
            lblMale.Show();
            lblFemale.Show();
            lblOther.Show();
            txtPhone.Show();
            txtAddress.Show();
            txtAge.Show();
            txtEmail.Show();
            btnSubmit.Show();
            picStar.Show();

            // display what info the user should input in the labels
            lblFirstName.Text = "First name: ";
            lblLastName.Text = "Last name: ";
            lblGender.Text = "Gender: ";
            lblPhone.Text = "Phone number: ";
            lblAddress.Text = "Address: ";
            lblAge.Text = "Age: ";
            lblEmail.Text = "Email: ";

            // reset contact
            ContactReset();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // if no textboxes are blank...
            if (txtFirstName.Text != "" && txtLastName.Text != "" && txtPhone.Text != "" && txtAddress.Text != "" && txtAge.Text != "" && txtEmail.Text != "")
            {
                // and a gender is selected...
                if (selectedGender == MALE || selectedGender == FEMALE || selectedGender == OTHER)
                {
                    // hide textboxes, gender selection, unnecessary buttons and picture boxes
                    txtFirstName.Hide();
                    txtLastName.Hide();
                    lblMale.Hide();
                    lblFemale.Hide();
                    lblOther.Hide();
                    txtPhone.Hide();
                    txtAddress.Hide();
                    txtAge.Hide();
                    txtEmail.Hide();
                    btnSubmit.Hide();
                    lblWarning.Hide();
                    picStar.Hide();

                    // show other options like, edit contact, add contact, left and right buttons, chat roulette
                    // show gender icon
                    btnEdit.Show();
                    btnAddContact.Show();
                    btnRight.Show();
                    btnLeft.Show();
                    picStar2.Show();
                    picGender.Show();
                    btnRoulette.Show();
                    txtSearch.Show();
                    btnSearch.Show();
                    btnFavourites.Show();
                    btnAllContacts.Show();

                    // resize the array
                    ArrayResize();

                    // add the new contact to the array
                    NewContact();

                    // display the newest contact
                    DisplayContact();
                }
            }
            else
            {
                // if any info is missing, show a warning to input all info
                lblWarning.Show();
            }
        }

        private void lblMale_Click(object sender, EventArgs e)
        {
            // if user clicks on male, selected gender is MALE
            selectedGender = MALE;

            // highlight male label
            lblMale.BackColor = Color.Yellow;
            lblFemale.BackColor = Color.Transparent;
            lblOther.BackColor = Color.Transparent;
        }

        private void lblFemale_Click(object sender, EventArgs e)
        {
            // if user clicks on female, selected gender is FEMALE
            selectedGender = FEMALE;

            // highlight female label
            lblMale.BackColor = Color.Transparent;
            lblFemale.BackColor = Color.Yellow;
            lblOther.BackColor = Color.Transparent;
        }

        private void lblOther_Click(object sender, EventArgs e)
        {
            // if user clicks on other, selected gender is OTHER
            selectedGender = OTHER;

            // highlight other label
            lblMale.BackColor = Color.Transparent;
            lblFemale.BackColor = Color.Transparent;
            lblOther.BackColor = Color.Yellow;
        }

        void ContactReset()
        {
            // empty textboxes
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtAge.Text = "";
            txtEmail.Text = "";

            // empty selected gender
            selectedGender = NONE;

            // unhighlight all gender selection labels
            lblMale.BackColor = Color.Transparent;
            lblFemale.BackColor = Color.Transparent;
            lblOther.BackColor = Color.Transparent;

            // make favourite star unselected
            picStar.Image = Properties.Resources.EmptyStar;
            // set favourited to false
            favourited = false;
        }

        void NewContact()
        {
            // set last index in array to whatever is in the textbox
            firstName[arraySize] = txtFirstName.Text;
            lastName[arraySize] = txtLastName.Text;
            gender[arraySize] = selectedGender;
            phone[arraySize] = txtPhone.Text;
            address[arraySize] = txtAddress.Text;
            int.TryParse(txtAge.Text, out age[arraySize]);
            email[arraySize] = txtEmail.Text;

            if (favourited == true)
            {
                // if favourited is true, save true in the array
                favourite[arraySize] = true;
            }
            else if (favourited == false)
            {
                // if favourited is false, save false in the array
                favourite[arraySize] = false;
            }
            // display index is equal to the length of the array
            display = arraySize;
            // increment array length
            arraySize++;

        }
        void SaveEdit()
        {
            // set currently displayed contact's array to whatever is in the textbox
            firstName[display] = txtFirstName.Text;
            lastName[display] = txtLastName.Text;
            gender[display] = selectedGender;
            phone[display] = txtPhone.Text;
            address[display] = txtAddress.Text;
            int.TryParse(txtAge.Text, out age[display]);
            email[display] = txtEmail.Text;

            if (favourited == true)
            {
                // if favourited is true, save true in the array
                favourite[display] = true;
            }
            else if (favourited == false)
            {
                // if favourited is false, save false in the array
                favourite[display] = false;
            }
        }

        void ArrayResize()
        {
            // only resize if array length variable is equal to the length of the arrays
            if (arraySize == firstName.Length)
            {
                // set all copy arrays to be as long as the original array
                copyFirstName = new string[firstName.Length];
                copyLastName = new string[lastName.Length];
                copyGender = new string[gender.Length];
                copyPhone = new string[phone.Length];
                copyAddress = new string[address.Length];
                copyAge = new int[age.Length];
                copyEmail = new string[email.Length];
                copyFavourite = new bool[favourite.Length];

                // copy all info from original arrays to copy arrays
                for (int i = 0; i < arraySize; i++)
                {
                    copyFirstName[i] = firstName[i];
                    copyLastName[i] = lastName[i];
                    copyGender[i] = gender[i];
                    copyPhone[i] = phone[i];
                    copyAddress[i] = address[i];
                    copyAge[i] = age[i];
                    copyEmail[i] = email[i];
                    copyFavourite[i] = favourite[i];
                }

                // increase original array lengths by 1
                firstName = new string[firstName.Length + 1];
                lastName = new string[lastName.Length + 1];
                gender = new string[gender.Length + 1];
                phone = new string[phone.Length + 1];
                address = new string[address.Length + 1];
                age = new int[age.Length + 1];
                email = new string[email.Length + 1];
                favourite = new bool[favourite.Length + 1];

                // copy info from copy arrays back to original arrays
                for (int i = 0; i < copyFirstName.Length; i++)
                {
                    firstName[i] = copyFirstName[i];
                    lastName[i] = copyLastName[i];
                    gender[i] = copyGender[i];
                    phone[i] = copyPhone[i];
                    address[i] = copyAddress[i];
                    age[i] = copyAge[i];
                    email[i] = copyEmail[i];
                    favourite[i] = copyFavourite[i];
                }
            }
        }

        void SearchResize()
        {
            // only resize if needed
            if (search.Length <= favouriteArraySize || search.Length >= searchArraySize)
            {
                // set copy array to be as long as original array
                copySearch = new int[search.Length];

                // copy all info from original array to copy array
                for (int i = 0; i < search.Length; i++)
                {
                    copySearch[i] = search[i];
                }
                
                // increase original array by 1
                search = new int[search.Length + 1];

                // copy info from copy array back to original array
                for (int i = 0; i < copySearch.Length; i++)
                {
                    search[i] = copySearch[i];
                }
            }
        }

        private void picStar_Click(object sender, EventArgs e)
        {
            if (favourited == false)
            {
                // if contact is not favourited, when user clicks the star, contact is favourited
                favourited = true;
                // change image of white star to yellow star
                picStar.Image = Properties.Resources.GoldStar;
            }
            else if (favourited == true)
            {
                // if contact is favourited, when user clicks the star, contact is unfavourited
                favourited = false;
                // change image of yellow star to white star
                picStar.Image = Properties.Resources.EmptyStar;
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            // if user is searching only favourites...
            if (searchingFavourites == true)
            {
                // increment search display variable
                searchDisplay++;
                // if the displayed contact index is greater than or equal to the array length...
                if (searchDisplay >= favouriteArraySize)
                {
                    // return to 0, the first contact
                    searchDisplay = 0;
                }
                // display the contact
                SearchDisplayContact();
            }
            // if user is searching...
            else if (searching == true)
            {
                // increment search display variable
                searchDisplay++;
                // if the displayed contact index is greater than or equal to the array length...
                if (searchDisplay >= searchArraySize)
                {
                    // return to 0, the first contact
                    searchDisplay = 0;
                }
                // display the contact
                SearchDisplayContact();
            }
            else
            {
                // increment display variable
                display++;
                // if the displayed contact index is greater than or equal to the array length...
                if (display >= arraySize)
                {
                    // return to 0, the first contact
                    display = 0;
                }
                // display the contact
                DisplayContact();
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            // if user is searching only favourites...
            if (searchingFavourites == true)
            {
                // decrement search display variable
                searchDisplay--;
                // if displayed contact index is less than 0...
                if (searchDisplay < 0)
                {
                    // return to one less of the length of the array, the most recent contact that is favourited
                    searchDisplay = favouriteArraySize - 1;
                }
                // display the contact
                SearchDisplayContact();
            }
            // if user is searching...
            else if (searching == true)
            {
                // decrement search display variable
                searchDisplay--;
                // if displayed contact index is less than 0...
                if (searchDisplay < 0)
                {
                    // return to one less of the length of the array, the most recent contact that fulfills the search
                    searchDisplay = searchArraySize - 1;
                }
                // display the contact
                SearchDisplayContact();
            }
            else
            {
                // decrement display variable
                display--;
                // if the displayed contact index is less than 0...
                if (display < 0)
                {
                    // return to one less of the length of the array, the most recent contact
                    display = firstName.Length - 1;
                }
                // display the contact
                DisplayContact();
            }
        }

        void DisplayContact()
        {
            // hide no contact label
            lblNoContact.Hide();

            // if the displayed contact's gender is male...
            if (gender[display] == MALE)
            {
                // change image to male symbol
                picGender.Image = Properties.Resources.male;
            }
            // if the displayed contact's gender is female...
            else if (gender[display] == FEMALE)
            {
                // change image to female symbol
                picGender.Image = Properties.Resources.female;
            }
            // if the displayed contact's gender is other...
            else if (gender[display] == OTHER)
            {
                // change image to other symbol
                picGender.Image = Properties.Resources.other;
            }

            // if the displayed contact is favourited...
            if (favourite[display] == true)
            {
                // change image of star to yellow star
                picStar2.Image = Properties.Resources.GoldStar;
            }
            // if the displayed contact is not favourited...
            else if (favourite[display] == false)
            {
                // change image of star to white star
                picStar2.Image = Properties.Resources.EmptyStar;
            }

            // display all info for the contact
            lblFirstName.Text = "First name: " + firstName[display];
            lblLastName.Text = "Last name: " + lastName[display];
            lblGender.Text = "Gender: " + gender[display];
            lblPhone.Text = "Phone number: " + phone[display];
            lblAddress.Text = "Address: " + address[display];
            lblAge.Text = "Age: " + age[display].ToString();
            lblEmail.Text = "Email: " + email[display];
        }

        void SearchDisplayContact()
        {
            // if user is searching for a contact...
            if (searchingFavourites == true || searching == true)
            {
                // hide no contact label
                lblNoContact.Hide();

                // Show contact displaying labels, buttons and picture boxes
                lblFirstName.Show();
                lblLastName.Show();
                lblGender.Show();
                lblPhone.Show();
                lblAddress.Show();
                lblAge.Show();
                lblEmail.Show();
                btnEdit.Show();
                btnRoulette.Show();
                picGender.Show();
                picStar2.Show();
                btnAddContact.Show();
                btnLeft.Show();
                btnRight.Show();

                // if the displayed contact's gender is male...
                if (gender[search[searchDisplay]] == MALE)
                {
                    // change image to male symbol
                    picGender.Image = Properties.Resources.male;
                }
                // if the displayed contact's gender is female...
                else if (gender[search[searchDisplay]] == FEMALE)
                {
                    // change image to female symbol
                    picGender.Image = Properties.Resources.female;
                }
                // if the displayed contact's gender is other...
                else if (gender[search[searchDisplay]] == OTHER)
                {
                    // change image to other symbol
                    picGender.Image = Properties.Resources.other;
                }

                // if the displayed contact is favourited...
                if (favourite[search[searchDisplay]] == true)
                {
                    // change image of star to yellow star
                    picStar2.Image = Properties.Resources.GoldStar;
                }
                // if the displayed contact is not favourited...
                else if (favourite[search[searchDisplay]] == false)
                {
                    // change image of star to white star
                    picStar2.Image = Properties.Resources.EmptyStar;
                }

                // display all info for the contact
                lblFirstName.Text = "First name: " + firstName[search[searchDisplay]];
                lblLastName.Text = "Last name: " + lastName[search[searchDisplay]];
                lblGender.Text = "Gender: " + gender[search[searchDisplay]];
                lblPhone.Text = "Phone number: " + phone[search[searchDisplay]];
                lblAddress.Text = "Address: " + address[search[searchDisplay]];
                lblAge.Text = "Age: " + age[search[searchDisplay]].ToString();
                lblEmail.Text = "Email: " + email[search[searchDisplay]];

            }
            
            else
            {
                // show no contact label
                lblNoContact.Show();
                // display that no results were found
                lblNoContact.Text = "No search results";

                // hide contact displaying labels, unnecessary buttons and picture boxes
                lblFirstName.Hide();
                lblLastName.Hide();
                lblGender.Hide();
                lblPhone.Hide();
                lblAddress.Hide();
                lblAge.Hide();
                lblEmail.Hide();
                lblWarning.Hide();
                btnSubmit.Hide();
                btnEdit.Hide();
                btnRoulette.Hide();
                picGender.Hide();
                picStar.Hide();
                picStar2.Hide();
                btnSave.Hide();
                lblBirthday.Hide();
                btnAddContact.Hide();
                btnLeft.Hide();
                btnRight.Hide();
            }
        }

        private void btnRoulette_Click(object sender, EventArgs e)
        {
            // only run if there's at least one contact
            if (arraySize > 0)
            {
                // declare random variable
                Random roulette = new Random();
                int random;
                // choose a random number between 0 and the length of the array
                random = roulette.Next(0, arraySize);

                // set the displayed contact index to the random number
                display = random;
                // display contact
                DisplayContact();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // hide unnecessary buttons and picture boxes
            btnAddContact.Hide();
            btnEdit.Hide();
            btnRight.Hide();
            btnLeft.Hide();
            btnRoulette.Hide();
            picStar2.Hide();
            picGender.Hide();
            txtSearch.Hide();
            btnSearch.Hide();
            btnFavourites.Hide();
            btnAllContacts.Hide();

            // show textboxes and gender selection for user to input info
            txtFirstName.Show();
            txtLastName.Show();
            lblMale.Show();
            lblFemale.Show();
            lblOther.Show();
            txtPhone.Show();
            txtAddress.Show();
            txtAge.Show();
            txtEmail.Show();
            btnSave.Show();
            picStar.Show();
            
            // display what info the user should input in the labels
            lblFirstName.Text = "First name: ";
            lblLastName.Text = "Last name: ";
            lblGender.Text = "Gender: ";
            lblPhone.Text = "Phone number: ";
            lblAddress.Text = "Address: ";
            lblAge.Text = "Age: ";
            lblEmail.Text = "Email: ";

            // if user is searching for a contact...
            if (searching == true || searchingFavourites == true)
            {
                // put currently displayed info into corresponding textboxes for editing
                txtFirstName.Text = firstName[search[searchDisplay]];
                txtLastName.Text = lastName[search[searchDisplay]];
                txtPhone.Text = phone[search[searchDisplay]];
                txtAddress.Text = address[search[searchDisplay]];
                txtAge.Text = age[search[searchDisplay]].ToString();
                txtEmail.Text = email[search[searchDisplay]];

                // if the displayed contact is favourited...
                if (favourite[search[searchDisplay]] == true)
                {
                    // change image of star to yellow star
                    picStar.Image = Properties.Resources.GoldStar;
                }
                // if the displayed contact is not favourited...
                else if (favourite[search[searchDisplay]] == false)
                {
                    // change image of star to white star
                    picStar.Image = Properties.Resources.EmptyStar;
                }

                // if the displayed contact's gender is male...
                if (gender[search[searchDisplay]] == MALE)
                {
                    // highlight male
                    lblMale.BackColor = Color.Yellow;
                    lblFemale.BackColor = Color.Transparent;
                    lblOther.BackColor = Color.Transparent;
                }
                // if the displayed contact's gender is female...
                else if (gender[search[searchDisplay]] == FEMALE)
                {
                    // highlight female
                    lblMale.BackColor = Color.Transparent;
                    lblFemale.BackColor = Color.Yellow;
                    lblOther.BackColor = Color.Transparent;
                }
                // if the displayed contact's gender is other...
                else if (gender[search[searchDisplay]] == OTHER)
                {
                    // highlight other
                    lblMale.BackColor = Color.Transparent;
                    lblFemale.BackColor = Color.Transparent;
                    lblOther.BackColor = Color.Yellow;
                }
            }
            
            else
            {
                // put currently displayed info into corresponding textboxes for editing
                txtFirstName.Text = firstName[display];
                txtLastName.Text = lastName[display];
                txtPhone.Text = phone[display];
                txtAddress.Text = address[display];
                txtAge.Text = age[display].ToString();
                txtEmail.Text = email[display];

                // if the displayed contact is favourited...
                if (favourite[display] == true)
                {
                    // change image of star to yellow star
                    picStar.Image = Properties.Resources.GoldStar;
                }
                // if the displayed contact is not favourited...
                else if (favourite[display] == false)
                {
                    // change image of star to white star
                    picStar.Image = Properties.Resources.EmptyStar;
                }

                // if the displayed contact's gender is male...
                if (gender[display] == MALE)
                {
                    // highlight male
                    lblMale.BackColor = Color.Yellow;
                    lblFemale.BackColor = Color.Transparent;
                    lblOther.BackColor = Color.Transparent;
                }
                // if the displayed contact's gender is female...
                else if (gender[display] == FEMALE)
                {
                    // highlight female
                    lblMale.BackColor = Color.Transparent;
                    lblFemale.BackColor = Color.Yellow;
                    lblOther.BackColor = Color.Transparent;
                }
                // if the displayed contact's gender is other...
                else if (gender[display] == OTHER)
                {
                    // highlight other
                    lblMale.BackColor = Color.Transparent;
                    lblFemale.BackColor = Color.Transparent;
                    lblOther.BackColor = Color.Yellow;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // if no textboxes are blank...
            if (txtFirstName.Text != "" && txtLastName.Text != "" && txtPhone.Text != "" && txtAddress.Text != "" && txtAge.Text != "" && txtEmail.Text != "")
            {
                // and a gender is selected...
                if (selectedGender == MALE || selectedGender == FEMALE || selectedGender == OTHER)
                {
                    // hide textboxes, gender selection, unnecessary buttons and picture boxes
                    txtFirstName.Hide();
                    txtLastName.Hide();
                    lblMale.Hide();
                    lblFemale.Hide();
                    lblOther.Hide();
                    txtPhone.Hide();
                    txtAddress.Hide();
                    txtAge.Hide();
                    txtEmail.Hide();
                    btnSave.Hide();
                    lblWarning.Hide();
                    picStar.Hide();

                    // show other options like, edit contact, add contact, left and right buttons, chat roulette
                    // show gender icon
                    btnEdit.Show();
                    btnAddContact.Show();
                    btnRight.Show();
                    btnLeft.Show();
                    picStar2.Show();
                    picGender.Show();
                    btnRoulette.Show();
                    txtSearch.Show();
                    btnSearch.Show();
                    btnFavourites.Show();
                    btnAllContacts.Show();

                    // save edited info to array
                    SaveEdit();
                    // display edited contact
                    DisplayContact();
                }
            }
            else
            {
                // if any info is missing, show a warning to input all info
                lblWarning.Show();
            }
        }

        // birthday runs every minute (60000 milliseconds)
        private void tmrBirthday_Tick(object sender, EventArgs e)
        {
            // show birthday label
            lblBirthday.Show();
            // declare random variable
            Random birthday = new Random();
            int random;
            // generate a random number between 0 and the length of the age array
            random = birthday.Next(0, age.Length);
            // increment the age for the contact at that random index
            age[random]++;
            // display a message saying it's their birthday and how old they are
            lblBirthday.Text = "It's " + firstName[random] + " " + lastName[random] + "'s birthday! \r\nThey are now " + age[random] + " years old!";
            // display the contact
            DisplayContact();
        }

        private void btnFavourites_Click(object sender, EventArgs e)
        {
            // searching is false unless favourites are found
            searching = false;
            searchingFavourites = false;
            // set array lengths to 0 and display to 0
            searchDisplay = 0;
            favouriteArraySize = 0;
            searchArraySize = 0;

            for (int i = 0; i < firstName.Length; i++)
            {
                // if contact is favourited...
                if (favourite[i] == true)
                {
                    // searching favourites is true
                    searchingFavourites = true;
                    // resize search arrays
                    SearchResize();
                    // index of search array is equal to the index of the contact
                    search[searchDisplay] = i;
                    // increment array size and display index
                    favouriteArraySize++;
                    searchDisplay++;
                }
            }
            // set display to 0 to display first contact
            searchDisplay = 0;
            // display searched contact
            SearchDisplayContact();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // searching is false unless results are found
            searchingFavourites = false;
            searching = false;
            // set array lengths to 0 and display to 0
            searchDisplay = 0;
            favouriteArraySize = 0;
            searchArraySize = 0;

            for (int i = 0; i < firstName.Length; i++)
            {
                // if results are found...
                if (firstName[i] == txtSearch.Text || lastName[i] == txtSearch.Text || phone[i] == txtSearch.Text)
                {
                    // searching is true
                    searching = true;
                    // resize search arrays
                    SearchResize();
                    // index of search array is equal to the index of the contact
                    search[searchDisplay] = i;
                    // increment array size and display index
                    searchArraySize++;
                    searchDisplay++;
                }
            }
            // set display to 0 to display first contact
            searchDisplay = 0;
            // display searched contact
            SearchDisplayContact();
            // clear search bar
            txtSearch.Text = "";
        }

        private void btnAllContacts_Click(object sender, EventArgs e)
        {
            // only display all contacts if there are contacts
            if (arraySize > 0)
            {
                // Show contact displaying labels, buttons and picture boxes
                lblFirstName.Show();
                lblLastName.Show();
                lblGender.Show();
                lblPhone.Show();
                lblAddress.Show();
                lblAge.Show();
                lblEmail.Show();
                btnEdit.Show();
                btnRoulette.Show();
                picGender.Show();
                picStar2.Show();
                btnAddContact.Show();
                btnLeft.Show();
                btnRight.Show();

                // searching is false since user is no longer searching
                searchingFavourites = false;
                searching = false;
                // display set to 0 to display first contact saved
                display = 0;
                // everything else set to 0 to avoid bugs
                searchDisplay = 0;
                favouriteArraySize = 0;
                searchArraySize = 0;
                // display contact
                DisplayContact();
            }
            else
            {
                // show no contact label
                lblNoContact.Show();
                // display that there are no contacts
                lblNoContact.Text = "No contacts";
                // show add contact button
                btnAddContact.Show();
            }
        }
    }
}
