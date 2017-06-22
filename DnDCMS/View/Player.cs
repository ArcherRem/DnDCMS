using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DnDCMS.ViewModel;
using DnDCMSLibrary.Logic;
using DnDCMSLibrary.Entities;
using DnDCMSLibrary.Repositories;


namespace DnDCMS.View
{
    public partial class Player : Form
    {
        SpellViewModel SpellviewModel = new SpellViewModel();
        SpellLogic spell = new SpellLogic(new SpellContext());
        CharacterViewModel CharacterviewModel = new CharacterViewModel();
        CharacterLogic character = new CharacterLogic(new CharacterContext());

        public Player()
        {
            InitializeComponent();
            CharacterviewModel.Characters = character.GetCharacter();
            cbPCCharacterName.Items.AddRange(CharacterviewModel.Characters.ToArray());
        }
        /* Spellbook */
        private void btnPCSearchSpell_Click(object sender, EventArgs e)
        {
            string query = CreateQuery();
            lbPCSpellList.DataSource = (spell.GetSpell(query));
        }

        private void lbPCSpellList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSpellbookFields();
        }

        /* Methods */
        public void SetSpellbookFields()
        {
            Spell selectedspell = (Spell)lbPCSpellList.SelectedItem;
            tbPCSelectedSpellName.Text = selectedspell.name;
            tbPCSelectedSpellRange.Text = selectedspell.range;
            tbPCSelectedSpellType.Text = selectedspell.type;
            tbPCSelectedSpellLevel.Text = selectedspell.level.ToString();
            tbPCSelectedSpellDuration.Text = selectedspell.duration;
            tbPCSelectedSpellCastingTime.Text = selectedspell.castingtime;
            rtbPCSelectedSpellComponents.Text = selectedspell.components;
            rtbPCSelectedSpellEffect.Text = selectedspell.effect;
        }
        public string CreateQuery()
        {
            string query = "";
            if (tbPCSearchSpellName.Text != "")
            {
                query = "WHERE name LIKE %" + tbPCSearchSpellName.Text + "%";
            }
            if (cbPCSearchSpellClass.Text != "")
            {
                if (query != "")
                {
                    query = query + " AND " + cbPCSearchSpellClass.Text + " = TRUE";
                }
                else
                {
                    query = "WHERE " + cbPCSearchSpellClass.Text + " = TRUE";
                }
            }
            if (cbPCSearchSpellLevel.Text != "")
            {
                if (query != "")
                {
                    query = query + " AND spelllevel = " + "'" + cbPCSearchSpellLevel.Text + "'";
                }
                else
                {
                    query = "WHERE spelllevel = " + "'" + cbPCSearchSpellLevel.Text + "'";
                }
            }
            if (cbPCSearchSpellType.Text != "")
            {
                if (query != "")
                {
                    query = query + " AND spelltype = " + "'" + cbPCSearchSpellType.Text + "'";
                }
                else
                {
                    query = "WHERE spelltype = " + "'" + cbPCSearchSpellType.Text + "'";
                }
            }
            if (chbPCSearchSpellRitual.Checked)
            {
                if (query != "")
                {
                    query = query + " AND ritual = " + chbPCSearchSpellRitual.Checked;
                }
                else
                {
                    query = "WHERE ritual = " + chbPCSearchSpellRitual.Checked;
                }
            }
            return query;
        }
    }
}
