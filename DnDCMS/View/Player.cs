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
using DnDCMSLibrary.Interfaces;



namespace DnDCMS.View
{
    public partial class Player : Form
    {
        /* ViewModels */
        SpellViewModel SpellviewModel = new SpellViewModel();
        CharacterViewModel CharacterviewModel = new CharacterViewModel();
        AbilityScoreViewModel AbilityScoreviewModel = new AbilityScoreViewModel();
        SkillViewModel SkillviewModel = new SkillViewModel();
        ClassViewModel ClassviewModel = new ClassViewModel();

        /* Logics */
        SpellLogic spell = new SpellLogic(new SpellContext());
        CharacterLogic character = new CharacterLogic(new CharacterContext());
        AbilityScoreLogic abilityscore = new AbilityScoreLogic(new AbilityScoreContext());
        SkillLogic skill = new SkillLogic(new SkillContext());
        ClassLogic classs = new ClassLogic(new ClassContext());

        public Player()
        {
            InitializeComponent();
            CharacterviewModel.Characters = character.GetCharacter();
            cbPCCharacterName.Items.AddRange(CharacterviewModel.Characters.ToArray());
        }
        /* CharacterSheet */
        private void cbPCCharacterName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCharacterInfoFields();
            SetAbilityScores();
            SetSpeedPerRace();
            SetSkills();
            SetLevel();
            tbPCProficiencyBonus.Text = Proficiency().ToString();
            SkillProficiency();
            SetSavingThrow();
            ArmorClass();
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

        public void SetCharacterInfoFields()
        {
            if (cbPCCharacterName.SelectedItem != null)
            {
                CharacterviewModel.SelectedCharacter = CharacterviewModel.Characters.Find(x => x.name.Contains(cbPCCharacterName.Text));
            }
            cbPCRace.Text = CharacterviewModel.SelectedCharacter.race;
            cbPCSubrace.Text = CharacterviewModel.SelectedCharacter.subrace;
            cbPCAlignment.Text = CharacterviewModel.SelectedCharacter.alignment;
            cbPCBackground.Text = CharacterviewModel.SelectedCharacter.background;
            tbPCHairColor.Text = CharacterviewModel.SelectedCharacter.haircolor;
            tbPCEyeColor.Text = CharacterviewModel.SelectedCharacter.eyecolor;
            tbPCSkinColor.Text = CharacterviewModel.SelectedCharacter.skincolor;
            cbPCGender.Text = CharacterviewModel.SelectedCharacter.gender;
            tbPCHeight.Text = CharacterviewModel.SelectedCharacter.height;
            tbPCWeight.Text = CharacterviewModel.SelectedCharacter.weight;
            nudPCAge.Value = CharacterviewModel.SelectedCharacter.age;
            nudPCExp.Value = CharacterviewModel.SelectedCharacter.experience;
            nudPCHP.Value = CharacterviewModel.SelectedCharacter.currenthp;
            nudPCHPMax.Value = CharacterviewModel.SelectedCharacter.maxhp;
            cbPCGender.Text = CharacterviewModel.SelectedCharacter.gender;


        }
        public void SetAbilityScores()
        {
            if (cbPCCharacterName.SelectedItem != null)
            {
                AbilityScoreviewModel.AbilityScores = abilityscore.GetAbilityScores(CharacterviewModel.SelectedCharacter.id);
                AbilityScoreviewModel.SelectedAbilityScore = AbilityScoreviewModel.AbilityScores[0];
            }
            nudPCStrength.Value = AbilityScoreviewModel.SelectedAbilityScore.strength;
            nudPCDexterity.Value = AbilityScoreviewModel.SelectedAbilityScore.dexterity;
            nudPCConstitution.Value = AbilityScoreviewModel.SelectedAbilityScore.constitution;
            nudPCIntelligence.Value = AbilityScoreviewModel.SelectedAbilityScore.intelligence;
            nudPCWisdom.Value = AbilityScoreviewModel.SelectedAbilityScore.wisdom;
            nudPCCharisma.Value = AbilityScoreviewModel.SelectedAbilityScore.charisma;
            tbPCStrengthMod.Text = StrengthModifier(nudPCStrength.Value).ToString();
            tbPCDexterityMod.Text = DexModifier(nudPCDexterity.Value).ToString();
            tbPCConstitutionMod.Text = ConModifier(nudPCConstitution.Value).ToString();
            tbPCIntelligenceMod.Text = IntModifier(nudPCIntelligence.Value).ToString();
            tbPCWisdomMod.Text = WisModifier(nudPCWisdom.Value).ToString();
            tbPCCharismaMod.Text = ChaModifier(nudPCCharisma.Value).ToString();
        }
        public void SetSpeedPerRace()
        {
            if (CharacterviewModel.SelectedCharacter.subrace == "Wood Elf")
            {
                nudPCSpeed.Value = 35;
            }
            else if (CharacterviewModel.SelectedCharacter.race == "Dwarf" || CharacterviewModel.SelectedCharacter.race == "Halfing" || CharacterviewModel.SelectedCharacter.race == "Gnome")
            {
                nudPCSpeed.Value = 25;
            }
            else
            {
                nudPCSpeed.Value = 30;

            }
        }
        public void SetSkills()
        {
            if (cbPCCharacterName.SelectedItem != null)
            {
                SkillviewModel.Skills = skill.GetSkills(CharacterviewModel.SelectedCharacter.id);
                SkillviewModel.SelectedSkill = SkillviewModel.Skills[0];
            }
            chbPCAcrobatics.Checked = SkillviewModel.SelectedSkill.acrobatics;
            chbPCAnimalHandling.Checked = SkillviewModel.SelectedSkill.animalhandling;
            chbPCArcana.Checked = SkillviewModel.SelectedSkill.arcana;
            chbPCAthletics.Checked = SkillviewModel.SelectedSkill.athletics;
            chbPCDeception.Checked = SkillviewModel.SelectedSkill.deception;
            chbPCHistory.Checked = SkillviewModel.SelectedSkill.history;
            chbPCInsight.Checked = SkillviewModel.SelectedSkill.insight;
            chbPCIntimidation.Checked = SkillviewModel.SelectedSkill.intimidation;
            chbPCInvestigation.Checked = SkillviewModel.SelectedSkill.investigation;
            chbPCMedicine.Checked = SkillviewModel.SelectedSkill.medicine;
            chbPCNature.Checked = SkillviewModel.SelectedSkill.nature;
            chbPCPerception.Checked = SkillviewModel.SelectedSkill.perception;
            chbPCPerformance.Checked = SkillviewModel.SelectedSkill.performance;
            chbPCPersuasion.Checked = SkillviewModel.SelectedSkill.persuasion;
            chbPCReligion.Checked = SkillviewModel.SelectedSkill.religion;
            chbPCSlightOfHand.Checked = SkillviewModel.SelectedSkill.sleightofhand;
            chbPCStealth.Checked = SkillviewModel.SelectedSkill.stealth;
            chbPCSurvival.Checked = SkillviewModel.SelectedSkill.survival;
        }

