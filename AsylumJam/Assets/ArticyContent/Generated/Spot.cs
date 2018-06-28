// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Articy.Unity;
using Articy.Unity.Interfaces;

namespace Articy.Asylumjame
{
    
    
    public class Spot : ArticyObject, ISpot, IPropertyProvider, IObjectWithColor, IObjectWithDisplayName, IObjectWithPreviewImage, IObjectWithText, IObjectWithExternalId, IObjectWithShortId, IObjectWithPosition, IObjectWithZIndex, IObjectWithSize
    {
        
        [SerializeField()]
        private String mDisplayName;
        
        [SerializeField()]
        private Color mColor;
        
        [SerializeField()]
        private String mText;
        
        [SerializeField()]
        private String mExternalId;
        
        [SerializeField()]
        private Vector2 mPosition;
        
        [SerializeField()]
        private Single mZIndex;
        
        [SerializeField()]
        private Vector2 mSize;
        
        [SerializeField()]
        private PreviewImage mPreviewImage = new PreviewImage();
        
        [SerializeField()]
        private UInt32 mShortId;
        
        [SerializeField()]
        private VisibilityModes mVisibility = new VisibilityModes();
        
        [SerializeField()]
        private Boolean mShowDisplayName = new Boolean();
        
        [SerializeField()]
        private Color mDisplayNameColor;
        
        [SerializeField()]
        private Int32 mDisplayNameSize;
        
        [SerializeField()]
        private Color mOutlineColor;
        
        [SerializeField()]
        private Single mOutlineSize;
        
        [SerializeField()]
        private OutlineStyle mOutlineStyle = new OutlineStyle();
        
        [SerializeField()]
        private Boolean mDropShadow = new Boolean();
        
        [SerializeField()]
        private SelectabilityModes mSelectability = new SelectabilityModes();
        
        public String DisplayName
        {
            get
            {
                return mDisplayName;
            }
            set
            {
                mDisplayName = value;
            }
        }
        
        public Color Color
        {
            get
            {
                return mColor;
            }
            set
            {
                mColor = value;
            }
        }
        
        public String Text
        {
            get
            {
                return mText;
            }
            set
            {
                mText = value;
            }
        }
        
        public String ExternalId
        {
            get
            {
                return mExternalId;
            }
            set
            {
                mExternalId = value;
            }
        }
        
        public Vector2 Position
        {
            get
            {
                return mPosition;
            }
            set
            {
                mPosition = value;
            }
        }
        
        public Single ZIndex
        {
            get
            {
                return mZIndex;
            }
            set
            {
                mZIndex = value;
            }
        }
        
        public Vector2 Size
        {
            get
            {
                return mSize;
            }
            set
            {
                mSize = value;
            }
        }
        
        public PreviewImage PreviewImage
        {
            get
            {
                return mPreviewImage;
            }
            set
            {
                mPreviewImage = value;
            }
        }
        
        public UInt32 ShortId
        {
            get
            {
                return mShortId;
            }
            set
            {
                mShortId = value;
            }
        }
        
        public VisibilityModes Visibility
        {
            get
            {
                return mVisibility;
            }
            set
            {
                mVisibility = value;
            }
        }
        
        public Boolean ShowDisplayName
        {
            get
            {
                return mShowDisplayName;
            }
            set
            {
                mShowDisplayName = value;
            }
        }
        
        public Color DisplayNameColor
        {
            get
            {
                return mDisplayNameColor;
            }
            set
            {
                mDisplayNameColor = value;
            }
        }
        
        public Int32 DisplayNameSize
        {
            get
            {
                return mDisplayNameSize;
            }
            set
            {
                mDisplayNameSize = value;
            }
        }
        
        public Color OutlineColor
        {
            get
            {
                return mOutlineColor;
            }
            set
            {
                mOutlineColor = value;
            }
        }
        
        public Single OutlineSize
        {
            get
            {
                return mOutlineSize;
            }
            set
            {
                mOutlineSize = value;
            }
        }
        
        public OutlineStyle OutlineStyle
        {
            get
            {
                return mOutlineStyle;
            }
            set
            {
                mOutlineStyle = value;
            }
        }
        
        public Boolean DropShadow
        {
            get
            {
                return mDropShadow;
            }
            set
            {
                mDropShadow = value;
            }
        }
        
        public SelectabilityModes Selectability
        {
            get
            {
                return mSelectability;
            }
            set
            {
                mSelectability = value;
            }
        }
        
