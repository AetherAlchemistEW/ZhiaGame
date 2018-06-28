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
using Articy.Unity.Interfaces;
using Articy.Unity;
using Articy.Asylumjame;

namespace Articy.Asylumjame.Features
{
    
    
    [Serializable()]
    public class ChapterFeaturesFeature : IArticyBaseObject, IPropertyProvider
    {
        
        [SerializeField()]
        private ArticyValueArticyObject mChapterImage = new ArticyValueArticyObject();
        
        public ArticyObject ChapterImage
        {
            get
            {
                return mChapterImage.GetValue();
            }
            set
            {
                mChapterImage.SetValue(value);
            }
        }
        
        private void CloneProperties(object aClone)
        {
            Articy.Asylumjame.Features.ChapterFeaturesFeature newClone = ((Articy.Asylumjame.Features.ChapterFeaturesFeature)(aClone));
            if ((mChapterImage != null))
            {
                newClone.mChapterImage = ((ArticyValueArticyObject)(mChapterImage.CloneObject()));
            }
        }
        
        public object CloneObject()
        {
            Articy.Asylumjame.Features.ChapterFeaturesFeature clone = new Articy.Asylumjame.Features.ChapterFeaturesFeature();
            CloneProperties(clone);
            return clone;
        }
        
        public virtual bool IsLocalizedPropertyOverwritten(string aProperty)
        {
            return false;
        }
        
        #region property provider interface
        public void setProp(string aProperty, object aValue)
        {
            if ((aProperty == "ChapterImage"))
            {
                ChapterImage = ((ArticyObject)(aValue));
                return;
            }
        }
        
        public Articy.Unity.Interfaces.ScriptDataProxy getProp(string aProperty)
        {
            if ((aProperty == "ChapterImage"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(ChapterImage);
            }
            return null;
        }
        #endregion
    }
}
