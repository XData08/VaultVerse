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
using PasswordManagementSystem.Models;

namespace PasswordManagementSystem.Views.TemplateView
{
    /// <summary>
    /// Interaction logic for ButtonModifyForm.xaml
    /// </summary>
    public partial class ButtonModifyForm : UserControl
    {
        public interface MyInterface
        {
            void updateData(string toChange);
            void deleteData(string toChange);
        }
        #region CredentialAccount
        public class CredentialAccount : MyInterface
        {
            private string[] information;
            private string databaseName;
            public string this[int index]
            {
                set
                {
                    if (index >= 0 && index < 7)
                    {
                        this.information[index] = value;
                    }
                }
            }
            public CredentialAccount(string databaseName)
            {
                this.databaseName = databaseName;
                this.information = new string[7];
                return;
            }
            public void updateData(string toChange)
            {
                DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.updateData(toChange, this.information, "credential_account");
                return;
            }
            public void deleteData(string toChange){
                DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.decrement("user_credential_no");
                template.deleteData(toChange, this.information, "credential_account");
            }
        }
        #endregion
        #region CredentialAddress
        public class CredentialAddress : MyInterface
        {
            private string[] information;
            private string databaseName;
            public string this[int index]
            {
                set
                {
                    if (index >= 0 && index < 9)
                    {
                        this.information[index] = value;
                    }
                }
            }
            public CredentialAddress(string databaseName)
            {
                this.information = new string[9];
                this.databaseName = databaseName;
                return;
            }
            public void updateData(string toChange)
            {
                DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.updateData(toChange, this.information, "credential_address");
                return;
            }
            public void deleteData(string toChange){
                DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.decrement("user_credential_no");
                template.deleteData(toChange, this.information, "credential_address");
            }
        }
        #endregion
        #region CredentialBankAccount
        public class CredentialBankAccount : MyInterface
        {
            private string[] information;
            private string databaseName;
            public string this[int index]
            {
                set
                {
                    if (index >= 0 && index < 7)
                    {
                        this.information[index] = value;
                    }
                }
            }
            public CredentialBankAccount(string databaseName)
            {
                this.information = new string[7];
                this.databaseName = databaseName;
                return;
            }
            public void updateData(string toChange)
            {
                DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.updateData(toChange, this.information, "credential_bank_account");
                return;
            }
            public void deleteData(string toChange){
                DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.decrement("user_credential_no");
                template.deleteData(toChange, this.information, "credential_bank_account");
            }
        }
        #endregion
        #region CredentialDriversLicense
        public class CredentialDriversLicense : MyInterface
        {
            private string[] information;
            private string databaseName;
            public string this[int index]
            {
                set
                {
                    if (index >= 0 && index < 12)
                    {
                        this.information[index] = value;
                    }
                }
            }
            public CredentialDriversLicense(string databaseName)
            {
                this.information = new string[12];
                this.databaseName = databaseName;
                return;
            }
            public void updateData(string toChange)
            {
                DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.updateData(toChange, this.information, "credential_drivers_license");
                return;
            }
            public void deleteData(string toChange){
                DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.decrement("user_credential_no");
                template.deleteData(toChange, this.information, "credential_bank_account");
            }
        }
        #endregion
        #region CredentialPaymentCard
        public class CredentialPaymentCard : MyInterface
        {
            private string[] information;
            private string databaseName;
            public string this[int index]
            {
                set
                {
                    if (index >= 0 && index < 7)
                    {
                        this.information[index] = value;
                    }
                }
            }

            public CredentialPaymentCard(string databaseName)
            {
                this.information = new string[7];
                this.databaseName = databaseName;
                return;
            }
            public void updateData(string toChange)
            {
                DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.updateData(toChange, this.information, "credential_payment_card");
                return;
            }
            public void deleteData(string toChange){
                DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.decrement("user_credential_no");
                template.deleteData(toChange, this.information, "credential_payment_card");
            }
        }
        #endregion

