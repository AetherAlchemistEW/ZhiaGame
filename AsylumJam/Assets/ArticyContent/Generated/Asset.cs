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
    
    
    public class Asset : ArticyObject, IAsset, IPropertyProvider, IObjectWithColor, IObjectWithDisplayName, IObjectWithPreviewImage, IObjectWithText, IObjectWithExternalId, IObjectWithShortId, IObjectWithPosition, IObjectWithZIndex, IObjectWithSize
    {
        
        [SerializeField()]
        private String mDisplayName;
        
        [SerializeField()]
        private String mFilename;
        
        [SerializeField()]
        private String mOriginalSource;
        
        [SerializeField()]
        private PreviewImage mPreviewImage = new PreviewImage();
        
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
        private UInt32 mShortId;
        
        [SerializeField()]
        private String mAssetRefPath;
        
        [SerializeField()]
        private UnityEngine.Object mCachedAsset;
        
        [SerializeField()]
        private AssetCategory mCategory;
        
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
        
        public String Filename
        {
            get
            {
                return mFilename;
            }
            set
            {
                mFilename = value;
            }
        }
        
        public String OriginalSource
        {
            get
            {
                return mOriginalSource;
            }
            set
            {
                mOriginalSource = value;
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
        
        public String AssetRefPath
        {
            get
            {
                return mAssetRefPath;
            }
        }
        
        public AssetCategory Category
        {
            get
            {
                return mCategory;
            }
        }
        
        public TAsset LoadAsset<TAsset>()
            where TAsset : UnityEngine.Object
        {
            if ((mCachedAsset == null))
            {
                mCachedAsset = UnityEngine.Resources.Load(mAssetRefPath);
            }
            return ((TAsset)(mCachedAsset));
        }
        
        public UnityEngine.Sprite LoadAssetAsSprite()
        {
            UnityEngine.Sprite assetSprite = UnityEngine.Resources.Load <UnityEngine.Sprite>(mAssetRefPath);
            if ((assetSprite != null))
            {
                return assetSprite;
            }
            else
            {
                UnityEngine.Texture2D assetTexture = LoadAsset <UnityEngine.Texture2D>();
                if ((assetTexture != null))
                {
                    UnityEngine.Rect spriteRect = new UnityEngine.Rect(0, 0, assetTexture.width, assetTexture.height);
                    return UnityEngine.Sprite.Create(assetTexture, spriteRect, UnityEngine.Vector2.zero);
                }
                return null;
            }
        }
        
        public void ReleaseAsset()
        {
            mCachedAsset = null;
        }
        
        protected override void CloneProperties(object aClone)
        {
            Asset newClone = ((Asset)(aClone));
            newClone.DisplayName = DisplayName;
            newClone.Filename = Filename;
            newClone.OriginalSource = OriginalSource;
            newClone.PreviewImage = PreviewImage;
            newClone.Color = Color;
            newClone.Text = Text;
            newClone.ExternalId = ExternalId;
            newClone.Position = Position;
            newClone.ZIndex = ZIndex;
            newClone.Size = Size;
            newClone.ShortId = ShortId;
            newClone.mAssetRefPath = mAssetRefPath;
            newClone.mCategory = mCategory;
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
            if ((aProperty == "Filename"))
            {
                Filename = System.Convert.ToString(aValue);
                return;
            }
            if ((aProperty == "OriginalSource"))
            {
                OriginalSource = System.Convert.ToString(aValue);
                return;
            }
            if ((aProperty == "PreviewImage"))
            {
                PreviewImage = ((PreviewImage)(aValue));
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
            if ((aProperty == "ShortId"))
            {
                ShortId = ((UInt32)(aValue));
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
            if ((aProperty == "Filename"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(Filename);
            }
            if ((aProperty == "OriginalSource"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(OriginalSource);
            }
            if ((aProperty == "PreviewImage"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(PreviewImage);
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
            if ((aProperty == "ShortId"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(ShortId);
            }
            return base.getProp(aProperty);
        }
        #endregion
    }
}
