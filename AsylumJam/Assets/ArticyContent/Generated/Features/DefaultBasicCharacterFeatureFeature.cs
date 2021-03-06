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
    public class DefaultBasicCharacterFeatureFeature : IArticyBaseObject, IPropertyProvider
    {
        
        [SerializeField()]
        private Single mAge;
        
        [SerializeField()]
        private String mSpecies;
        
        [SerializeField()]
        private String mBornIn;
        
        [SerializeField()]
        private Sex mSex = new Sex();
        
        [SerializeField()]
        private String mOccupation;
        
        [SerializeField()]
        private String mAccent;
        
        [SerializeField()]
        private String mPersonality;
        
        [SerializeField()]
        private String mAppearance;
        
        [SerializeField()]
        private ArticyValueArticyModelList mInventory = new ArticyValueArticyModelList();
        
        public Single Age
        {
            get
            {
                return mAge;
            }
            set
            {
                mAge = value;
            }
        }
        
        public String Species
        {
            get
            {
                return mSpecies;
            }
            set
            {
                mSpecies = value;
            }
        }
        
        public String BornIn
        {
            get
            {
                return mBornIn;
            }
            set
            {
                mBornIn = value;
            }
        }
        
        public Sex Sex
        {
            get
            {
                return mSex;
            }
            set
            {
                mSex = value;
            }
        }
        
        public String Occupation
        {
            get
            {
                return mOccupation;
            }
            set
            {
                mOccupation = value;
            }
        }
        
        public String Accent
        {
            get
            {
                return mAccent;
            }
            set
            {
                mAccent = value;
            }
        }
        
        public String Personality
        {
            get
            {
                return mPersonality;
            }
            set
            {
                mPersonality = value;
            }
        }
        
        public String Appearance
        {
            get
            {
                return mAppearance;
            }
            set
            {
                mAppearance = value;
            }
        }
        
        public List<ArticyObject> Inventory
        {
            get
            {
                return mInventory.GetValue();
            }
            set
            {
                mInventory.SetValue(value);
            }
        }
        
        private void CloneProperties(object aClone)
        {
            Articy.Asylumjame.Features.DefaultBasicCharacterFeatureFeature newClone = ((Articy.Asylumjame.Features.DefaultBasicCharacterFeatureFeature)(aClone));
            newClone.Age = Age;
            newClone.Species = Species;
            newClone.BornIn = BornIn;
            newClone.Sex = Sex;
            newClone.Occupation = Occupation;
            newClone.Accent = Accent;
            newClone.Personality = Personality;
            newClone.Appearance = Appearance;
            mInventory.CustomClone(newClone.mInventory);
        }
        
        public object CloneObject()
        {
            Articy.Asylumjame.Features.DefaultBasicCharacterFeatureFeature clone = new Articy.Asylumjame.Features.DefaultBasicCharacterFeatureFeature();
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
            if ((aProperty == "Age"))
            {
                Age = System.Convert.ToSingle(aValue);
                return;
            }
            if ((aProperty == "Species"))
            {
                Species = System.Convert.ToString(aValue);
                return;
            }
            if ((aProperty == "BornIn"))
            {
                BornIn = System.Convert.ToString(aValue);
                return;
            }
            if ((aProperty == "Sex"))
            {
                Sex = ((Sex)(aValue));
                return;
            }
            if ((aProperty == "Occupation"))
            {
                Occupation = System.Convert.ToString(aValue);
                return;
            }
            if ((aProperty == "Accent"))
            {
                Accent = System.Convert.ToString(aValue);
                return;
            }
            if ((aProperty == "Personality"))
            {
                Personality = System.Convert.ToString(aValue);
                return;
            }
            if ((aProperty == "Appearance"))
            {
                Appearance = System.Convert.ToString(aValue);
                return;
            }
            if ((aProperty == "Inventory"))
            {
                Inventory = ((List<ArticyObject>)(aValue));
                return;
            }
        }
        
        public Articy.Unity.Interfaces.ScriptDataProxy getProp(string aProperty)
        {
            if ((aProperty == "Age"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(Age);
            }
            if ((aProperty == "Species"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(Species);
            }
            if ((aProperty == "BornIn"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(BornIn);
            }
            if ((aProperty == "Sex"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(Sex);
            }
            if ((aProperty == "Occupation"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(Occupation);
            }
            if ((aProperty == "Accent"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(Accent);
            }
            if ((aProperty == "Personality"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(Personality);
            }
            if ((aProperty == "Appearance"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(Appearance);
            }
            if ((aProperty == "Inventory"))
            {
                return new Articy.Unity.Interfaces.ScriptDataProxy(Inventory);
            }
            return null;
        }
        #endregion
    }
}
