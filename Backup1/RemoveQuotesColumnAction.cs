using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;
using AT.ETL;
using ERMS.Core.Common;
using ERMS.Core.DAL;
using ERMS.Core.DbMould;
using System.Collections;

namespace ETL.Plugin.RemoveQuotes
{
  /// <summary>
  /// Пример модуля расширения действий над колонкой
  /// </summary>
  [DisplayName("Удаление кавычек")]
  [DataContract]
  public class RemoveQuotesColumnAction : ColumnAction, ILookupProvider
  {
    [DataMember]
    [DisplayName("Исходная колонка Text")]
    [Category("Источник")]
    [TypeConverter(typeof(LookupTypeConverter))]
    public string SourceTextColumn
    {
      get { return _(() => this.SourceTextColumn); }
      set { _(() => this.SourceTextColumn, value); }
    }

    [DataMember]
    [DisplayName("Конечная колонка Text")]
    [Category("Приёмник")]
    [TypeConverter(typeof(LookupTypeConverter))]
    public string DestinationTextColumn
    {
      get { return _(() => this.DestinationTextColumn); }
      set { _(() => this.DestinationTextColumn, value); }
    }

    public override bool Validate(InfoBuffer buffer)
    {
      var ret = this.AutoCheckLookupProperties(buffer);
      return ret;
    }

    public override bool Execute(IDataRow source, EditableRow destination, InfoBuffer buffer)
    {
      string text = source[this.SourceTextColumn] as string;

      if (text.StartsWith("\"") && text.EndsWith("\""))
        text = text.Substring(1, text.Length - 2);

      destination[this.DestinationTextColumn] = text;

      return true;
    }

    public override string[] GetFillColumns()
    {
      return new string[] { this.DestinationTextColumn };
    }

    #region ILookupProvider Members

    IList ILookupProvider.GetLookupValues(string propertyName)
    {
      var parent = this.Parent;

      if (parent != null)
        switch (propertyName)
        {
          case "SourceTextColumn":
            return this.GetColumnLookup(parent.SourceTable);
          case "DestinationTextColumn":
            return this.GetColumnLookup(parent.DestinationTable);
        }

      return null;
    }

    private IList GetColumnLookup(TableMould table)
    {
      if (table != null)
        return table.Columns.Where(col => col.ColumnType is StringTypeMould).Select(col => col.Name).ToArray();
      return null;
    }

    #endregion
  }
}
