using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;
using ERMS.Core.Common;
using ERMS.Core.DAL;
using ERMS.Core.DbMould;
using System.Collections;
using ACS.BLL;

namespace ETL.Plugin.ACS.OperatorLoader
{
  /// <summary>
  /// Пример модуля расширяющего операции на таблицами
  /// </summary>
  [DisplayName("Обновление таблицы перевозчиков")]
  [DataContract]
  public class OperatorUpdateAction : AT.ETL.UpdateAction
  {
    public override void Execute(IDataRow source, EditableRow destination)
    {
      // Получение списка перевозчиков АСУ
      var operators = new SinglePhaseCollection<OPERATOR>();
      //operators.DataBind();

      foreach(var o in operators)
      {
        bool found = false;

        // Поиск перевозчика в перекрёстном справочнике

        if (!found)
        {
          // Вставка нового перевозчика
        }
      }

    }
  }
}
