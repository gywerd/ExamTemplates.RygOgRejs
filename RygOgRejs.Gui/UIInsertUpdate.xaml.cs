using RygOgRejs.Bizz.App;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace RygOgRejs.Gui
{
	/// <summary>
	/// Interaction logic for UIInsertUpdate.xaml
	/// </summary>
	public partial class UIInsertUpdate : UserControl
	{
		//added region
		#region Fields
		AppBizz CAB;
		#endregion

		public UIInsertUpdate(AppBizz bizz)
		{
			InitializeComponent();
			CAB = bizz;
			InitializeContent();

		}

		#region Buttons
		private void ButtonCreateJourney_Click(object sender, RoutedEventArgs e)
		{
			bool AdultsOK = false;
			bool ChildrensOK = false;
			bool LuggageOK = false;
			if (int.TryParse(textBoxAdults.Text, out int textBoxAdultsInt))
			{
				AdultsOK = true;
			}
			if (int.TryParse(textBoxChildren.Text, out int textBoxChildrenInt))
			{
				ChildrensOK = true;
			}
			if (int.TryParse(textBoxLuggage.Text, out int textBoxLuggageInt))
			{
				LuggageOK = true;
			}
			else
			{

			}

			if (LuggageOK == true && AdultsOK == true && ChildrensOK == true)
			{
				CAB.CreateJourney(textBoxAdultsInt, textBoxChildrenInt, textBoxLuggageInt, CAB.TempJourney.IsFirstClass);
			}
			else
			{
				MessageBox.Show("Indeholder ugyldige tegn");
			}
		}

		private void ButtonDeleteJourney_Click(object sender, RoutedEventArgs e)
		{
			CAB.DeleteJourney();
		}

		private void ButtonEditJourney_Click(object sender, RoutedEventArgs e)
		{
			CAB.EditJourney();
		}
		#endregion

		#region Events
		private void CheckBoxFirstClass_isChecked(object sender, RoutedEventArgs e)
		{
			if (checkBoxFirstClass.IsChecked == true)
			{
				CAB.TempJourney.IsFirstClass = true;
			}
			else
			{
				CAB.TempJourney.IsFirstClass = false;
			}
		}

		private void TextBoxFirstName_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(textBoxFirstName.Text))
			{
				bool Gyldig = false;
				foreach  (char c in textBoxFirstName.Text)
				{
					if (!char.IsLetter(c))
					{
						Gyldig = false;
						MessageBox.Show("Fornavn må ikke indeholde ugyldige tegn eller tal.");
						textBoxFirstName.BorderBrush = Brushes.Red;
						textBoxFirstName.BorderThickness = new Thickness(2);
					}
					else
					{
						Gyldig = true;
						textBoxFirstName.BorderBrush = Brushes.Transparent;
						textBoxFirstName.BorderThickness = new Thickness(1);
					}
				}
				if (Gyldig == true)
				{
					textBoxFirstName.BorderBrush = Brushes.Green;
					textBoxFirstName.BorderThickness = new Thickness(2);
				}
			}
			else
			{
				textBoxFirstName.BorderBrush = Brushes.Red;
				textBoxFirstName.BorderThickness = new Thickness(2);
			}
		}

		private void TextBoxLastName_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(textBoxLastName.Text))
			{
				bool Gyldig = false;
				foreach (char c in textBoxLastName.Text)
				{
					if (!char.IsLetter(c))
					{
						Gyldig = false;
						MessageBox.Show("Fornavn må ikke indeholde ugyldige tegn eller tal.");
						textBoxLastName.BorderBrush = Brushes.Red;
						textBoxLastName.BorderThickness = new Thickness(2);
					}
					else
					{
						Gyldig = true;
						textBoxLastName.BorderBrush = Brushes.Transparent;
						textBoxLastName.BorderThickness = new Thickness(1);
					}
				}
				if (Gyldig == true)
				{
					textBoxLastName.BorderBrush = Brushes.Green;
					textBoxLastName.BorderThickness = new Thickness(2);
				}

			}
			else
			{
				textBoxLastName.BorderBrush = Brushes.Red;
				textBoxLastName.BorderThickness = new Thickness(2);
			}
		}
		#endregion

		#region Methods
		private void InitializeContent()
		{
			if (CAB.JourneyOrTransaction == "transaction")
			{
				buttonCreateJourney.Visibility = Visibility.Hidden;
				buttonEditJourney.Visibility = Visibility.Visible;
				buttonDeleteJourney.Visibility = Visibility.Visible;
			}
			else
			{
				buttonCreateJourney.Visibility = Visibility.Visible;
				buttonEditJourney.Visibility = Visibility.Hidden;
				buttonDeleteJourney.Visibility = Visibility.Hidden;
				//labelChosenDestination.Content = CAB.Journey.Destination;
				labelChosenDestination.Content = CAB.TempJourney.Destination; //corrected reference
			}
		}

		#endregion

	}
}
