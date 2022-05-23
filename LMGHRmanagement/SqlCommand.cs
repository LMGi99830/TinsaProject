using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMGHRmanagement
{
    internal class SqlCommand
    {
        #region TInsa_Code1
        public const string Tinsa_Code1_Search = @" select *
                            from lmg_tinsa_cdg 
                            where cdg_grpnm like :cdg_grpnm
                            and cdg_use like :cdg_use
                            order by cdg_grpcd";

        //값 Insert
        public const string Tinsa_Code1_Insert = @"
        Insert into LMG_TINSA_CDG
            (CDG_GRPCD,CDG_GRPNM,CDG_DIGIT,CDG_LENGTH,CDG_USE,CDG_KIND)
        values
            (:CDG_GRPCD,:CDG_GRPNM,:CDG_DIGIT,:CDG_LENGTH,:CDG_USE,:CDG_KIND)";

        public const string Tinsa_Code1_Update = @"
        Update LMG_TINSA_CDG
        set CDG_GRPNM = :CDG_GRPNM,CDG_DIGIT = :CDG_DIGIT,CDG_LENGTH = :CDG_LENGTH,
        CDG_USE = :CDG_USE,CDG_KIND = :CDG_KIND
        where CDG_GRPCD = :CDG_GRPCD";
        #endregion

        #region TInsa_Code2
        //검색
        public const string Tinsa_Code2_Search = @" select cdg_grpcd, cdg_grpnm
                            from lmg_tinsa_cdg 
                            where cdg_grpnm like :cdg_grpnm
                            order by cdg_grpcd";

        //코드 조회
        public const string Tinsa_Code2_Main_Search = @"select 'Select' , cd.*
                            from LMG_TINSA_CD cd
                            where cd_grpcd = :cdg_grpcd";

        //값 Insert
        public const string Tinsa_Code2_Insert = @"
        Insert into LMG_TINSA_CD
            (CD_GRPCD,CD_CODE,CD_SEQ,CD_CODNMS,CD_CODNM,CD_ADDINFO,CD_UPPER,CD_USE,CD_SDATE,CD_EDATE,DATASYS1,DATASYS2,DATASYS3)
        values
            (:CD_GRPCD,:CD_CODE,:CD_SEQ,:CD_CODNMS,:CD_CODNM,:CD_ADDINFO,:CD_UPPER,:CD_USE,:CD_SDATE,:CD_EDATE,:DATASYS1,:DATASYS2,:DATASYS3)";

        public const string Tinsa_Code2_Update = @"
        Update LMG_TINSA_CD
        set CD_SEQ = :CD_SEQ,CD_CODNMS = :CD_CODNMS,CD_CODNM = :CD_CODNM,CD_ADDINFO = :CD_ADDINFO,CD_UPPER = :CD_UPPER,
        CD_USE = :CD_USE,CD_SDATE = :CD_SDATE,CD_EDATE = :CD_EDATE,DATASYS1 = :DATASYS1,DATASYS2 = :DATASYS2,DATASYS3 = :DATASYS3
        where CD_GRPCD = :CD_GRPCD AND CD_CODE = :CD_CODE";
        #endregion  

        #region Tinsa_Code3
        public const string Tinsa_Code3_Search = @" select *
                            from lmg_tinsa_dept 
                            where dept_name like :dept_name
                            order by dept_code";

        //값 Insert
        public const string Tinsa_Code3_Insert = @"
        Insert into LMG_TINSA_DEPT
            (DEPT_CODE,DEPT_NAME,DEPT_NAMES,DEPT_SEQ,DEPT_UPP,DEPT_SDATE,DEPT_EDATE,DATASYS1,DATASYS2,DATASYS3)
        values
            (:DEPT_CODE,:DEPT_NAME,:DEPT_NAMES,:DEPT_SEQ,:DEPT_UPP,:DEPT_SDATE,:DEPT_EDATE,:DATASYS1,:DATASYS2,:DATASYS3)";

        // 값 Update
        public const string Tinsa_Code3_Update = @"
                            Update LMG_TINSA_DEPT
                            set DEPT_NAME = :DEPT_NAME,DEPT_NAMES = :DEPT_NAMES,DEPT_SEQ = :DEPT_SEQ,
                            DEPT_UPP = :DEPT_UPP,DEPT_SDATE = :DEPT_SDATE,DEPT_EDATE = :DEPT_EDATE,
                            DATASYS1 = :DATASYS1,DATASYS2 = :DATASYS2,DATASYS3 = :DATASYS3
                            where DEPT_CODE = :DEPT_CODE";
        #endregion

        #region TINSA_BAS1
        public const string Tinsa_BAS1_INSERT = @"
        INSERT INTO LMG_TINSA_BAS 
            (BAS_EMPNO, BAS_RESNO, BAS_NAME, BAS_CNAME,BAS_ENAME, BAS_FIX, BAS_ZIP, BAS_ADDR, BAS_HDPNO, BAS_TELNO, BAS_EMAIL,BAS_MIL_STA, BAS_MIL_MIL, BAS_MIL_RNK, BAS_MAR, BAS_ACC_BANK, BAS_ACC_NAME,BAS_ACC_NO, bas_cont,bas_emp_sdate,bas_emp_edate,bas_entdate,bas_resdate,bas_levdate,bas_reidate,bas_dptdate,bas_jkpdate,bas_posdate,bas_wsta,bas_sts,bas_pos,bas_dut,bas_dept,bas_rmk,DATASYS1, DATASYS2, DATASYS3)
        VALUES 
            (:bas_empno,:bas_resno,:bas_name,:bas_cname,:bas_ename,:bas_fix,:bas_zip,:bas_addr,:bas_hdpno,:bas_telno,:bas_email,:bas_mil_sta,:bas_mil_mil, :bas_mil_rnk,:bas_mar, :bas_acc_bank, :bas_acc_name, :bas_acc_no, :bas_cont,:bas_emp_sdate, :bas_emp_edate,:bas_entdate, :bas_resdate,:bas_levdate,:bas_reidate,:bas_dptdate,:bas_jkpdate,:bas_posdate, :bas_wsta,:bas_sts,:bas_pos,:bas_dut,:bas_dept,:bas_rmk,:datesys1, :datesys2, :datesys3)
        ";

        public const string TInsa_Bas1_ImageInsert = @"
        INSERT INTO LMG_TINSA_IMAGE
            (IMG_EMPNO, IMG_IMAGE)
        values 
            (:IMG_EMPNO, :IMG_IMAGE)";

        public const string TInsa_Bas1_UPDATE = @"
        Update lmg_tinsa_bas
        set
            BAS_EMPNO = :BAS_EMPNO,
            BAS_RESNO = :BAS_RESNO,BAS_NAME = :BAS_NAME,
            BAS_CNAME = :BAS_CNAME,BAS_ENAME = :BAS_ENAME,
            BAS_FIX = :BAS_FIX,BAS_ZIP = :BAS_ZIP,
            BAS_ADDR = :BAS_ADDR,BAS_HDPNO = :BAS_HDPNO,
            BAS_TELNO = :BAS_TELNO,BAS_EMAIL = :BAS_EMAIL,
            BAS_MIL_STA = :BAS_MIL_STA,BAS_MIL_MIL = :BAS_MIL_MIL,
            BAS_MIL_RNK = :BAS_MIL_RNK,BAS_MAR = :BAS_MAR,
            BAS_ACC_BANK = :BAS_ACC_BANK,BAS_ACC_NAME = :BAS_ACC_NAME,
            BAS_ACC_NO = :BAS_ACC_NO,BAS_CONT = :BAS_CONT,
            BAS_EMP_SDATE = :BAS_EMP_SDATE,BAS_EMP_EDATE = :BAS_EMP_EDATE,
            BAS_ENTDATE = :BAS_ENTDATE,BAS_RESDATE = :BAS_RESDATE,
            BAS_LEVDATE = :BAS_LEVDATE,BAS_REIDATE = :BAS_REIDATE,
            BAS_DPTDATE = :BAS_DPTDATE,BAS_JKPDATE = :BAS_JKPDATE,
            BAS_POSDATE = :BAS_POSDATE,BAS_WSTA = :BAS_WSTA,
            BAS_STS = :BAS_STS,BAS_POS = :BAS_POS,
            BAS_DUT = :BAS_DUT,BAS_DEPT = :BAS_DEPT,
            BAS_RMK = :BAS_RMK, DATASYS1 = :DATASYS1, DATASYS2 = :DATASYS2, DATASYS3 = :DATASYS3
        where bas_empno = :bas_empno_cp";
        #endregion

        #region TINSA_BAS2
        //가족사항 조회
        public const string Tinsa_Bas2_Select = @"select *
                            from LMG_TINSA_CD cd
                            inner join LMG_TINSA_FAM fam
                            on cd.CD_CODE = fam.FAM_REL
                            where fam.FAM_EMPNO = :fam_empno
                            and cd.CD_GRPCD = 'FMI'";

        //검색
        public const string Tinsa_Bas2_Search = @" select bas_empno, bas_name
                            from lmg_tinsa_bas 
                            where bas_empno like :bas_empno
                            and bas_name like :bas_name order by bas_empno";

        //값 Insert
        public const string Tinsa_Bas2_Insert = @"
                            Insert into LMG_TINSA_FAM
                                (FAM_REL,FAM_NAME,FAM_BTH,FAM_LTG, FAM_EMPNO, datasys1,datasys2,datasys3)
                            values
                                (:FAM_REL,:FAM_NAME,:FAM_BTH,:FAM_LTG,:FAM_EMPNO,:datesys1,:datesys2,:datesys3)";

        // 값 Update
        public const string Tinsa_Bas2_Update = @"
                            Update LMG_TINSA_FAM
                            set FAM_BTH = :FAM_BTH, FAM_LTG = :FAM_LTG, DATASYS1 = :DATASYS1,
                            DATASYS2 = :DATASYS2,DATASYS3 = :DATASYS3
                            where FAM_EMPNO = :FAM_EMPNO and FAM_REL = :FAM_REL and FAM_NAME = :FAM_NAME";
        #endregion

        #region TINSA_BAS3
        // 조회
        public const string Tinsa_Bas3_Select = @"select *
                            from LMG_TINSA_EDU 
                            where edu_EMPNO = :edu_empno";

        //값 Insert
        public const string Tinsa_Bas3_Insert = @"
                            Insert into LMG_TINSA_EDU
                                (EDU_EMPNO,EDU_LOE,EDU_ENTDATE,EDU_GRADATE,EDU_SCHNM,EDU_DEPT,EDU_DEGREE,EDU_GRADE,EDU_GRA,EDU_LAST,DATASYS1,DATASYS2,DATASYS3)
                            values
                                (:EDU_EMPNO,:EDU_LOE,:EDU_ENTDATE,:EDU_GRADATE,:EDU_SCHNM,:EDU_DEPT,:EDU_DEGREE,:EDU_GRADE,:EDU_GRA,:EDU_LAST,:DATASYS1,:DATASYS2,:DATASYS3)";

        // 값 Update
        public const string Tinsa_Bas3_Update = @"
                            Update LMG_TINSA_edu
                            set EDU_GRADATE = :EDU_GRADATE, EDU_SCHNM = :EDU_SCHNM, EDU_DEPT = :EDU_DEPT,
                            EDU_DEGREE = :EDU_DEGREE, EDU_GRADE = :EDU_GRADE , EDU_GRA = :EDU_GRA, EDU_LAST = :EDU_LAST,
                            DATASYS1 = :DATASYS1, DATASYS2 = :DATASYS2, DATASYS3 = :DATASYS3
                            where EDU_EMPNO = :EDU_EMPNO and EDU_LOE = :EDU_LOE and EDU_ENTDATE = :EDU_ENTDATE";
        #endregion

        #region TINSA_BAS4
        //수상경력 조회
        public const string Tinsa_Bas4_Select = @"select 'Select' , awa.*
                            from LMG_TINSA_AWARD awa
                            where award_empno = :bas_empno";

        //값 Insert
        public const string Tinsa_Bas4_Insert = @"
        Insert into LMG_TINSA_AWARD
            (AWARD_EMPNO,AWARD_DATE,AWARD_NO,AWARD_KIND,AWARD_ORGAN,AWARD_CONTENT,AWARD_INOUT,AWARD_POS,AWARD_DEPT,DATASYS1,DATASYS2,DATASYS3)
        values
            (:AWARD_EMPNO,:AWARD_DATE,:AWARD_NO,:AWARD_KIND,:AWARD_ORGAN,:AWARD_CONTENT,:AWARD_INOUT,:AWARD_POS,:AWARD_DEPT,:DATASYS1,:DATASYS2,:DATASYS3)";

        public const string Tinsa_Bas4_Update = @"
        Update LMG_TINSA_AWARD
        set AWARD_NO = :AWARD_NO,AWARD_KIND = :AWARD_KIND,AWARD_ORGAN = :AWARD_ORGAN,AWARD_CONTENT = :AWARD_CONTENT,
        AWARD_INOUT = :AWARD_INOUT,AWARD_POS = :AWARD_POS,AWARD_DEPT = :AWARD_DEPT,
        DATASYS1 = :DATASYS1,DATASYS2 = :DATASYS2,DATASYS3 = :DATASYS3
        where AWARD_EMPNO = :AWARD_EMPNO and AWARD_DATE = :AWARD_DATE";
        #endregion

        #region Tinsa_Bas5
        public const string Tinsa_Bas5_Select = @"select 'Select' , car.*
                            from LMG_TINSA_CAR car
                            where car_empno = :bas_empno";

        public const string Tinsa_Bas5_Insert = @"
        Insert into LMG_TINSA_CAR
            (CAR_EMPNO,CAR_COM,CAR_REGION,CAR_YYYYMM_F,CAR_YYYYMM_T,CAR_POS,CAR_DEPT,CAR_REASON,DATASYS1,DATASYS2,DATASYS3)
        values
            (:CAR_EMPNO,:CAR_COM,:CAR_REGION,:CAR_YYYYMM_F,:CAR_YYYYMM_T,:CAR_POS,:CAR_DEPT,:CAR_REASON,:DATASYS1,:DATASYS2,:DATASYS3)";

        public const string Tinsa_Bas5_Update = @"
        Update LMG_TINSA_CAR
        set CAR_REGION = :CAR_REGION,CAR_YYYYMM_F = :CAR_YYYYMM_F,CAR_YYYYMM_T = :CAR_YYYYMM_T,CAR_POS = :CAR_POS,
        CAR_DEPT = :CAR_DEPT,CAR_REASON = :CAR_REASON,DATASYS1 = :DATASYS1,DATASYS2 = :DATASYS2,DATASYS3 = :DATASYS3
        where CAR_EMPNO = :CAR_EMPNO AND CAR_COM = :CAR_COM";
        #endregion

        #region TINSA_BAS6
        //수상경력 조회
        public const string Tinsa_Bas6_Select = @"select 'Select' , lic.*
                            from LMG_TINSA_LIC lic
                            where lic_empno = :bas_empno";

        //값 Insert
        public const string Tinsa_Bas6_Insert = @"
        Insert into LMG_TINSA_LIC
            (LIC_EMPNO,LIC_NAME,LIC_GRADE,LIC_ACQDATE,LIC_ORGAN,DATASYS1,DATASYS2,DATASYS3)
        values
            (:LIC_EMPNO,:LIC_NAME,:LIC_GRADE,:LIC_ACQDATE,:LIC_ORGAN,:DATASYS1,:DATASYS2,:DATASYS3)";

        public const string Tinsa_Bas6_Update = @"
        Update LMG_TINSA_LIC
        set LIC_GRADE = :LIC_GRADE, LIC_ACQDATE = :LIC_ACQDATE, LIC_ORGAN = :LIC_ORGAN, DATASYS1 = :DATASYS1,
        DATASYS2 = :DATASYS2, DATASYS3 = :DATASYS3
        where LIC_EMPNO = :LIC_EMPNO AND LIC_NAME = :LIC_NAME";
        #endregion

        #region TINSA_BAS7
        //수상경력 조회
        public const string Tinsa_Bas7_Select = @"select 'Select' , forl.*
                            from LMG_TINSA_FORL forl
                            where forl_empno = :bas_empno";

        //값 Insert
        public const string Tinsa_Bas7_Insert = @"
        Insert into LMG_TINSA_FORL
            (FORL_EMPNO,FORL_NAME,FORL_SCORE,FORL_ACQDATE,FORL_ORGAN,DATASYS1,DATASYS2,DATASYS3)
        values
            (:FORL_EMPNO,:FORL_NAME,:FORL_SCORE,:FORL_ACQDATE,:FORL_ORGAN,:DATASYS1,:DATASYS2,:DATASYS3)";

        public const string Tinsa_Bas7_Update = @"
        Update LMG_TINSA_FORL
        set FORL_SCORE = :FORL_SCORE,FORL_ACQDATE = :FORL_ACQDATE,FORL_ORGAN = :FORL_ORGAN,DATASYS1 = :DATASYS1,
        DATASYS2 = :DATASYS2,DATASYS3 = :DATASYS3
        where FORL_EMPNO = :FORL_EMPNO AND FORL_NAME = :FORL_NAME";
        #endregion

        #region TINSA_BAS8
        //수상경력 조회
        public const string Tinsa_Bas8_Select = @"
                            select bas.* , img.IMG_IMAGE
                            from LMG_TINSA_BAS bas
                            left join LMG_TINSA_IMAGE img
                            on bas.BAS_EMPNO = img.IMG_EMPNO
                            where bas.bas_empno like :bas_empno and bas.bas_name like :bas_name
                            and bas.bas_pos like :bas_pos and bas.bas_dept like :bas_dept
                            order by bas.BAS_EMPNO";

        #endregion

        #region TINSA_BAS8 탭 컨트롤 조회
        public const string Tinsa_Bas8_Select1 = @"select *
                            from LMG_TINSA_CD cd
                            inner join LMG_TINSA_FAM fam
                            on cd.CD_CODE = fam.FAM_REL
                            where fam.FAM_EMPNO = :bas_empno";

        public const string Tinsa_Bas8_Select2 = @"select *
                            from LMG_TINSA_EDU 
                            where edu_EMPNO = :bas_empno";

        public const string Tinsa_Bas8_Select3 = @"select *
                            from LMG_TINSA_AWARD
                            where award_empno = :bas_empno";

        public const string Tinsa_Bas8_Select4 = @"select *
                            from LMG_TINSA_CAR
                            where car_empno = :bas_empno";

        public const string Tinsa_Bas8_Select5 = @"select *
                            from LMG_TINSA_LIC
                            where lic_empno = :bas_empno";

        public const string Tinsa_Bas8_Select6 = @"select *
                            from LMG_TINSA_FORL
                            where forl_empno = :bas_empno";


        #endregion

        #region TINSA_ISSUED1
        public const string Tinsa_Issued1_Select = @"select *   
                            from LMG_TINSA_PAPR
                            where papr_appno like :papr_appno
                            And papr_date like :papr_date"; 

        public const string Tinsa_Issued1_Insert = @"
                            Insert into LMG_TINSA_PAPR
                                (PAPR_APPNO,PAPR_DATE,PAPR_CONTENT,PAPR_NUM,DATASYS1,DATASYS2,DATASYS3)
                            values
                                (:PAPR_APPNO,:PAPR_DATE,:PAPR_CONTENT,:PAPR_NUM,:DATASYS1,:DATASYS2,:DATASYS3)";

        // 값 Update
        public const string Tinsa_Issued1_Update = @"
                            Update LMG_TINSA_PAPR
                            set PAPR_CONTENT = :PAPR_CONTENT, PAPR_NUM = :PAPR_NUM,
                            DATASYS1 = :DATASYS1,DATASYS2 = :DATASYS2,DATASYS3 = :DATASYS3
                            where PAPR_APPNO = :PAPR_APPNO and PAPR_DATE = :PAPR_DATE";
        #endregion

        #region TINSA_ISSUED2
        public const string Tinsa_Issued2_Select = @"select *
                            from LMG_TINSA_PAPR pr
                            inner join LMG_TINSA_PAPP pa
                            on pr.papr_appno = pa.papp_appno
                            where pa.papp_appno = :papp_appno";

        public const string Tinsa_Issued2_Empno_Select = @"select *
                            from LMG_TINSA_PAPR pr
                            inner join LMG_TINSA_PAPP pa
                            on pr.papr_appno = pa.papp_appno
                            where pa.papp_appno = :papp_appno";

        public const string Tinsa_Issued2_Insert = @"
                            Insert into LMG_TINSA_PAPP
                                (PAPP_EMPNO,PAPP_APPNO,PAPP_DATE,PAPP_PAP,PAPP_CONTENT,PAPP_AUTH,PAPP_BASIS,
                                 PAPP_RMK,PAPP_POS_CD,PAPP_DUT_CD,PAPP_DEPT_CD,PAPP_POS_NM,PAPP_DUT_NM,PAPP_DEPT_NM,
                                 DATASYS1,DATASYS2,DATASYS3)
                            values
                                (:PAPP_EMPNO,:PAPP_APPNO,:PAPP_DATE,:PAPP_PAP,:PAPP_CONTENT,:PAPP_AUTH,:PAPP_BASIS,
                                 :PAPP_RMK,:PAPP_POS_CD,:PAPP_DUT_CD,:PAPP_DEPT_CD,:PAPP_POS_NM,:PAPP_DUT_NM,
                                 :PAPP_DEPT_NM,:DATASYS1,:DATASYS2,:DATASYS3)";
        #endregion

        #region TINSA_SEARCHEMPNO
        //검색
        public const string Tinsa_SearchEmpno1 = @" select bas_empno, bas_name
                            from lmg_tinsa_bas 
                            where bas_empno like :bas_empno
                            order by bas_empno";
        #endregion
    }
}