        public void SetLevel()
        {
            if (cbPCCharacterName.SelectedItem != null)
            {
                ClassviewModel.Class = classs.GetClass(CharacterviewModel.SelectedCharacter.id);
                ClassviewModel.SelectedClass = ClassviewModel.Class[0];
            }
            nudPCBarbarian.Value = ClassviewModel.SelectedClass.Barbarian;
            nudPCBard.Value = ClassviewModel.SelectedClass.Bard;
            nudPCCleric.Value = ClassviewModel.SelectedClass.Cleric;
            nudPCDruid.Value = ClassviewModel.SelectedClass.Druid;
            nudPCFighter.Value = ClassviewModel.SelectedClass.Fighter;
            nudPCMonk.Value = ClassviewModel.SelectedClass.Monk;
            nudPCPaladin.Value = ClassviewModel.SelectedClass.Paladin;
            nudPCRanger.Value = ClassviewModel.SelectedClass.Ranger;
            nudPCRogue.Value = ClassviewModel.SelectedClass.Rogue;
            nudPCSorcerer.Value = ClassviewModel.SelectedClass.Sorcerer;
            nudPCWarlock.Value = ClassviewModel.SelectedClass.Warlock;
            nudPCWizard.Value = ClassviewModel.SelectedClass.Wizard;
            tbPCLevel.Text = Totallevel().ToString();
        }
        public int Totallevel()
        {
            int totallevel = ClassviewModel.SelectedClass.Barbarian + ClassviewModel.SelectedClass.Bard + ClassviewModel.SelectedClass.Cleric + ClassviewModel.SelectedClass.Druid + ClassviewModel.SelectedClass.Fighter + ClassviewModel.SelectedClass.Monk + ClassviewModel.SelectedClass.Paladin + ClassviewModel.SelectedClass.Ranger + ClassviewModel.SelectedClass.Rogue + ClassviewModel.SelectedClass.Sorcerer + ClassviewModel.SelectedClass.Warlock + ClassviewModel.SelectedClass.Wizard;
            return totallevel;
        }
        public int Proficiency()
        {
            int proficiency = 0;
            int totallevel = Totallevel();
            if (totallevel < 5)
            {
                proficiency = 2;
            }
            else if (totallevel >= 5 && totallevel < 9)
            {
                proficiency = 3;
            }
            else if (totallevel >= 9 && totallevel < 13)
            {
                proficiency = 4;
            }
            else if (totallevel >= 13 && totallevel < 17)
            {
                proficiency = 5;
            }
            else if (totallevel >= 17 && totallevel < 21)
            {
                proficiency = 6;
            }
            return proficiency;
        }
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
        public decimal StrengthModifier(decimal strength)
        {
            decimal strengthmod;

            strengthmod = strength / 2 - 5;
            strengthmod = Math.Floor(strengthmod);

            return strengthmod;

        }
        public decimal DexModifier(decimal dex)
        {
            decimal dexmod;

            dexmod = dex / 2 - 5;
            dexmod = Math.Floor(dexmod);

            return dexmod;

        }
        public decimal ConModifier(decimal con)
        {
            decimal conmod;

            conmod = con / 2 - 5;
            conmod = Math.Floor(conmod);

            return conmod;

        }
        public decimal IntModifier(decimal intelligence)
        {
            decimal intmod;

            intmod = intelligence / 2 - 5;
            intmod = Math.Floor(intmod);

            return intmod;

        }
        public decimal WisModifier(decimal wis)
        {
            decimal wismod;

            wismod = wis / 2 - 5;
            wismod = Math.Floor(wismod);

            return wismod;

        }
        public decimal ChaModifier(decimal cha)
        {
            decimal chamod;

            chamod = cha / 2 - 5;
            chamod = Math.Floor(chamod);

            return chamod;

        }
        public void SkillProficiency()
        {
            int acrobatics;
            int animalhandling;
            int arcana;
            int athletics;
            int deception;
            int history;
            int insight;
            int intimidation;
            int investigation;
            int medicine;
            int nature;
            int perception;
            int performance;
            int persuasion;
            int religion;
            int sleightofhand;
            int stealth;
            int survival;
            int passiveperception;

            if (tbPCProficiencyBonus.Text != "")
            {
                if (chbPCAcrobatics.Checked)
                {
                    acrobatics = Convert.ToInt32(tbPCDexterityMod.Text) + Convert.ToInt32(tbPCProficiencyBonus.Text);
                    tbPCAcrobatics.Text = acrobatics.ToString();

                }
                else
                {
                    tbPCAcrobatics.Text = tbPCDexterityMod.Text;
                }
                if (chbPCAnimalHandling.Checked)
                {
                    animalhandling = Convert.ToInt32(tbPCWisdomMod.Text) + Convert.ToInt32(tbPCProficiencyBonus.Text);
                    tbPCAnimalHandling.Text = animalhandling.ToString();
                }
                else
                {
                    tbPCAnimalHandling.Text = tbPCWisdomMod.Text;
                }
                if (chbPCArcana.Checked)
                {
                    arcana = Convert.ToInt32(tbPCIntelligenceMod.Text) + Convert.ToInt32(tbPCProficiencyBonus.Text);
                    tbPCArcana.Text = arcana.ToString();
                }
                else
                {
                    tbPCArcana.Text = tbPCIntelligenceMod.Text;
                }
                if (chbPCAthletics.Checked)
                {
                    athletics = Convert.ToInt32(tbPCStrengthMod.Text) + Convert.ToInt32(tbPCProficiencyBonus.Text);
                    tbPCAthletics.Text = athletics.ToString();
                }
                else
                {
                    tbPCAthletics.Text = tbPCStrengthMod.Text;
                }
                if (chbPCDeception.Checked)
                {
                    deception = Convert.ToInt32(tbPCCharismaMod.Text) + Convert.ToInt32(tbPCProficiencyBonus.Text);
                    tbPCDeception.Text = deception.ToString();
                }
                else
                {
                    tbPCDeception.Text = tbPCCharismaMod.Text;
                }
                if (chbPCHistory.Checked)
                {
                    history = Convert.ToInt32(tbPCIntelligenceMod.Text) + Convert.ToInt32(tbPCProficiencyBonus.Text);
                    tbPCHistory.Text = history.ToString();
                }
                else
                {
                    tbPCHistory.Text = tbPCIntelligenceMod.Text;
                }
                if (chbPCInsight.Checked)
                {
                    insight = Convert.ToInt32(tbPCWisdomMod.Text) + Convert.ToInt32(tbPCProficiencyBonus.Text);
                    tbPCInsight.Text = insight.ToString();
                }
                else
                {
                    tbPCInsight.Text = tbPCWisdomMod.Text;
                }
                if (chbPCIntimidation.Checked)
                {
                    intimidation = Convert.ToInt32(tbPCCharismaMod.Text) + Convert.ToInt32(tbPCProficiencyBonus.Text);
                    tbPCIntimidation.Text = intimidation.ToString();
                }
                else
                {
                    tbPCIntimidation.Text = tbPCCharismaMod.Text;
                }
                if (chbPCInvestigation.Checked)
                {
                    investigation = Convert.ToInt32(tbPCIntelligenceMod.Text) + Convert.ToInt32(tbPCProficiencyBonus.Text);
                    tbPCInvestigation.Text = investigation.ToString();
                }
                else
                {
                    tbPCInvestigation.Text = tbPCIntelligenceMod.Text;
                }
                if (chbPCMedicine.Checked)
                {
                    medicine = Convert.ToInt32(tbPCWisdomMod.Text) + Convert.ToInt32(tbPCProficiencyBonus.Text);
                    tbPCMedicine.Text = medicine.ToString();
                }
                else
                {
                    tbPCMedicine.Text = tbPCWisdomMod.Text;
                }
                if (chbPCNature.Checked)
                {
                    nature = Convert.ToInt32(tbPCIntelligenceMod.Text) + Convert.ToInt32(tbPCProficiencyBonus.Text);
                    tbPCNature.Text = nature.ToString();
                }
                else
                {
                    tbPCNature.Text = tbPCIntelligenceMod.Text;
                }
                if (chbPCPerception.Checked)
                {
                    perception = Convert.ToInt32(tbPCWisdomMod.Text) + Convert.ToInt32(tbPCProficiencyBonus.Text);
                    tbPCPerception.Text = perception.ToString();
                }
                else
                {
                    tbPCPerception.Text = tbPCWisdomMod.Text;
                }
                if (chbPCPerformance.Checked)
                {
                    performance = Convert.ToInt32(tbPCCharismaMod.Text) + Convert.ToInt32(tbPCProficiencyBonus.Text);
                    tbPCPerformance.Text = performance.ToString();
                }
                else
                {
                    tbPCPerformance.Text = tbPCCharismaMod.Text;
                }
                if (chbPCPersuasion.Checked)
                {
                    persuasion = Convert.ToInt32(tbPCCharismaMod.Text) + Convert.ToInt32(tbPCProficiencyBonus.Text);
                    tbPCPersuasion.Text = persuasion.ToString();
                }
                else
                {
                    tbPCPersuasion.Text = tbPCCharismaMod.Text;
                }
                if (chbPCReligion.Checked)
                {
                    religion = Convert.ToInt32(tbPCIntelligenceMod.Text) + Convert.ToInt32(tbPCProficiencyBonus.Text);
                    tbPCReligion.Text = religion.ToString();
                }
                else
                {
                    tbPCReligion.Text = tbPCIntelligenceMod.Text;
                }
                if (chbPCSlightOfHand.Checked)
                {
                    sleightofhand = Convert.ToInt32(tbPCDexterityMod.Text) + Convert.ToInt32(tbPCProficiencyBonus.Text);
                    tbPCSlightOfHand.Text = sleightofhand.ToString();
                }
                else
                {
                    tbPCSlightOfHand.Text = tbPCDexterityMod.Text;
                }
                if (chbPCStealth.Checked)
                {
                    stealth = Convert.ToInt32(tbPCDexterityMod.Text) + Convert.ToInt32(tbPCProficiencyBonus.Text);
                    tbPCStealth.Text = stealth.ToString();
                }
                else
                {
                    tbPCStealth.Text = tbPCDexterityMod.Text;
                }
                if (chbPCSurvival.Checked)
                {
                    survival = Convert.ToInt32(tbPCWisdomMod.Text) + Convert.ToInt32(tbPCProficiencyBonus.Text);
                    tbPCSurvival.Text = survival.ToString();
                }
                else
                {
                    tbPCSurvival.Text = tbPCWisdomMod.Text;
                }

                passiveperception = 10 + Convert.ToInt32(tbPCPerception.Text);
                tbPCPassivePerception.Text = Convert.ToString(passiveperception);
            }
        }
        public void SetSavingThrow()
        {
            int strengthsave;
            int dexteritysave;
            int constitutionsave;
            int intelligencesave;
            int wisdomsave;
            int charismasave;

            if (nudPCBarbarian.Value >= 1)
            {
                chbPCStrengthSave.Checked = true;
                chbPCConstitutionSave.Checked = true;
            }
            else if (nudPCBard.Value >= 1)
            {
                chbPCDexteritySave.Checked = true;
                chbPCCharismaSave.Checked = true;
            }
            else if (nudPCCleric.Value >= 1)
            {
                chbPCWisdomSave.Checked = true;
                chbPCCharismaSave.Checked = true;
            }
            else if (nudPCDruid.Value >= 1)
            {
                chbPCIntelligenceSave.Checked = true;
                chbPCWisdomSave.Checked = true;
            }
            else if (nudPCFighter.Value >= 1)
            {
                chbPCStrengthSave.Checked = true;
                chbPCConstitutionSave.Checked = true;
            }
            else if (nudPCMonk.Value >= 1)
            {
                chbPCStrengthSave.Checked = true;
                chbPCDexteritySave.Checked = true;
            }
            else if (nudPCPaladin.Value >= 1)
            {
                chbPCWisdomSave.Checked = true;
                chbPCCharismaSave.Checked = true;
            }
            else if (nudPCRanger.Value >= 1)
            {
                chbPCStrengthSave.Checked = true;
                chbPCDexteritySave.Checked = true;
            }
            else if (nudPCRogue.Value >= 1)
            {
                chbPCDexteritySave.Checked = true;
                chbPCIntelligenceSave.Checked = true;
            }
            else if (nudPCSorcerer.Value >= 1)
            {
                chbPCConstitutionSave.Checked = true;
                chbPCCharismaSave.Checked = true;
            }
            else if (nudPCWarlock.Value >= 1)
            {
                chbPCWisdomSave.Checked = true;
                chbPCCharismaSave.Checked = true;
            }
            else if (nudPCWizard.Value >= 1)
            {
                chbPCIntelligenceSave.Checked = true;
                chbPCWisdomSave.Checked = true;
            }
            if (tbPCProficiencyBonus.Text != "")
            {
                if (chbPCStrengthSave.Checked)
                {
                    strengthsave = Convert.ToInt32(tbPCStrengthMod.Text) + Convert.ToInt32(tbPCProficiencyBonus.Text);
                    tbPCStrengthSave.Text = strengthsave.ToString();
                }
                else
                {
                    tbPCStrengthSave.Text = tbPCStrengthMod.Text;
                }
                if (chbPCDexteritySave.Checked)
                {
                    dexteritysave = Convert.ToInt32(tbPCDexterityMod.Text) + Convert.ToInt32(tbPCProficiencyBonus.Text);
                    tbPCDexteritySave.Text = dexteritysave.ToString();
                }
                else
                {
                    tbPCDexteritySave.Text = tbPCDexterityMod.Text;
                }
                if (chbPCConstitutionSave.Checked)
                {
                    constitutionsave = Convert.ToInt32(tbPCConstitutionMod.Text) + Convert.ToInt32(tbPCProficiencyBonus.Text);
                    tbPCConstitutionSave.Text = constitutionsave.ToString();
                }
                else
                {
                    tbPCConstitutionSave.Text = tbPCConstitutionMod.Text;
                }
                if (chbPCIntelligenceSave.Checked)
                {
                    intelligencesave = Convert.ToInt32(tbPCIntelligenceMod.Text) + Convert.ToInt32(tbPCProficiencyBonus.Text);
                    tbPCIntelligenceSave.Text = intelligencesave.ToString();
                }
                else
                {
                    tbPCIntelligenceSave.Text = tbPCIntelligenceMod.Text;
                }
                if (chbPCWisdomSave.Checked)
                {
                    wisdomsave = Convert.ToInt32(tbPCWisdomMod.Text) + Convert.ToInt32(tbPCProficiencyBonus.Text);
                    tbPCWisdomSave.Text = wisdomsave.ToString();
                }
                else
                {
                    tbPCWisdomSave.Text = tbPCWisdomMod.Text;
                }
                if (chbPCCharismaSave.Checked)
                {
                    charismasave = Convert.ToInt32(tbPCCharismaMod.Text) + Convert.ToInt32(tbPCProficiencyBonus.Text);
                    tbPCCharismaSave.Text = charismasave.ToString();
                }
                else
                {
                    tbPCCharismaSave.Text = tbPCCharismaMod.Text;
                }
            }
        }
        public void ArmorClass()
        {
            int armorclass = 10;
            armorclass = armorclass + Convert.ToInt32(tbPCDexterityMod.Text);
            tbPCArmorClass.Text = armorclass.ToString();
        }
    }
}
