using System.Collections;
using System.Data.Common;

namespace Phonebook.model
{
    internal class NoteSQL
    {
        int secondaryKey;

        public string contactNname;
        public string phoneNumber;
        public string email_address;
        public string addInfo;

        public void noteSQL()
        {          
            string insertSqlname = string.Format("INSERT INTO 'name_tab' ('name') VALUES ('{0}')", contactNname);
            SQLQuery.writeQuery(insertSqlname);

            string selectSqlID = "SELECT MAX(`name_tab_id`) FROM `name_tab`";
            ArrayList reader = SQLQuery.readQuery(selectSqlID);
            foreach (DbDataRecord record in reader)
                secondaryKey = int.Parse(record[0] + " ");

            string insertSqlphone = string.Format("INSERT INTO 'phone_tab' ('phone_name_fk', 'phone_number') VALUES ('{0}', '{1}')", secondaryKey, phoneNumber);
            SQLQuery.writeQuery(insertSqlphone);

            string insertSqlemail = string.Format("INSERT INTO 'email_tab' ('email_name_fk', 'email_address') VALUES ('{0}', '{1}')", secondaryKey, email_address);
            SQLQuery.writeQuery(insertSqlemail);

            String insertSqlInfo = string.Format("INSERT INTO 'comment_tab' ('comment_name_fk', 'comment') VALUES ('{0}', '{1}')", secondaryKey, addInfo);
            SQLQuery.writeQuery(insertSqlInfo);
        }
    }
}
