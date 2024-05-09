using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace MenuInv_namespace
{
    public class ChangeManager : MonoBehaviour
    {
        MenuInventario menInv;
        StatsManager statMan;

        VisualElement PlusVig;
        VisualElement LessVig;

        VisualElement PlusInt;
        VisualElement LessInt;

        VisualElement PlusRes;
        VisualElement LessRes;

        VisualElement PlusFue;
        VisualElement LessFue;

        VisualElement PlusDes;
        VisualElement LessDes;

        VisualElement PlusSue;
        VisualElement LessSue;

        void OnEnable()
        {
            menInv = GetComponent<MenuInventario>();
            statMan = GetComponent<StatsManager>();

            VisualElement rootve = GetComponent<UIDocument>().rootVisualElement;
            PlusVig = rootve.Q<Button>("PlusVig");
            LessVig = rootve.Q<Button>("LessVig");
            PlusInt = rootve.Q<Button>("PlusInt");
            LessInt = rootve.Q<Button>("LessInt");
            PlusRes = rootve.Q<Button>("PlusRes");
            LessRes = rootve.Q<Button>("LessRes");
            PlusFue = rootve.Q<Button>("PlusFue");
            LessFue = rootve.Q<Button>("LessFue");
            PlusDes = rootve.Q<Button>("PlusDes");
            LessDes = rootve.Q<Button>("LessDes");
            PlusSue = rootve.Q<Button>("PlusSue");
            LessSue = rootve.Q<Button>("LessSue");
            InnitButtons();
        }

        private void InnitButtons()
        {
            PlusVig.RegisterCallback<ClickEvent>(Add1Vig);
            LessVig.RegisterCallback<ClickEvent>(Less1Vig);
            PlusInt.RegisterCallback<ClickEvent>(Add1Int);
            LessInt.RegisterCallback<ClickEvent>(Less1Int);
            PlusRes.RegisterCallback<ClickEvent>(Add1Res);
            LessRes.RegisterCallback<ClickEvent>(Less1Res);
            PlusFue.RegisterCallback<ClickEvent>(Add1Fue);
            LessFue.RegisterCallback<ClickEvent>(Less1Fue);
            PlusDes.RegisterCallback<ClickEvent>(Add1Des);
            LessDes.RegisterCallback<ClickEvent>(Less1Des);
            PlusSue.RegisterCallback<ClickEvent>(Add1Sue);
            LessSue.RegisterCallback<ClickEvent>(Less1Sue);
        }
        void Add1Vig(ClickEvent ev)
        {
            if(statMan._extra > 0)
            {
                statMan._vigor++;
                statMan._extra--;

                statMan.Actualize();
            }
        }
        void Less1Vig(ClickEvent ev)
        {
            if (statMan._vigor > 0)
            {
                statMan._vigor--;
                statMan._extra++;

                statMan.Actualize();
            }
        }
        void Add1Int(ClickEvent ev)
        {
            if (statMan._extra > 0)
            {
                statMan._inteligencia++;
                statMan._extra--;

                statMan.Actualize();
            }
        }
        void Less1Int(ClickEvent ev)
        {
            if (statMan._inteligencia > 0)
            {
                statMan._inteligencia--;
                statMan._extra++;

                statMan.Actualize();
            }
        }
        void Add1Res(ClickEvent ev)
        {
            if (statMan._extra > 0)
            {
                statMan._resistencia++;
                statMan._extra--;

                statMan.Actualize();
            }
        }
        void Less1Res(ClickEvent ev)
        {
            if (statMan._resistencia > 0)
            {
                statMan._resistencia--;
                statMan._extra++;

                statMan.Actualize();
            }
        }
        void Add1Fue(ClickEvent ev)
        {
            if (statMan._extra > 0)
            {
                statMan._fuerza++;
                statMan._extra--;

                statMan.Actualize();
            }
        }
        void Less1Fue(ClickEvent ev)
        {
            if (statMan._fuerza > 0)
            {
                statMan._fuerza--;
                statMan._extra++;

                statMan.Actualize();
            }
        }
        void Add1Des(ClickEvent ev)
        {
            if (statMan._extra > 0)
            {
                statMan._destreza++;
                statMan._extra--;

                statMan.Actualize();
            }
        }
        void Less1Des(ClickEvent ev)
        {
            if (statMan._destreza > 0)
            {
                statMan._destreza--;
                statMan._extra++;

                statMan.Actualize();
            }
        }
        void Add1Sue(ClickEvent ev)
        {
            if (statMan._extra > 0)
            {
                statMan._suerte++;
                statMan._extra--;

                statMan.Actualize();
            }
        }
        void Less1Sue(ClickEvent ev)
        {
            if (statMan._suerte > 0)
            {
                statMan._suerte--;
                statMan._extra++;

                statMan.Actualize();
            }
        }
        public void ChangeObjeto(EspacioInv v)
        {
            if(v.Objeto ==1 || v.Objeto == 2|| v.Objeto == 3)
            {
                //espada
                int obj = menInv.ChangeManDer(v.Objeto);
                v.Objeto = obj;
                if (obj == -1) menInv.ultimoSlots--;
            }
            else
            {
                if (v.Objeto == 4 || v.Objeto == 5)
                {
                    //armadura
                    int obj = menInv.ChangeTorso(v.Objeto);
                    v.Objeto = obj;
                    if (obj == -1) menInv.ultimoSlots--;
                }
                else
                {
                    if (v.Objeto == 6 || v.Objeto == 7)
                    {
                        //botas
                        int obj = menInv.ChangeBoots(v.Objeto);
                        v.Objeto = obj;
                        if (obj == -1) menInv.ultimoSlots--;
                    }
                    else
                    {
                        if (v.Objeto == 8 || v.Objeto == 9)
                        {
                            //casco
                            int obj = menInv.ChangeCasco(v.Objeto);
                            v.Objeto = obj;
                            if (obj == -1) menInv.ultimoSlots--;
                        }
                        else
                        {
                            if (v.Objeto == 10 || v.Objeto == 11)
                            {
                                //escudo
                                int obj = menInv.ChangeManIz(v.Objeto);
                                v.Objeto = obj;
                                if (obj == -1) menInv.ultimoSlots--;
                            }
                            else
                            {
                                if (v.Objeto == 12 || v.Objeto == 0)
                                {
                                    //pantalones
                                    int obj = menInv.ChangePant(v.Objeto);
                                    v.Objeto = obj;
                                    if (obj == -1) menInv.ultimoSlots--;
                                }
                            }
                        }
                    }
                }
            }
            statMan.Actualize();
        }
    }
}