﻿using System.Collections.Generic;

using UpkManager.Entities.Constants;
using UpkManager.Entities.Tables;


namespace UpkManager.Entities.PropertyTypes {

  public class PropertyStructValue : PropertyValueBase {

    #region Properties

    public NameTableIndex StructNameIndex { get; set; }

    public List<Property> Properties { get; set; }

    #endregion Properties

    #region Overrides

    public override PropertyType PropertyType => PropertyType.StructProperty;

    public override void ReadPropertyValue(byte[] Data, ref int Index, UpkHeader header, out string message) {
      StructNameIndex = new NameTableIndex();

      if (!StructNameIndex.ReadNameTableIndex(Data, ref Index, header.NameTable, out message)) return;

      //Properties = new List<Property>();

      //do {
      //  Property prop = new Property();

      //  prop.ReadProperty(Data, ref Index, nameTable);

      //  Properties.Add(prop);

      //  if (prop.NameIndex.Name == ObjectType.None.ToString()) break;
      //} while(true);

      base.ReadPropertyValue(Data, ref Index, header, out message);
    }

    public override string ToString() {
      return $"{StructNameIndex.Name}";
    }

    #endregion Overrides

  }

}