        protected override void CloneProperties(object aClone)
        {
            Spot newClone = ((Spot)(aClone));
            newClone.DisplayName = DisplayName;
            newClone.Color = Color;
            newClone.Text = Text;
            newClone.ExternalId = ExternalId;
            newClone.Position = Position;
            newClone.ZIndex = ZIndex;
            newClone.Size = Size;
            newClone.PreviewImage = PreviewImage;
            newClone.ShortId = ShortId;
            newClone.Visibility = Visibility;
            newClone.ShowDisplayName = ShowDisplayName;
            newClone.DisplayNameColor = DisplayNameColor;
            newClone.DisplayNameSize = DisplayNameSize;
            newClone.OutlineColor = OutlineColor;
            newClone.OutlineSize = OutlineSize;
            newClone.OutlineStyle = OutlineStyle;
            newClone.DropShadow = DropShadow;
            newClone.Selectability = Selectability;
            base.CloneProperties(newClone);
        }
        
        public override bool IsLocalizedPropertyOverwritten(string aProperty)
        {
            return base.IsLocalizedPropertyOverwritten(aProperty);
        }
        
        #region property provider interface
        public override void setProp(string aProperty, object aValue)
        {
            if ((aProperty == "DisplayName"))
            {
                DisplayName = System.Convert.ToString(aValue);
                return;
            }
            if ((aProperty == "Color"))
            {
                Color = ((Color)(aValue));
                return;
            }
            if ((aProperty == "Text"))
            {
                Text = System.Convert.ToString(aValue);
                return;
            }
            if ((aProperty == "ExternalId"))
            {
                ExternalId = System.Convert.ToString(aValue);
                return;
            }
            if ((aProperty == "Position"))
            {
                Position = ((Vector2)(aValue));
                return;
            }
            if ((aProperty == "ZIndex"))
            {
                ZIndex = System.Convert.ToSingle(aValue);
                return;
            }
            if ((aProperty == "Size"))
            {
                Size = ((Vector2)(aValue));
                return;
            }
            if ((aProperty == "PreviewImage"))
            {
                PreviewImage = ((PreviewImage)(aValue));
                return;
            }
            if ((aProperty == "ShortId"))
            {
                ShortId = ((UInt32)(aValue));
                return;
            }
            if ((aProperty == "Visibility"))
            {
                Visibility = ((VisibilityModes)(aValue));
                return;
            }
            if ((aProperty == "ShowDisplayName"))
            {
                ShowDisplayName = System.Convert.ToBoolean(aValue);
                return;
            }
            if ((aProperty == "DisplayNameColor"))
            {
                DisplayNameColor = ((Color)(aValue));
                return;
            }
            if ((aProperty == "DisplayNameSize"))
            {
                DisplayNameSize = System.Convert.ToInt32(aValue);
                return;
            }
            if ((aProperty == "OutlineColor"))
            {
                OutlineColor = ((Color)(aValue));
                return;
            }
            if ((aProperty == "OutlineSize"))
            {
                OutlineSize = System.Convert.ToSingle(aValue);
                return;
            }
            if ((aProperty == "OutlineStyle"))
            {
                OutlineStyle = ((OutlineStyle)(aValue));
                return;
            }
            if ((aProperty == "DropShadow"))
            {
                DropShadow = System.Convert.ToBoolean(aValue);
                return;
            }
            if ((aProperty == "Selectability"))
            {
                Selectability = ((SelectabilityModes)(aValue));
                return;
            }
            base.setProp(aProperty, aValue);
        }
        
        public override Articy.Unity.Interfaces.ScriptDataProxy getProp(string aProperty)
        {
            if ((aProperty == "DisplayName"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(DisplayName);
            }
            if ((aProperty == "Color"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(Color);
            }
            if ((aProperty == "Text"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(Text);
            }
            if ((aProperty == "ExternalId"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(ExternalId);
            }
            if ((aProperty == "Position"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(Position);
            }
            if ((aProperty == "ZIndex"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(ZIndex);
            }
            if ((aProperty == "Size"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(Size);
            }
            if ((aProperty == "PreviewImage"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(PreviewImage);
            }
            if ((aProperty == "ShortId"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(ShortId);
            }
            if ((aProperty == "Visibility"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(Visibility);
            }
            if ((aProperty == "ShowDisplayName"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(ShowDisplayName);
            }
            if ((aProperty == "DisplayNameColor"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(DisplayNameColor);
            }
            if ((aProperty == "DisplayNameSize"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(DisplayNameSize);
            }
            if ((aProperty == "OutlineColor"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(OutlineColor);
            }
            if ((aProperty == "OutlineSize"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(OutlineSize);
            }
            if ((aProperty == "OutlineStyle"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(OutlineStyle);
            }
            if ((aProperty == "DropShadow"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(DropShadow);
            }
            if ((aProperty == "Selectability"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(Selectability);
            }
            return base.getProp(aProperty);
        }
        #endregion
    }
}