        #region RecordLecture
        public class RecordLecture : MyInterface
        {
            private string[] information;
            private string databaseName;
            public string this[int index]
            {
                set
                {
                    if (index >= 0 && index < 5)
                    {
                        this.information[index] = value;
                    }
                }
            }
            public RecordLecture(string databaseName)
            {
                this.information = new string[5];
                this.databaseName = databaseName;
                return;
            }
            public void updateData(string toChange)
            {
                DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.updateData(toChange, this.information, "record_lecture");
                return;
            }
            public void deleteData(string toChange){
                DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.decrement("user_record_no");
                template.deleteData(toChange, this.information, "record_lecture");
            }
        }
        #endregion
        #region RecordToDoList
        public class RecordToDoList : MyInterface
        {
            private string[] information;
            private string databaseName;
            public string this[int index]
            {
                set
                {
                    if (index >= 0 && index < 3)
                    {
                        this.information[index] = value;
                    }
                }
            }
            public RecordToDoList(string databaseName)
            {
                this.information = new string[3];
                this.databaseName = databaseName;
                return;
            }
            public void updateData(string toChange)
            {
                DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.updateData(toChange, this.information, "record_to_do_list");

                return;
            }
            public void deleteData(string toChange){
                DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.decrement("user_record_no");
                template.deleteData(toChange, this.information, "record_to_do_list");
            }
            
        }
        #endregion
        #region RecordSchedule
        public class RecordSchedule : MyInterface
        {
            private string[] information;
            private string databaseName;
            public string this[int index]
            {
                set
                {
                    if (index >= 0 && index < 10)
                    {
                        this.information[index] = value;
                    }
                }
            }
            public RecordSchedule(string databaseName)
            {
                this.information = new string[10];
                this.databaseName = databaseName;
                return;
            }
            public void updateData(string toChange)
            {
                DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.updateData(toChange, this.information, "record_schedule");
                return;
            }
            public void deleteData(string toChange){
                DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.decrement("user_record_no");
                template.deleteData(toChange, this.information, "record_schedule");
            }
        }
        #endregion
        #region RecordCollaboration
        public class RecordCollaboration : MyInterface
        {
            private string[] information;
            private string databaseName;
            public string this[int index]
            {
                set
                {
                    if (index >= 0 && index < 4)
                    {
                        this.information[index] = value;
                    }
                }
            }
            public RecordCollaboration(string databaseName)
            {
                this.information = new string[4];
                this.databaseName = databaseName;
                return;
            }
            public void updateData(string toChange)
            {
                DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.updateData(toChange, this.information, "record_collaboration");
                return;
            }
            public void deleteData(string toChange){
                DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.decrement("user_record_no");
                template.deleteData(toChange, this.information, "record_collaboration");
            }
        }
        #endregion

        #region GalleryImage
        public class GalleryImage : MyInterface
        {
            private string[] information;
            private string databaseName;
            public string this[int index]
            {
                set
                {
                    if (index >= 0 && index < 3)
                    {
                        this.information[index] = value;
                    }
                }
            }
            public GalleryImage(string databaseName)
            {
                this.information = new string[3];
                this.databaseName = databaseName;
                return;
            }
            public void updateData(string toChange)
            {
                DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.updateData(toChange, this.information, "gallery_image");
                return;
            }
            public void deleteData(string toChange){
                DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.decrement("user_gallery_no");
                template.deleteData(toChange, this.information, "gallery_image");
            }
        }
        #endregion
        #region GalleryVideo
        public class GalleryVideo : MyInterface
        {
            private string[] information;
            private string databaseName;
            public string this[int index]
            {
                set
                {
                    if (index >= 0 && index < 3)
                    {
                        this.information[index] = value;
                    }
                }
            }
            public GalleryVideo(string databaseName)
            {
                this.information = new string[3];
                this.databaseName = databaseName;
                return;
            }
            public void updateData(string toChange)
            {
                DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.updateData(toChange, this.information, "gallery_video");

                return;
            }
            public void deleteData(string toChange){
                    DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.decrement("user_gallery_no");
                template.deleteData(toChange, this.information, "gallery_video");
            }
        }
        #endregion

