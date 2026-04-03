namespace Shell.UI
{
    using ERMS.UI;
    using System;

    internal class VisumDatabaseFormFactory : IFormFactory
    {
        public ICollectionForm GetCollectionForm(OpenFormContext context) => 
            new CollectionForm();

        public EditForm GetEditForm(OpenFormContext context) => 
            new VisumDatabaseForm();
    }
}

