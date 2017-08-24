using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMI_calculator
{
    public partial class BMICalculator : Form
    {
        //variables are initialized to 0
        private double height = 0;
        private double weight = 0;
        private int age = 0;
        private int gender = 0; //male:0, female:1
        private double bmi = 0;
        int language = 0; //english:0, french:1

        private bool heightValidated = false;
        private bool weightValidated = false;

        //variables are initialized corresponding to metric system
        double heightHigh = 2.2; //height upper limit im meters
        double heightLow = 0.2; //height lower limit in meters
        double weightHigh = 300; //weight upper limit in kg
        double weightLow = 10; //weight lower limit in kg
        int bmiMultiply = 1; //multiplier for bmi
        

        public BMICalculator()
        {
            InitializeComponent();
        }
           
        /**
         * Method responsible for the button to choose English language for the form.
         * It sets language to English and disables French buttons.
         */
        private void lblEnglish_Click(object sender, EventArgs e)
        {
            language = 0;
            picBmiResult.Visible = false;
            //enable english labels
            radioMaleEng.Checked = true;
             btnImperialEng.Visible = true;
            btnMetricEng.Visible = true;
            btnSubmitEng.Visible = true;
            btnRefreshEng.Visible = true;
            lblAgeEng.Visible = true;
            lblAgeErrorEng.Visible = false;
            lblEnterInfoEng.Visible = true;
            lblGenderEng.Visible = true;
            lblHeightEng.Visible = true;
            lblWeightEng.Visible = true;
            lblTitleEng.Visible = true;
            lblHeightWeightErrorEng.Visible = false;
            lblMeters.Visible = true;
            lblKg.Visible = true;
            lblYrsEng.Visible = true;
            radioFemaleEng.Visible = true;
            radioMaleEng.Visible = true;
           //disable french labels
            lblTitleFr.Visible = false;
            lblAgeFr.Visible = false;
            lblYrsFr.Visible = false;
            lblAgeErFr.Visible = false;
            lblEnterInfoFr.Visible = false;
            lblGenderFr.Visible = false;
            lblHeightWeightErrorFr.Visible = false;
            lblPoundsFr.Visible = false;
            lblInchesFr.Visible = false;
            lblHeightFr.Visible = false;
            lblWeightFr.Visible = false;
            radioFemaleFr.Visible = false;
            radioMaleFr.Visible = false;
            btnImperialFr.Visible = false;
            btnMetricFr.Visible = false;
            btnRefreshFr.Visible = false;
            btnSubmitFr.Visible = false;
        }

        /**
        * Method responsible for the button to choose French language for the form.
        * It sets language to French and disables English buttons.
        */
        private void lblFrench_Click(object sender, EventArgs e)
        {
            language = 1;
            picBmiResult.Visible = false;
           //disable english labels
            btnImperialEng.Visible = false;
            btnMetricEng.Visible = false;
            btnRefreshEng.Visible = false;
            btnSubmitEng.Visible = false;
            lblMeters.Visible = true;
            lblKg.Visible = true;
            lblAgeEng.Visible = false;
            lblAgeErrorEng.Visible = false;
            lblEnterInfoEng.Visible = false;
            lblGenderEng.Visible = false;
            lblHeightWeightErrorEng.Visible = false;
            lblHeightEng.Visible = false;
            lblTitleEng.Visible = false;
            lblWeightEng.Visible = false;
            lblYrsEng.Visible = false;
            radioFemaleEng.Visible = false;
            radioMaleEng.Visible = false;
            lblPoundsEng.Visible = false;
            lblInchesEng.Visible = false;
            //enable french labels
            lblTitleFr.Visible = true;
            lblAgeFr.Visible = true;
            lblAgeErFr.Visible = false;
            lblEnterInfoFr.Visible = true;
            lblGenderFr.Visible = true;
            lblPoundsFr.Visible = false;
            lblInchesFr.Visible = false;
            lblHeightWeightErrorFr.Visible = false;
            lblHeightFr.Visible = true;
            lblWeightFr.Visible = true;
            lblYrsFr.Visible = true;
            radioFemaleFr.Visible = true;
            radioMaleFr.Visible = true;
            radioMaleFr.Checked = true;
            btnImperialFr.Visible = true;
            btnMetricFr.Visible = true;
            btnSubmitFr.Visible = true;
            btnRefreshFr.Visible = true;
        }

        /**
         * Sets number system to metric, which is default (french interface). 
         * Disables imperial system labels.
         * Sets height and weight limits.
         */
        private void btnMetricFr_Click(object sender, EventArgs e)
        {
            btnMetricEng_Click(sender, e);
        }

        /**
         * Sets number system to metric, which is default (english interface). 
         * Disables imperial system labels.
         * Sets height and weight limits.
         */
        private void btnMetricEng_Click(object sender, EventArgs e)
        {
            lblPoundsEng.Visible = false;
            lblInchesEng.Visible = false;
            lblPoundsFr.Visible = false;
            lblInchesFr.Visible = false;
            
            lblKg.Visible = true;
            lblMeters.Visible = true;
            bmiMultiply = 1;
            heightHigh = 2.2;
            heightLow = 0.2;
            weightHigh = 300;
            weightLow = 10;
        }

        /**
         * Sets number system to imperial in French. Disables metric system labels.
         * Sets height and weight limits.
         */
        private void btnImperialFr_Click(object sender, EventArgs e)
        {
            btnImperialEng_Click(sender, e);
        }

        /**
         * Sets number system to imperial in English. Disables metric system labels.
         * Sets height and weight limits.
         */
        private void btnImperialEng_Click(object sender, EventArgs e)
        {
            lblKg.Visible = false;
            lblMeters.Visible = false;
            if (language == 0)
            {
                lblPoundsEng.Visible = true;
                lblInchesEng.Visible = true;
            }
            else
            {
                lblPoundsFr.Visible = true;
                lblInchesFr.Visible = true;
            }
            bmiMultiply = 703;
            heightHigh = 86.6;
            heightLow = 8;
            weightHigh = 661;
            weightLow = 22;

        }

        /**
         * Evaluates given string whether it is a valid double.
         * Sets error label if a character is invalid.
         * Returns true if it is and false otherwise.
         */
        private bool validDouble(String str)
        {
            lblHeightWeightErrorFr.Visible = false;
            lblHeightWeightErrorEng.Visible = false;
            int periodNum = 0;
            str = str.Trim();

            if(str.Equals(""))
            {
                displayWeightHeightError(str);
                return false;
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsDigit(str[i]))
                {
                    if (str[i] == '.' && periodNum == 0)
                        periodNum++;
                    else
                    {
                        displayWeightHeightError(str);
                        return false;
                    }
                }
            }
            return true;
        }

        /**
         * Displays the error message when user types the incorrect format for height or weight.
         */
        private void displayWeightHeightError(String str)
        {
            Console.Beep(1000, 550);
            if (language == 0)
            {
                lblHeightWeightErrorEng.Visible = true;
                MessageBox.Show("The input is invalid: " + str +
                    " \nThe value should be a decimal.");
            }
            else
            {
                lblHeightWeightErrorFr.Visible = true;
                MessageBox.Show("L'entrée est incorrecte: " + str +
                    " \nOn accepte seulement des nombres décimals.");
            }
        }

        /**
         * Evaluates whether input is a valid integer at the moment the user types
         * a character. Sets error label if a character is invalid.
         */
        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblAgeErrorEng.Visible = false;
            if (!Char.IsDigit(e.KeyChar))
            {
                Console.Beep(1000, 450);
                if (language == 0)
                    lblAgeErrorEng.Visible = true;
                else
                    lblAgeErFr.Visible = true;
                e.Handled = true;
            }
        }

        /**
         * Sets gender to male (english interface).
         */
        private void radioMaleEng_CheckedChanged(object sender, EventArgs e)
        {
            gender = 0;
        }

        /**
         * Sets gender to male (french interface).
         */
        private void radioMaleFr_CheckedChanged(object sender, EventArgs e)
        {
            gender = 0;
        }

        /**
         * Sets gender to female (english interface).
         */
        private void radioFemaleEng_CheckedChanged(object sender, EventArgs e)
        {
            gender = 1;
        }

        /**
         * Sets gender to female (french interface).
         */
        private void radioFemaleFr_CheckedChanged(object sender, EventArgs e)
        {
            gender = 1;
        }

        /**
         * Evaluates height and weight ranges and prints error messages accordingly 
         * (french interface).
         * If the values are valid, calculates bmi
         */
        private void btnSubmitFr_Click(object sender, EventArgs e)
        {
            btnSubmitEng_Click(sender, e);
        }

        /**
         * Evaluates height and weight ranges and prints error messages accordingly 
         * (english interface).
         * If the values are valid, calculates bmi
         */
        private void btnSubmitEng_Click(object sender, EventArgs e)
        {
            lblHeightWeightErrorEng.Visible = false;
            lblHeightWeightErrorFr.Visible = false;
            lblAgeErFr.Visible = false;
            lblAgeErrorEng.Visible = false;

            try
            {
                age = int.Parse(txtAge.Text);

                heightValidated = validDouble(txtHeight.Text.ToString());
                weightValidated = validDouble(txtWeight.Text.ToString());
            }
            
            //catches when age textbox is empty.
            catch (System.FormatException) {
                MessageBox.Show("The input is invalid! | L'entrée est incorrecte!");
            }

            
           if (heightValidated)
           {
               height = double.Parse(txtHeight.Text);
               if (height < heightLow || height > heightHigh)
               {
                   heightValidated = false;
                   Console.Beep(1000, 550);
                   if (language == 0)
                       lblHeightWeightErrorEng.Visible = true;
                   else
                       lblHeightWeightErrorFr.Visible = true;
                   MessageBox.Show("Height range is | La portée de la taille est " + heightLow + " - " + 
                       heightHigh + ": " + height);
               }
           }

           if (weightValidated)
           {
               weight = double.Parse(txtWeight.Text);
               if (weight < weightLow || weight > weightHigh)
               {
                   weightValidated = false;
                   Console.Beep(1000, 550);
                   if (language == 0)
                       lblHeightWeightErrorEng.Visible = true;
                   else
                       lblHeightWeightErrorFr.Visible = true;
                   MessageBox.Show("Weight range is | La portée du poids est " + weightLow + " - " + 
                       weightHigh + ": " + weight);
               }
           }

           if(age > 200) 
           {
               Console.Beep(1000, 550);
               if (language == 0)
               {
                   MessageBox.Show("The age value is invalid! " + txtAge.Text + "\nIt should be less than 200 years.");
                   lblAgeErrorEng.Visible = true;
               }
               else
               {
                   MessageBox.Show("L'entrée pour l'âge est incorrecte! " + txtAge.Text + "\nIl doit être plus petit que 200 ans.");
                   lblAgeErFr.Visible = true;
               }
           }
           else if (heightValidated && weightValidated)
           {
               bmi = weight / height / height*bmiMultiply;
               estimateBMI();
            }
          
        }

        /**
         * Estimates bmi results according to age and gender.
         */
        private void estimateBMI()
        {
            if (age <= 19)
                bmiChildren();
            else if (age >= 65)
                bmiSeniors();
            else if (gender == 0)
                bmiMale();
            else 
                bmiFemale();
        }

        /**
         * Determines bmi result meaning for males.
         */
        private void bmiMale()
        {
            if (bmi <= 18)
                bmiUnderWeightDisplay();

            else if (bmi <= 26)
                bmiNormalWeightDisplay();

            else if (bmi <= 31)
                bmiOverWeightDisplay();

            else
                bmiObeseDisplay();
        }

        /**
         * Determines bmi result meaning for females.
         */
        private void bmiFemale()
        {
            if (bmi <= 18)
                bmiUnderWeightDisplay();

            else if (bmi <= 24)
                bmiNormalWeightDisplay();

            else if (bmi <= 29)
                bmiOverWeightDisplay();

            else
                bmiObeseDisplay();
        }

        /**
         * Determines bmi result meaning for children.
         */
        private void bmiChildren()
        {
            if (bmi <= 15)
                bmiUnderWeightDisplay();

            else if (bmi <= 22)
                bmiNormalWeightDisplay();

            else if (bmi <= 26)
                bmiOverWeightDisplay();

            else
                bmiObeseDisplay();
        }

        /**
         * Determines bmi result meaning for seniors.
         */
        private void bmiSeniors()
        {
            if (bmi <= 19)
                bmiUnderWeightDisplay();
            
            else if (bmi <= 24)
                bmiNormalWeightDisplay();
               
            else if (bmi <= 28)
                bmiOverWeightDisplay();
                
            else
                bmiObeseDisplay();
        }

        /**
         * Displays underweight message depending on chosen language.
         */
        private void bmiUnderWeightDisplay()
        {
            if (language == 0)
                MessageBox.Show("Risk of developing problems such as nutritional deficiency and osteoporosis.");
            else
                MessageBox.Show("Risques de co-morbidités sont faibles, " +
                    "mais plus grands risques pour d'autres problèmes cliniques dont la mortalité.");

            picBmiResult.Image = BMI_calculator.Properties.Resources.cruella;
            picBmiResult.Visible = true;
            
        }

        /**
         * Displays normal weight message depending on chosen language.
         */
        private void bmiNormalWeightDisplay()
        {
            if (language == 0)
                MessageBox.Show("Low health risk (healthy range).");
            else
                MessageBox.Show("Risques de co-morbidités sont faibles.");

            picBmiResult.Image = BMI_calculator.Properties.Resources.garfield;
            picBmiResult.Visible = true;
        }

        /**
         * Displays overweight message depending on chosen language.
         */
        private void bmiOverWeightDisplay()
        {
            if (language == 0)
                MessageBox.Show("Moderate risk of developing heart disease, high blood pressure, stroke, diabetes.");
            else
                MessageBox.Show("Surpoids. Il y a des certains risques de co-morbidités.");

            picBmiResult.Image = BMI_calculator.Properties.Resources.obelix;
            picBmiResult.Visible = true;
        }

        /**
         * Displays obese message depending on chosen language.
         */
        private void bmiObeseDisplay() 
        {
            if (language == 0)
                MessageBox.Show("High risk of developing heart disease, high blood pressure, stroke, diabetes.");
            else
                MessageBox.Show("Élevés risques de co-morbidités.");


           picBmiResult.Image = BMI_calculator.Properties.Resources.ursula; 
           picBmiResult.Visible = true;
        }

        /**
         * Clears text boxes and removes the image (english interface).
         */
        private void btnRefreshEng_Click(object sender, EventArgs e)
        {
            txtAge.Clear();
            txtHeight.Clear();
            txtWeight.Clear();
            lblEnglish_Click(sender, e);
        }

        /**
         * Clears text boxes and removes the image (french interface).
         */
        private void btnRefreshFr_Click(object sender, EventArgs e)
        {
            txtAge.Clear();
            txtHeight.Clear();
            txtWeight.Clear();
            lblFrench_Click(sender, e);
        }

        /**
         * Shows information about BMI when the user hovers over the title (english interface).
         */
        private void lblTitleEng_MouseHover(object sender, EventArgs e)
        {
            MessageBox.Show("BMI is a measure of body fat based on height and weight.");
        }

        /**
         * Shows information about BMI when the user hovers over the title (french interface).
         */
        private void lblTitleFr_MouseHover(object sender, EventArgs e)
        {
            MessageBox.Show("IMC est un outil vous permettant d'évaluer votre degré général d'obésité.");
        }

    }
}