        #region DocumentZip
        public class DocumentZip : MyInterface
        {
            private string[] information;
            private string databaseName;
            public string this[int index]
            {
                set
                {
                    if (index >= 0 && index < 3)
                    {
                        this.information[index] = value;
                    }
                }
            }
            public DocumentZip(string databaseName)
            {
                this.information = new string[3];
                this.databaseName = databaseName;
                return;
            }
            public void updateData(string toChange)
            {
                DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.updateData(toChange, this.information, "document_zip");

                return;
            }
            public void deleteData(string toChange){
                DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.decrement("user_document_no");
                template.deleteData(toChange, this.information, "document_zip");
            }
        }
        #endregion
        #region DocumentFile
        public class DocumentFile : MyInterface
        {
            private string[] information;
            private string databaseName;
            public string this[int index]
            {
                set
                {
                    if (index >= 0 && index < 3)
                    {
                        this.information[index] = value;
                    }
                }
            }
            public DocumentFile(string databaseName)
            {
                this.information = new string[3];
                this.databaseName = databaseName;
                return;
            }
            public void updateData(string toChange)
            {
                DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.updateData(toChange, this.information, "document_file");

                return;
            }
            public void deleteData(string toChange){
                DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.decrement("user_document_no");
                template.deleteData(toChange, this.information, "document_file");
            }
            
        }
        #endregion
        #region DocumentFolder
        public class DocumentFolder : MyInterface
        {
            private string[] information;
            private string databaseName;
            public string this[int index]
            {
                set
                {
                    if (index >= 0 && index < 3)
                    {
                        this.information[index] = value;
                    }
                }
            }
            public DocumentFolder(string databaseName)
            {
                this.information = new string[3];
                this.databaseName = databaseName;
                return;
            }
            public void updateData(string toChange)
            {
                DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.updateData(toChange, this.information, "record_folder");

                return;
            }
            public void deleteData(string toChange){
                DatabaseTemplate template = new DatabaseTemplate(this.databaseName);
                template.decrement("user_document_no");
                template.deleteData(toChange, this.information, "record_folder");
            
            }
        }
        #endregion

        public CredentialAccount credentialAccount;
        public CredentialAddress credentialAddress;
        public CredentialBankAccount credentialBankAccount;
        public CredentialDriversLicense credentialDriversLicense;
        public CredentialPaymentCard credentialPaymentCard;

        public RecordLecture recordLecture;
        public RecordToDoList recordToDoList;
        public RecordSchedule recordSchedule;
        public RecordCollaboration recordCollaboration;

        public GalleryImage galleryImage;
        public GalleryVideo galleryVideo;

        public DocumentZip documentZip;
        public DocumentFile documentFile;
        public DocumentFolder documentFolder;

        private Window window;
        private MainWindow main;
        private string template;
        public string toChange;

        public ButtonModifyForm(Window window, MainWindow main,string databaseName, string template = null)
        {
            InitializeComponent();
            this.main = main;
            this.window = window;
            this.template = template;

            this.credentialAccount = new CredentialAccount(databaseName);
            this.credentialAddress = new CredentialAddress(databaseName);
            this.credentialBankAccount = new CredentialBankAccount(databaseName);
            this.credentialDriversLicense = new CredentialDriversLicense(databaseName);
            this.credentialPaymentCard = new CredentialPaymentCard(databaseName);

            this.recordLecture = new RecordLecture(databaseName);
            this.recordToDoList = new RecordToDoList(databaseName);
            this.recordSchedule = new RecordSchedule(databaseName);
            this.recordCollaboration = new RecordCollaboration(databaseName);

            this.galleryImage = new GalleryImage(databaseName);
            this.galleryVideo = new GalleryVideo(databaseName);

            this.documentZip = new DocumentZip(databaseName);
            this.documentFile = new DocumentFile(databaseName);
            this.documentFolder = new DocumentFolder(databaseName);
            return;
        }

        private void UpdateButton(object sender, RoutedEventArgs e)
        {
            if (this.template == "CredentialAccount")
            {
                this.credentialAccount.updateData(this.toChange);
            }
            else if (this.template == "CredentialAddress")
            {
                this.credentialAddress.updateData(this.toChange);
            } 
            else if (this.template == "CredentialBankAccount")
            {
                this.credentialBankAccount.updateData(this.toChange);
            }
            else if (this.template == "CredentialDriversLicense")
            {
                this.credentialDriversLicense.updateData(this.toChange);
            } 
            else if (this.template == "CredentialPaymentCard")
            {
                this.credentialPaymentCard.updateData(this.toChange);
            } 
            else if (this.template == "RecordLecture")
            {
                this.recordLecture.updateData(this.toChange);
            } 
            else if (this.template == "RecordToDoList")
            {
                this.recordToDoList.updateData(this.toChange);
            } 
            else if (this.template == "RecordSchedule")
            {
                this.recordSchedule.updateData(this.toChange);
            } 
            else if (this.template == "RecordCollaboration")
            {
                this.recordCollaboration.updateData(this.toChange);
            }
            else if (this.template == "GalleryImage")
            {
                this.galleryImage.updateData(this.toChange);
            }
            else if (this.template == "GalleryVideo")
            {
                this.galleryVideo.updateData(this.toChange);
            }
            else if (this.template == "DocumentZIP")
            {
                this.documentZip.updateData(this.toChange);
            } 
            else if (this.template == "DocumentFile")
            {
                this.documentFile.updateData(this.toChange);
            } 
            else if (this.template == "DocumentFolder")
            {
                this.documentFolder.updateData(this.toChange);
            } 
            else
            {
                Console.WriteLine("Error");    
            }

            this.window.Close();
            this.main.WindowState = WindowState.Normal;
            this.main.ReloadAllListView();
            return;
        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            if (this.template == "CredentialAccount")
            {
                this.credentialAccount.deleteData(this.toChange);
            }
            else if (this.template == "CredentialAddress")
            {
                this.credentialAddress.deleteData(this.toChange);
            } 
            else if (this.template == "CredentialBankAccount")
            {
                this.credentialBankAccount.deleteData(this.toChange);
            }
            else if (this.template == "CredentialDriversLicense")
            {
                this.credentialDriversLicense.deleteData(this.toChange);
            } 
            else if (this.template == "CredentialPaymentCard")
            {
                this.credentialPaymentCard.deleteData(this.toChange);
            } 
            else if (this.template == "RecordLecture")
            {
                this.recordLecture.deleteData(this.toChange);
            } 
            else if (this.template == "RecordToDoList")
            {
                this.recordToDoList.deleteData(this.toChange);
            } 
            else if (this.template == "RecordSchedule")
            {
                this.recordSchedule.deleteData(this.toChange);
            } 
            else if (this.template == "RecordCollaboration")
            {
                this.recordCollaboration.deleteData(this.toChange);
            }
            else if (this.template == "GalleryImage")
            {
                this.galleryImage.deleteData(this.toChange);
            }
            else if (this.template == "GalleryVideo")
            {
                this.galleryVideo.deleteData(this.toChange);
            }
            else if (this.template == "DocumentZIP")
            {
                this.documentZip.deleteData(this.toChange);
            } 
            else if (this.template == "DocumentFile")
            {
                this.documentFile.deleteData(this.toChange);
            } 
            else if (this.template == "DocumentFolder")
            {
                this.documentFolder.deleteData(this.toChange);
            } 
            else
            {
                Console.WriteLine("Error");    
            }

            this.window.Close();
            this.main.WindowState = WindowState.Normal;
            this.main.ReloadAllListView();
            return;
        }
    }
}
