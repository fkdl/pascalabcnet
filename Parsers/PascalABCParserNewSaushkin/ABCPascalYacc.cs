// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.3.6
// Machine:  DESKTOP-IF20NRO
// DateTime: 5/20/2019 1:17:16 PM
// UserName: FatCow
// Input file <ABCPascal.y>

// options: no-lines gplex

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using QUT.Gppg;
using PascalABCCompiler.SyntaxTree;
using PascalABCSavParser;
using PascalABCCompiler.ParserTools;
using PascalABCCompiler.Errors;
using System.Linq;
using SyntaxVisitors;

namespace GPPGParserScanner
{
public enum Tokens {
    error=1,EOF=2,tkDirectiveName=3,tkAmpersend=4,tkColon=5,tkDotDot=6,
    tkPoint=7,tkRoundOpen=8,tkRoundClose=9,tkSemiColon=10,tkSquareOpen=11,tkSquareClose=12,
    tkQuestion=13,tkUnderscore=14,tkQuestionPoint=15,tkDoubleQuestion=16,tkQuestionSquareOpen=17,tkSizeOf=18,
    tkTypeOf=19,tkWhere=20,tkArray=21,tkCase=22,tkClass=23,tkAuto=24,
    tkStatic=25,tkConst=26,tkConstructor=27,tkDestructor=28,tkElse=29,tkExcept=30,
    tkFile=31,tkFor=32,tkForeach=33,tkFunction=34,tkMatch=35,tkWhen=36,
    tkIf=37,tkImplementation=38,tkInherited=39,tkInterface=40,tkProcedure=41,tkOperator=42,
    tkProperty=43,tkRaise=44,tkRecord=45,tkSet=46,tkType=47,tkThen=48,
    tkUses=49,tkVar=50,tkWhile=51,tkWith=52,tkNil=53,tkGoto=54,
    tkOf=55,tkLabel=56,tkLock=57,tkProgram=58,tkEvent=59,tkDefault=60,
    tkTemplate=61,tkPacked=62,tkExports=63,tkResourceString=64,tkThreadvar=65,tkSealed=66,
    tkPartial=67,tkTo=68,tkDownto=69,tkLoop=70,tkSequence=71,tkYield=72,
    tkNew=73,tkOn=74,tkName=75,tkPrivate=76,tkProtected=77,tkPublic=78,
    tkInternal=79,tkRead=80,tkWrite=81,tkParseModeExpression=82,tkParseModeStatement=83,tkParseModeType=84,
    tkBegin=85,tkEnd=86,tkAsmBody=87,tkILCode=88,tkError=89,INVISIBLE=90,
    tkRepeat=91,tkUntil=92,tkDo=93,tkComma=94,tkFinally=95,tkTry=96,
    tkInitialization=97,tkFinalization=98,tkUnit=99,tkLibrary=100,tkExternal=101,tkParams=102,
    tkNamespace=103,tkAssign=104,tkPlusEqual=105,tkMinusEqual=106,tkMultEqual=107,tkDivEqual=108,
    tkMinus=109,tkPlus=110,tkSlash=111,tkStar=112,tkStarStar=113,tkEqual=114,
    tkGreater=115,tkGreaterEqual=116,tkLower=117,tkLowerEqual=118,tkNotEqual=119,tkCSharpStyleOr=120,
    tkArrow=121,tkOr=122,tkXor=123,tkAnd=124,tkDiv=125,tkMod=126,
    tkShl=127,tkShr=128,tkNot=129,tkAs=130,tkIn=131,tkIs=132,
    tkImplicit=133,tkExplicit=134,tkAddressOf=135,tkDeref=136,tkIdentifier=137,tkStringLiteral=138,
    tkFormatStringLiteral=139,tkAsciiChar=140,tkAbstract=141,tkForward=142,tkOverload=143,tkReintroduce=144,
    tkOverride=145,tkVirtual=146,tkExtensionMethod=147,tkInteger=148,tkFloat=149,tkHex=150};

// Abstract base class for GPLEX scanners
public abstract class ScanBase : AbstractScanner<PascalABCSavParser.Union,LexLocation> {
  private LexLocation __yylloc = new LexLocation();
  public override LexLocation yylloc { get { return __yylloc; } set { __yylloc = value; } }
  protected virtual bool yywrap() { return true; }
}

public partial class GPPGParser: ShiftReduceParser<PascalABCSavParser.Union, LexLocation>
{
  // Verbatim content from ABCPascal.y
// ��� ���������� ����������� � ����� GPPGParser, �������������� ����� ������, ������������ �������� gppg
    public syntax_tree_node root; // �������� ���� ��������������� ������ 

    public List<Error> errors;
    public string current_file_name;
    public int max_errors = 10;
    public PT parsertools;
    public List<compiler_directive> CompilerDirectives;
	public ParserLambdaHelper lambdaHelper = new ParserLambdaHelper();
	
    public GPPGParser(AbstractScanner<PascalABCSavParser.Union, LexLocation> scanner) : base(scanner) { }
  // End verbatim content from ABCPascal.y

#pragma warning disable 649
  private static Dictionary<int, string> aliasses;
#pragma warning restore 649
  private static Rule[] rules = new Rule[938];
  private static State[] states = new State[1551];
  private static string[] nonTerms = new string[] {
      "parse_goal", "unit_key_word", "class_or_static", "assignment", "optional_array_initializer", 
      "attribute_declarations", "ot_visibility_specifier", "one_attribute", "attribute_variable", 
      "const_factor", "const_variable_2", "const_term", "const_variable", "literal_or_number", 
      "unsigned_number", "variable_or_literal_or_number", "program_block", "optional_var", 
      "class_attribute", "class_attributes", "class_attributes1", "member_list_section", 
      "optional_component_list_seq_end", "const_decl", "only_const_decl", "const_decl_sect", 
      "object_type", "record_type", "member_list", "method_decl_list", "field_or_const_definition_list", 
      "case_stmt", "case_list", "program_decl_sect_list", "int_decl_sect_list1", 
      "inclass_decl_sect_list1", "interface_decl_sect_list", "decl_sect_list", 
      "decl_sect_list1", "inclass_decl_sect_list", "field_or_const_definition", 
      "abc_decl_sect", "decl_sect", "int_decl_sect", "type_decl", "simple_type_decl", 
      "simple_field_or_const_definition", "res_str_decl_sect", "method_decl_withattr", 
      "method_or_property_decl", "property_definition", "fp_sect", "default_expr", 
      "tuple", "expr_as_stmt", "exception_block", "external_block", "exception_handler", 
      "exception_handler_list", "exception_identifier", "typed_const_list1", 
      "typed_const_list", "optional_expr_list", "elem_list", "optional_expr_list_with_bracket", 
      "expr_list", "const_elem_list1", "case_label_list", "const_elem_list", 
      "optional_const_func_expr_list", "elem_list1", "enumeration_id", "expr_l1_list", 
      "enumeration_id_list", "const_simple_expr", "term", "simple_term", "typed_const", 
      "typed_const_plus", "typed_var_init_expression", "expr", "expr_with_func_decl_lambda", 
      "const_expr", "elem", "range_expr", "const_elem", "array_const", "factor", 
      "relop_expr", "expr_dq", "expr_l1", "expr_l1_func_decl_lambda", "simple_expr", 
      "range_term", "range_factor", "external_directive_ident", "init_const_expr", 
      "case_label", "variable", "var_reference", "optional_read_expr", "simple_expr_or_nothing", 
      "var_question_point", "for_cycle_type", "format_expr", "format_const_expr", 
      "const_expr_or_nothing", "foreach_stmt", "for_stmt", "loop_stmt", "yield_stmt", 
      "yield_sequence_stmt", "fp_list", "fp_sect_list", "file_type", "sequence_type", 
      "var_address", "goto_stmt", "func_name_ident", "param_name", "const_field_name", 
      "func_name_with_template_args", "identifier_or_keyword", "unit_name", "exception_variable", 
      "const_name", "func_meth_name_ident", "label_name", "type_decl_identifier", 
      "template_identifier_with_equal", "program_param", "identifier", "identifier_keyword_operatorname", 
      "func_class_name_ident", "visibility_specifier", "property_specifier_directives", 
      "non_reserved", "if_stmt", "initialization_part", "template_arguments", 
      "label_list", "ident_or_keyword_pointseparator_list", "ident_list", "param_name_list", 
      "inherited_message", "implementation_part", "interface_part", "abc_interface_part", 
      "simple_type_list", "literal", "one_literal", "literal_list", "label_decl_sect", 
      "lock_stmt", "func_name", "proc_name", "optional_proc_name", "qualified_identifier", 
      "new_expr", "allowable_expr_as_stmt", "parts", "inclass_block", "block", 
      "proc_func_external_block", "exception_class_type_identifier", "simple_type_identifier", 
      "base_class_name", "base_classes_names_list", "optional_base_classes", 
      "one_compiler_directive", "optional_head_compiler_directives", "head_compiler_directives", 
      "program_heading_2", "optional_tk_point", "program_param_list", "optional_semicolon", 
      "operator_name_ident", "const_relop", "const_addop", "assign_operator", 
      "const_mulop", "relop", "addop", "mulop", "sign", "overload_operator", 
      "typecast_op", "property_specifiers", "write_property_specifiers", "read_property_specifiers", 
      "array_defaultproperty", "meth_modificators", "optional_method_modificators", 
      "optional_method_modificators1", "meth_modificator", "property_modificator", 
      "proc_call", "proc_func_constr_destr_decl", "proc_func_decl", "inclass_proc_func_decl", 
      "inclass_proc_func_decl_noclass", "constr_destr_decl", "inclass_constr_destr_decl", 
      "method_decl", "proc_func_constr_destr_decl_with_attr", "proc_func_decl_noclass", 
      "method_header", "proc_type_decl", "procedural_type_kind", "proc_header", 
      "procedural_type", "constr_destr_header", "proc_func_header", "func_header", 
      "method_procfunc_header", "int_func_header", "int_proc_header", "property_interface", 
      "program_file", "program_header", "parameter_decl", "parameter_decl_list", 
      "property_parameter_list", "const_set", "question_expr", "question_constexpr", 
      "record_const", "const_field_list_1", "const_field_list", "const_field", 
      "repeat_stmt", "raise_stmt", "pointer_type", "attribute_declaration", "one_or_some_attribute", 
      "stmt_list", "else_case", "exception_block_else_branch", "compound_stmt", 
      "string_type", "sizeof_expr", "simple_property_definition", "stmt_or_expression", 
      "unlabelled_stmt", "stmt", "case_item", "set_type", "as_is_expr", "as_is_constexpr", 
      "is_type_expr", "as_expr", "power_expr", "power_constexpr", "unsized_array_type", 
      "simple_type_or_", "simple_type", "simple_type_question", "foreach_stmt_ident_dype_opt", 
      "fptype", "type_ref", "fptype_noproctype", "array_type", "template_param", 
      "template_empty_param", "structured_type", "unpacked_structured_type", 
      "empty_template_type_reference", "simple_or_template_type_reference", "type_ref_or_secific", 
      "for_stmt_decl_or_assign", "type_decl_type", "type_ref_and_secific_list", 
      "type_decl_sect", "try_handler", "class_or_interface_keyword", "optional_tk_do", 
      "keyword", "reserved_keyword", "typeof_expr", "simple_fp_sect", "template_param_list", 
      "template_empty_param_list", "template_type_params", "template_type_empty_params", 
      "template_type", "try_stmt", "uses_clause", "used_units_list", "unit_file", 
      "used_unit_name", "unit_header", "var_decl_sect", "var_decl", "var_decl_part", 
      "field_definition", "var_decl_with_assign_var_tuple", "var_stmt", "where_part", 
      "where_part_list", "optional_where_section", "while_stmt", "with_stmt", 
      "variable_as_type", "dotted_identifier", "func_decl_lambda", "expl_func_decl_lambda", 
      "lambda_type_ref", "lambda_type_ref_noproctype", "full_lambda_fp_list", 
      "lambda_simple_fp_sect", "lambda_function_body", "lambda_procedure_body", 
      "common_lambda_body", "optional_full_lambda_fp_list", "field_in_unnamed_object", 
      "list_fields_in_unnamed_object", "func_class_name_ident_list", "rem_lambda", 
      "variable_list", "var_ident_list", "tkAssignOrEqual", "pattern", "pattern_optional_var", 
      "const_pattern", "collection_pattern", "tuple_pattern", "collection_pattern_list_item", 
      "tuple_pattern_item", "collection_pattern_var_item", "match_with", "pattern_case", 
      "pattern_cases", "pattern_out_param", "pattern_out_param_optional_var", 
      "const_pattern_expr_list", "pattern_out_param_list", "pattern_out_param_list_optional_var", 
      "collection_pattern_expr_list", "tuple_pattern_item_list", "const_pattern_expression", 
      "$accept", };

  static GPPGParser() {
    states[0] = new State(new int[]{58,1458,11,1016,82,1533,84,1538,83,1545,3,-25,49,-25,85,-25,56,-25,26,-25,64,-25,47,-25,50,-25,59,-25,41,-25,34,-25,25,-25,23,-25,27,-25,28,-25,99,-200,100,-200,103,-200},new int[]{-1,1,-219,3,-220,4,-289,1470,-6,1471,-234,1033,-161,1532});
    states[1] = new State(new int[]{2,2});
    states[2] = new State(-1);
    states[3] = new State(-2);
    states[4] = new State(new int[]{3,1454,49,-12,85,-12,56,-12,26,-12,64,-12,47,-12,50,-12,59,-12,11,-12,41,-12,34,-12,25,-12,23,-12,27,-12,28,-12},new int[]{-171,5,-172,1452,-170,1457});
    states[5] = new State(-36,new int[]{-287,6});
    states[6] = new State(new int[]{49,14,56,-60,26,-60,64,-60,47,-60,50,-60,59,-60,11,-60,41,-60,34,-60,25,-60,23,-60,27,-60,28,-60,85,-60},new int[]{-17,7,-34,114,-38,1389,-39,1390});
    states[7] = new State(new int[]{7,9,10,10,5,11,94,12,6,13,2,-24},new int[]{-174,8});
    states[8] = new State(-18);
    states[9] = new State(-19);
    states[10] = new State(-20);
    states[11] = new State(-21);
    states[12] = new State(-22);
    states[13] = new State(-23);
    states[14] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,79,32,78,33,77,34,76,35,66,36,61,37,122,38,19,39,18,40,60,41,20,42,123,43,124,44,125,45,126,46,127,47,128,48,129,49,130,50,131,51,132,52,21,53,71,54,85,55,22,56,23,57,26,58,27,59,28,60,69,61,93,62,29,63,30,64,31,65,24,66,98,67,95,68,32,69,33,70,34,71,37,72,38,73,39,74,97,75,40,76,41,77,43,78,44,79,45,80,91,81,46,82,96,83,47,84,25,85,48,86,68,87,92,88,49,89,50,90,51,91,52,92,53,93,54,94,55,95,56,96,58,97,99,98,100,99,103,100,101,101,102,102,59,103,72,104,35,105,36,106,42,108,86,109},new int[]{-288,15,-290,113,-142,19,-123,112,-132,22,-136,24,-137,27,-277,30,-135,31,-278,107});
    states[15] = new State(new int[]{10,16,94,17});
    states[16] = new State(-37);
    states[17] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,79,32,78,33,77,34,76,35,66,36,61,37,122,38,19,39,18,40,60,41,20,42,123,43,124,44,125,45,126,46,127,47,128,48,129,49,130,50,131,51,132,52,21,53,71,54,85,55,22,56,23,57,26,58,27,59,28,60,69,61,93,62,29,63,30,64,31,65,24,66,98,67,95,68,32,69,33,70,34,71,37,72,38,73,39,74,97,75,40,76,41,77,43,78,44,79,45,80,91,81,46,82,96,83,47,84,25,85,48,86,68,87,92,88,49,89,50,90,51,91,52,92,53,93,54,94,55,95,56,96,58,97,99,98,100,99,103,100,101,101,102,102,59,103,72,104,35,105,36,106,42,108,86,109},new int[]{-290,18,-142,19,-123,112,-132,22,-136,24,-137,27,-277,30,-135,31,-278,107});
    states[18] = new State(-39);
    states[19] = new State(new int[]{7,20,131,110,10,-40,94,-40});
    states[20] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,79,32,78,33,77,34,76,35,66,36,61,37,122,38,19,39,18,40,60,41,20,42,123,43,124,44,125,45,126,46,127,47,128,48,129,49,130,50,131,51,132,52,21,53,71,54,85,55,22,56,23,57,26,58,27,59,28,60,69,61,93,62,29,63,30,64,31,65,24,66,98,67,95,68,32,69,33,70,34,71,37,72,38,73,39,74,97,75,40,76,41,77,43,78,44,79,45,80,91,81,46,82,96,83,47,84,25,85,48,86,68,87,92,88,49,89,50,90,51,91,52,92,53,93,54,94,55,95,56,96,58,97,99,98,100,99,103,100,101,101,102,102,59,103,72,104,35,105,36,106,42,108,86,109},new int[]{-123,21,-132,22,-136,24,-137,27,-277,30,-135,31,-278,107});
    states[21] = new State(-35);
    states[22] = new State(-773);
    states[23] = new State(-770);
    states[24] = new State(-771);
    states[25] = new State(-788);
    states[26] = new State(-789);
    states[27] = new State(-772);
    states[28] = new State(-790);
    states[29] = new State(-791);
    states[30] = new State(-774);
    states[31] = new State(-796);
    states[32] = new State(-792);
    states[33] = new State(-793);
    states[34] = new State(-794);
    states[35] = new State(-795);
    states[36] = new State(-797);
    states[37] = new State(-798);
    states[38] = new State(-799);
    states[39] = new State(-800);
    states[40] = new State(-801);
    states[41] = new State(-802);
    states[42] = new State(-803);
    states[43] = new State(-804);
    states[44] = new State(-805);
    states[45] = new State(-806);
    states[46] = new State(-807);
    states[47] = new State(-808);
    states[48] = new State(-809);
    states[49] = new State(-810);
    states[50] = new State(-811);
    states[51] = new State(-812);
    states[52] = new State(-813);
    states[53] = new State(-814);
    states[54] = new State(-815);
    states[55] = new State(-816);
    states[56] = new State(-817);
    states[57] = new State(-818);
    states[58] = new State(-819);
    states[59] = new State(-820);
    states[60] = new State(-821);
    states[61] = new State(-822);
    states[62] = new State(-823);
    states[63] = new State(-824);
    states[64] = new State(-825);
    states[65] = new State(-826);
    states[66] = new State(-827);
    states[67] = new State(-828);
    states[68] = new State(-829);
    states[69] = new State(-830);
    states[70] = new State(-831);
    states[71] = new State(-832);
    states[72] = new State(-833);
    states[73] = new State(-834);
    states[74] = new State(-835);
    states[75] = new State(-836);
    states[76] = new State(-837);
    states[77] = new State(-838);
    states[78] = new State(-839);
    states[79] = new State(-840);
    states[80] = new State(-841);
    states[81] = new State(-842);
    states[82] = new State(-843);
    states[83] = new State(-844);
    states[84] = new State(-845);
    states[85] = new State(-846);
    states[86] = new State(-847);
    states[87] = new State(-848);
    states[88] = new State(-849);
    states[89] = new State(-850);
    states[90] = new State(-851);
    states[91] = new State(-852);
    states[92] = new State(-853);
    states[93] = new State(-854);
    states[94] = new State(-855);
    states[95] = new State(-856);
    states[96] = new State(-857);
    states[97] = new State(-858);
    states[98] = new State(-859);
    states[99] = new State(-860);
    states[100] = new State(-861);
    states[101] = new State(-862);
    states[102] = new State(-863);
    states[103] = new State(-864);
    states[104] = new State(-865);
    states[105] = new State(-866);
    states[106] = new State(-867);
    states[107] = new State(-775);
    states[108] = new State(-868);
    states[109] = new State(-869);
    states[110] = new State(new int[]{138,111});
    states[111] = new State(-41);
    states[112] = new State(-34);
    states[113] = new State(-38);
    states[114] = new State(new int[]{85,116},new int[]{-239,115});
    states[115] = new State(-32);
    states[116] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,697,150,155,149,698,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,86,-476,10,-476},new int[]{-236,117,-245,695,-244,121,-4,122,-100,123,-117,435,-99,447,-132,696,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787,-128,911});
    states[117] = new State(new int[]{86,118,10,119});
    states[118] = new State(-512);
    states[119] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,697,150,155,149,698,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,86,-476,10,-476,92,-476,95,-476,30,-476,98,-476},new int[]{-245,120,-244,121,-4,122,-100,123,-117,435,-99,447,-132,696,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787,-128,911});
    states[120] = new State(-514);
    states[121] = new State(-474);
    states[122] = new State(-477);
    states[123] = new State(new int[]{104,485,105,486,106,487,107,488,108,489,86,-510,10,-510,92,-510,95,-510,30,-510,98,-510,29,-510,94,-510,12,-510,9,-510,93,-510,81,-510,80,-510,2,-510,79,-510,78,-510,77,-510,76,-510},new int[]{-180,124});
    states[124] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,551,18,247,19,252,5,642,34,863,41,878},new int[]{-82,125,-81,126,-91,127,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,454,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641,-305,936,-306,937});
    states[125] = new State(-504);
    states[126] = new State(-578);
    states[127] = new State(new int[]{13,128,86,-580,10,-580,92,-580,95,-580,30,-580,98,-580,29,-580,94,-580,12,-580,9,-580,93,-580,81,-580,80,-580,2,-580,79,-580,78,-580,77,-580,76,-580,6,-580});
    states[128] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-91,129,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623});
    states[129] = new State(new int[]{5,130,13,128});
    states[130] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-91,131,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623});
    states[131] = new State(new int[]{13,128,86,-591,10,-591,92,-591,95,-591,30,-591,98,-591,29,-591,94,-591,12,-591,9,-591,93,-591,81,-591,80,-591,2,-591,79,-591,78,-591,77,-591,76,-591,5,-591,6,-591,48,-591,55,-591,135,-591,137,-591,75,-591,73,-591,42,-591,39,-591,8,-591,18,-591,19,-591,138,-591,140,-591,139,-591,148,-591,150,-591,149,-591,54,-591,85,-591,37,-591,22,-591,91,-591,51,-591,32,-591,52,-591,96,-591,44,-591,33,-591,50,-591,57,-591,72,-591,70,-591,35,-591,68,-591,69,-591});
    states[132] = new State(new int[]{16,133,13,-582,86,-582,10,-582,92,-582,95,-582,30,-582,98,-582,29,-582,94,-582,12,-582,9,-582,93,-582,81,-582,80,-582,2,-582,79,-582,78,-582,77,-582,76,-582,5,-582,6,-582,48,-582,55,-582,135,-582,137,-582,75,-582,73,-582,42,-582,39,-582,8,-582,18,-582,19,-582,138,-582,140,-582,139,-582,148,-582,150,-582,149,-582,54,-582,85,-582,37,-582,22,-582,91,-582,51,-582,32,-582,52,-582,96,-582,44,-582,33,-582,50,-582,57,-582,72,-582,70,-582,35,-582,68,-582,69,-582});
    states[133] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-89,134,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622});
    states[134] = new State(new int[]{114,291,119,292,117,293,115,294,118,295,116,296,131,297,16,-587,13,-587,86,-587,10,-587,92,-587,95,-587,30,-587,98,-587,29,-587,94,-587,12,-587,9,-587,93,-587,81,-587,80,-587,2,-587,79,-587,78,-587,77,-587,76,-587,5,-587,6,-587,48,-587,55,-587,135,-587,137,-587,75,-587,73,-587,42,-587,39,-587,8,-587,18,-587,19,-587,138,-587,140,-587,139,-587,148,-587,150,-587,149,-587,54,-587,85,-587,37,-587,22,-587,91,-587,51,-587,32,-587,52,-587,96,-587,44,-587,33,-587,50,-587,57,-587,72,-587,70,-587,35,-587,68,-587,69,-587},new int[]{-182,135});
    states[135] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-93,136,-76,308,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,646,-251,622});
    states[136] = new State(new int[]{110,303,109,304,122,305,123,306,120,307,114,-609,119,-609,117,-609,115,-609,118,-609,116,-609,131,-609,16,-609,13,-609,86,-609,10,-609,92,-609,95,-609,30,-609,98,-609,29,-609,94,-609,12,-609,9,-609,93,-609,81,-609,80,-609,2,-609,79,-609,78,-609,77,-609,76,-609,5,-609,6,-609,48,-609,55,-609,135,-609,137,-609,75,-609,73,-609,42,-609,39,-609,8,-609,18,-609,19,-609,138,-609,140,-609,139,-609,148,-609,150,-609,149,-609,54,-609,85,-609,37,-609,22,-609,91,-609,51,-609,32,-609,52,-609,96,-609,44,-609,33,-609,50,-609,57,-609,72,-609,70,-609,35,-609,68,-609,69,-609},new int[]{-183,137});
    states[137] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-76,138,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,646,-251,622});
    states[138] = new State(new int[]{132,309,130,311,112,313,111,314,125,315,126,316,127,317,128,318,124,319,5,-681,110,-681,109,-681,122,-681,123,-681,120,-681,114,-681,119,-681,117,-681,115,-681,118,-681,116,-681,131,-681,16,-681,13,-681,86,-681,10,-681,92,-681,95,-681,30,-681,98,-681,29,-681,94,-681,12,-681,9,-681,93,-681,81,-681,80,-681,2,-681,79,-681,78,-681,77,-681,76,-681,6,-681,48,-681,55,-681,135,-681,137,-681,75,-681,73,-681,42,-681,39,-681,8,-681,18,-681,19,-681,138,-681,140,-681,139,-681,148,-681,150,-681,149,-681,54,-681,85,-681,37,-681,22,-681,91,-681,51,-681,32,-681,52,-681,96,-681,44,-681,33,-681,50,-681,57,-681,72,-681,70,-681,35,-681,68,-681,69,-681},new int[]{-184,139});
    states[139] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,29,42,461,39,491,8,493,18,247,19,252},new int[]{-88,140,-252,141,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-77,571});
    states[140] = new State(new int[]{132,-698,130,-698,112,-698,111,-698,125,-698,126,-698,127,-698,128,-698,124,-698,5,-698,110,-698,109,-698,122,-698,123,-698,120,-698,114,-698,119,-698,117,-698,115,-698,118,-698,116,-698,131,-698,16,-698,13,-698,86,-698,10,-698,92,-698,95,-698,30,-698,98,-698,29,-698,94,-698,12,-698,9,-698,93,-698,81,-698,80,-698,2,-698,79,-698,78,-698,77,-698,76,-698,6,-698,48,-698,55,-698,135,-698,137,-698,75,-698,73,-698,42,-698,39,-698,8,-698,18,-698,19,-698,138,-698,140,-698,139,-698,148,-698,150,-698,149,-698,54,-698,85,-698,37,-698,22,-698,91,-698,51,-698,32,-698,52,-698,96,-698,44,-698,33,-698,50,-698,57,-698,72,-698,70,-698,35,-698,68,-698,69,-698,113,-693});
    states[141] = new State(-699);
    states[142] = new State(-710);
    states[143] = new State(new int[]{7,144,132,-711,130,-711,112,-711,111,-711,125,-711,126,-711,127,-711,128,-711,124,-711,5,-711,110,-711,109,-711,122,-711,123,-711,120,-711,114,-711,119,-711,117,-711,115,-711,118,-711,116,-711,131,-711,16,-711,13,-711,86,-711,10,-711,92,-711,95,-711,30,-711,98,-711,29,-711,94,-711,12,-711,9,-711,93,-711,81,-711,80,-711,2,-711,79,-711,78,-711,77,-711,76,-711,113,-711,6,-711,48,-711,55,-711,135,-711,137,-711,75,-711,73,-711,42,-711,39,-711,8,-711,18,-711,19,-711,138,-711,140,-711,139,-711,148,-711,150,-711,149,-711,54,-711,85,-711,37,-711,22,-711,91,-711,51,-711,32,-711,52,-711,96,-711,44,-711,33,-711,50,-711,57,-711,72,-711,70,-711,35,-711,68,-711,69,-711,11,-734});
    states[144] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,79,32,78,33,77,34,76,35,66,36,61,37,122,38,19,39,18,40,60,41,20,42,123,43,124,44,125,45,126,46,127,47,128,48,129,49,130,50,131,51,132,52,21,53,71,54,85,55,22,56,23,57,26,58,27,59,28,60,69,61,93,62,29,63,30,64,31,65,24,66,98,67,95,68,32,69,33,70,34,71,37,72,38,73,39,74,97,75,40,76,41,77,43,78,44,79,45,80,91,81,46,82,96,83,47,84,25,85,48,86,68,87,92,88,49,89,50,90,51,91,52,92,53,93,54,94,55,95,56,96,58,97,99,98,100,99,103,100,101,101,102,102,59,103,72,104,35,105,36,106,42,108,86,109},new int[]{-123,145,-132,22,-136,24,-137,27,-277,30,-135,31,-278,107});
    states[145] = new State(-741);
    states[146] = new State(-718);
    states[147] = new State(new int[]{138,149,140,150,7,-759,11,-759,132,-759,130,-759,112,-759,111,-759,125,-759,126,-759,127,-759,128,-759,124,-759,5,-759,110,-759,109,-759,122,-759,123,-759,120,-759,114,-759,119,-759,117,-759,115,-759,118,-759,116,-759,131,-759,16,-759,13,-759,86,-759,10,-759,92,-759,95,-759,30,-759,98,-759,29,-759,94,-759,12,-759,9,-759,93,-759,81,-759,80,-759,2,-759,79,-759,78,-759,77,-759,76,-759,113,-759,6,-759,48,-759,55,-759,135,-759,137,-759,75,-759,73,-759,42,-759,39,-759,8,-759,18,-759,19,-759,139,-759,148,-759,150,-759,149,-759,54,-759,85,-759,37,-759,22,-759,91,-759,51,-759,32,-759,52,-759,96,-759,44,-759,33,-759,50,-759,57,-759,72,-759,70,-759,35,-759,68,-759,69,-759,121,-759,104,-759,4,-759,136,-759,36,-759},new int[]{-151,148});
    states[148] = new State(-762);
    states[149] = new State(-757);
    states[150] = new State(-758);
    states[151] = new State(-761);
    states[152] = new State(-760);
    states[153] = new State(-719);
    states[154] = new State(-177);
    states[155] = new State(-178);
    states[156] = new State(-179);
    states[157] = new State(-712);
    states[158] = new State(new int[]{8,159});
    states[159] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-268,160,-166,162,-132,196,-136,24,-137,27});
    states[160] = new State(new int[]{9,161});
    states[161] = new State(-708);
    states[162] = new State(new int[]{7,163,4,166,117,168,9,-594,130,-594,132,-594,112,-594,111,-594,125,-594,126,-594,127,-594,128,-594,124,-594,110,-594,109,-594,122,-594,123,-594,114,-594,119,-594,115,-594,118,-594,116,-594,131,-594,13,-594,6,-594,94,-594,12,-594,5,-594,86,-594,10,-594,92,-594,95,-594,30,-594,98,-594,29,-594,93,-594,81,-594,80,-594,2,-594,79,-594,78,-594,77,-594,76,-594,11,-594,8,-594,120,-594,16,-594,48,-594,55,-594,135,-594,137,-594,75,-594,73,-594,42,-594,39,-594,18,-594,19,-594,138,-594,140,-594,139,-594,148,-594,150,-594,149,-594,54,-594,85,-594,37,-594,22,-594,91,-594,51,-594,32,-594,52,-594,96,-594,44,-594,33,-594,50,-594,57,-594,72,-594,70,-594,35,-594,68,-594,69,-594,113,-594},new int[]{-283,165});
    states[163] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,79,32,78,33,77,34,76,35,66,36,61,37,122,38,19,39,18,40,60,41,20,42,123,43,124,44,125,45,126,46,127,47,128,48,129,49,130,50,131,51,132,52,21,53,71,54,85,55,22,56,23,57,26,58,27,59,28,60,69,61,93,62,29,63,30,64,31,65,24,66,98,67,95,68,32,69,33,70,34,71,37,72,38,73,39,74,97,75,40,76,41,77,43,78,44,79,45,80,91,81,46,82,96,83,47,84,25,85,48,86,68,87,92,88,49,89,50,90,51,91,52,92,53,93,54,94,55,95,56,96,58,97,99,98,100,99,103,100,101,101,102,102,59,103,72,104,35,105,36,106,42,108,86,109},new int[]{-123,164,-132,22,-136,24,-137,27,-277,30,-135,31,-278,107});
    states[164] = new State(-248);
    states[165] = new State(-595);
    states[166] = new State(new int[]{117,168},new int[]{-283,167});
    states[167] = new State(-596);
    states[168] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-281,169,-263,266,-256,173,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-265,596,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,597,-209,527,-208,528,-285,598});
    states[169] = new State(new int[]{115,170,94,171});
    states[170] = new State(-222);
    states[171] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-263,172,-256,173,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-265,596,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,597,-209,527,-208,528,-285,598});
    states[172] = new State(-226);
    states[173] = new State(new int[]{13,174,115,-230,94,-230,114,-230,9,-230,10,-230,121,-230,104,-230,86,-230,92,-230,95,-230,30,-230,98,-230,29,-230,12,-230,93,-230,81,-230,80,-230,2,-230,79,-230,78,-230,77,-230,76,-230,131,-230});
    states[174] = new State(-231);
    states[175] = new State(new int[]{6,1387,110,1376,109,1377,122,1378,123,1379,13,-235,115,-235,94,-235,114,-235,9,-235,10,-235,121,-235,104,-235,86,-235,92,-235,95,-235,30,-235,98,-235,29,-235,12,-235,93,-235,81,-235,80,-235,2,-235,79,-235,78,-235,77,-235,76,-235,131,-235},new int[]{-179,176});
    states[176] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152},new int[]{-94,177,-95,268,-166,386,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151});
    states[177] = new State(new int[]{112,218,111,219,125,220,126,221,127,222,128,223,124,224,6,-239,110,-239,109,-239,122,-239,123,-239,13,-239,115,-239,94,-239,114,-239,9,-239,10,-239,121,-239,104,-239,86,-239,92,-239,95,-239,30,-239,98,-239,29,-239,12,-239,93,-239,81,-239,80,-239,2,-239,79,-239,78,-239,77,-239,76,-239,131,-239},new int[]{-181,178});
    states[178] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152},new int[]{-95,179,-166,386,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151});
    states[179] = new State(new int[]{8,180,112,-241,111,-241,125,-241,126,-241,127,-241,128,-241,124,-241,6,-241,110,-241,109,-241,122,-241,123,-241,13,-241,115,-241,94,-241,114,-241,9,-241,10,-241,121,-241,104,-241,86,-241,92,-241,95,-241,30,-241,98,-241,29,-241,12,-241,93,-241,81,-241,80,-241,2,-241,79,-241,78,-241,77,-241,76,-241,131,-241});
    states[180] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,370,129,373,110,377,109,378,9,-172},new int[]{-69,181,-67,183,-86,366,-83,186,-75,191,-12,215,-10,225,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379,-249,380,-253,381,-226,382});
    states[181] = new State(new int[]{9,182});
    states[182] = new State(-246);
    states[183] = new State(new int[]{94,184,9,-171,12,-171});
    states[184] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,370,129,373,110,377,109,378},new int[]{-86,185,-83,186,-75,191,-12,215,-10,225,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379,-249,380,-253,381,-226,382});
    states[185] = new State(-174);
    states[186] = new State(new int[]{13,187,6,1360,94,-175,9,-175,12,-175,5,-175});
    states[187] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,370,129,373,110,377,109,378},new int[]{-83,188,-75,191,-12,215,-10,225,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379,-249,380,-253,381,-226,382});
    states[188] = new State(new int[]{5,189,13,187});
    states[189] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,370,129,373,110,377,109,378},new int[]{-83,190,-75,191,-12,215,-10,225,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379,-249,380,-253,381,-226,382});
    states[190] = new State(new int[]{13,187,6,-117,94,-117,9,-117,12,-117,5,-117,86,-117,10,-117,92,-117,95,-117,30,-117,98,-117,29,-117,93,-117,81,-117,80,-117,2,-117,79,-117,78,-117,77,-117,76,-117});
    states[191] = new State(new int[]{110,1376,109,1377,122,1378,123,1379,114,1380,119,1381,117,1382,115,1383,118,1384,116,1385,131,1386,13,-114,6,-114,94,-114,9,-114,12,-114,5,-114,86,-114,10,-114,92,-114,95,-114,30,-114,98,-114,29,-114,93,-114,81,-114,80,-114,2,-114,79,-114,78,-114,77,-114,76,-114},new int[]{-179,192,-178,1374});
    states[192] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,370,129,373,110,377,109,378},new int[]{-12,193,-10,225,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379,-249,380,-253,381});
    states[193] = new State(new int[]{130,216,132,217,112,218,111,219,125,220,126,221,127,222,128,223,124,224,110,-126,109,-126,122,-126,123,-126,114,-126,119,-126,117,-126,115,-126,118,-126,116,-126,131,-126,13,-126,6,-126,94,-126,9,-126,12,-126,5,-126,86,-126,10,-126,92,-126,95,-126,30,-126,98,-126,29,-126,93,-126,81,-126,80,-126,2,-126,79,-126,78,-126,77,-126,76,-126},new int[]{-187,194,-181,197});
    states[194] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-268,195,-166,162,-132,196,-136,24,-137,27});
    states[195] = new State(-131);
    states[196] = new State(-247);
    states[197] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,370,129,373,110,377,109,378},new int[]{-10,198,-253,1373,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379});
    states[198] = new State(new int[]{113,199,130,-136,132,-136,112,-136,111,-136,125,-136,126,-136,127,-136,128,-136,124,-136,110,-136,109,-136,122,-136,123,-136,114,-136,119,-136,117,-136,115,-136,118,-136,116,-136,131,-136,13,-136,6,-136,94,-136,9,-136,12,-136,5,-136,86,-136,10,-136,92,-136,95,-136,30,-136,98,-136,29,-136,93,-136,81,-136,80,-136,2,-136,79,-136,78,-136,77,-136,76,-136});
    states[199] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,370,129,373,110,377,109,378},new int[]{-10,200,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379});
    states[200] = new State(-132);
    states[201] = new State(new int[]{4,203,11,205,7,1366,136,1368,8,1369,113,-145,130,-145,132,-145,112,-145,111,-145,125,-145,126,-145,127,-145,128,-145,124,-145,110,-145,109,-145,122,-145,123,-145,114,-145,119,-145,117,-145,115,-145,118,-145,116,-145,131,-145,13,-145,6,-145,94,-145,9,-145,12,-145,5,-145,86,-145,10,-145,92,-145,95,-145,30,-145,98,-145,29,-145,93,-145,81,-145,80,-145,2,-145,79,-145,78,-145,77,-145,76,-145},new int[]{-11,202});
    states[202] = new State(-162);
    states[203] = new State(new int[]{117,168},new int[]{-283,204});
    states[204] = new State(-163);
    states[205] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,370,129,373,110,377,109,378,5,1362,12,-172},new int[]{-106,206,-69,208,-83,210,-75,191,-12,215,-10,225,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379,-249,380,-253,381,-226,382,-67,183,-86,366});
    states[206] = new State(new int[]{12,207});
    states[207] = new State(-164);
    states[208] = new State(new int[]{12,209});
    states[209] = new State(-168);
    states[210] = new State(new int[]{5,211,13,187,6,1360,94,-175,12,-175});
    states[211] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,370,129,373,110,377,109,378,5,-664,12,-664},new int[]{-107,212,-83,1359,-75,191,-12,215,-10,225,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379,-249,380,-253,381,-226,382});
    states[212] = new State(new int[]{5,213,12,-669});
    states[213] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,370,129,373,110,377,109,378},new int[]{-83,214,-75,191,-12,215,-10,225,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379,-249,380,-253,381,-226,382});
    states[214] = new State(new int[]{13,187,12,-671});
    states[215] = new State(new int[]{130,216,132,217,112,218,111,219,125,220,126,221,127,222,128,223,124,224,110,-125,109,-125,122,-125,123,-125,114,-125,119,-125,117,-125,115,-125,118,-125,116,-125,131,-125,13,-125,6,-125,94,-125,9,-125,12,-125,5,-125,86,-125,10,-125,92,-125,95,-125,30,-125,98,-125,29,-125,93,-125,81,-125,80,-125,2,-125,79,-125,78,-125,77,-125,76,-125},new int[]{-187,194,-181,197});
    states[216] = new State(-687);
    states[217] = new State(-688);
    states[218] = new State(-138);
    states[219] = new State(-139);
    states[220] = new State(-140);
    states[221] = new State(-141);
    states[222] = new State(-142);
    states[223] = new State(-143);
    states[224] = new State(-144);
    states[225] = new State(new int[]{113,199,130,-133,132,-133,112,-133,111,-133,125,-133,126,-133,127,-133,128,-133,124,-133,110,-133,109,-133,122,-133,123,-133,114,-133,119,-133,117,-133,115,-133,118,-133,116,-133,131,-133,13,-133,6,-133,94,-133,9,-133,12,-133,5,-133,86,-133,10,-133,92,-133,95,-133,30,-133,98,-133,29,-133,93,-133,81,-133,80,-133,2,-133,79,-133,78,-133,77,-133,76,-133});
    states[226] = new State(-156);
    states[227] = new State(new int[]{23,1348,137,23,80,25,81,26,75,28,73,29,17,-791,8,-791,7,-791,136,-791,4,-791,15,-791,104,-791,105,-791,106,-791,107,-791,108,-791,86,-791,10,-791,11,-791,5,-791,92,-791,95,-791,30,-791,98,-791,121,-791,132,-791,130,-791,112,-791,111,-791,125,-791,126,-791,127,-791,128,-791,124,-791,110,-791,109,-791,122,-791,123,-791,120,-791,114,-791,119,-791,117,-791,115,-791,118,-791,116,-791,131,-791,16,-791,13,-791,29,-791,94,-791,12,-791,9,-791,93,-791,2,-791,79,-791,78,-791,77,-791,76,-791,113,-791,6,-791,48,-791,55,-791,135,-791,42,-791,39,-791,18,-791,19,-791,138,-791,140,-791,139,-791,148,-791,150,-791,149,-791,54,-791,85,-791,37,-791,22,-791,91,-791,51,-791,32,-791,52,-791,96,-791,44,-791,33,-791,50,-791,57,-791,72,-791,70,-791,35,-791,68,-791,69,-791},new int[]{-268,228,-166,162,-132,196,-136,24,-137,27});
    states[228] = new State(new int[]{11,230,8,1024,86,-606,10,-606,92,-606,95,-606,30,-606,98,-606,132,-606,130,-606,112,-606,111,-606,125,-606,126,-606,127,-606,128,-606,124,-606,5,-606,110,-606,109,-606,122,-606,123,-606,120,-606,114,-606,119,-606,117,-606,115,-606,118,-606,116,-606,131,-606,16,-606,13,-606,29,-606,94,-606,12,-606,9,-606,93,-606,81,-606,80,-606,2,-606,79,-606,78,-606,77,-606,76,-606,6,-606,48,-606,55,-606,135,-606,137,-606,75,-606,73,-606,42,-606,39,-606,18,-606,19,-606,138,-606,140,-606,139,-606,148,-606,150,-606,149,-606,54,-606,85,-606,37,-606,22,-606,91,-606,51,-606,32,-606,52,-606,96,-606,44,-606,33,-606,50,-606,57,-606,72,-606,70,-606,35,-606,68,-606,69,-606,113,-606},new int[]{-65,229});
    states[229] = new State(-599);
    states[230] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,551,18,247,19,252,5,642,34,863,41,878,12,-750},new int[]{-63,231,-66,451,-82,550,-81,126,-91,127,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,454,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641,-305,936,-306,937});
    states[231] = new State(new int[]{12,232});
    states[232] = new State(new int[]{8,234,86,-598,10,-598,92,-598,95,-598,30,-598,98,-598,132,-598,130,-598,112,-598,111,-598,125,-598,126,-598,127,-598,128,-598,124,-598,5,-598,110,-598,109,-598,122,-598,123,-598,120,-598,114,-598,119,-598,117,-598,115,-598,118,-598,116,-598,131,-598,16,-598,13,-598,29,-598,94,-598,12,-598,9,-598,93,-598,81,-598,80,-598,2,-598,79,-598,78,-598,77,-598,76,-598,6,-598,48,-598,55,-598,135,-598,137,-598,75,-598,73,-598,42,-598,39,-598,18,-598,19,-598,138,-598,140,-598,139,-598,148,-598,150,-598,149,-598,54,-598,85,-598,37,-598,22,-598,91,-598,51,-598,32,-598,52,-598,96,-598,44,-598,33,-598,50,-598,57,-598,72,-598,70,-598,35,-598,68,-598,69,-598,113,-598},new int[]{-5,233});
    states[233] = new State(-600);
    states[234] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,847,129,373,110,377,109,378,60,158,9,-186},new int[]{-62,235,-61,237,-79,850,-78,240,-83,241,-75,191,-12,215,-10,225,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379,-249,380,-253,381,-226,382,-87,858,-227,859,-53,851});
    states[235] = new State(new int[]{9,236});
    states[236] = new State(-597);
    states[237] = new State(new int[]{94,238,9,-187});
    states[238] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,847,129,373,110,377,109,378,60,158},new int[]{-79,239,-78,240,-83,241,-75,191,-12,215,-10,225,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379,-249,380,-253,381,-226,382,-87,858,-227,859,-53,851});
    states[239] = new State(-189);
    states[240] = new State(-404);
    states[241] = new State(new int[]{13,187,94,-180,9,-180,86,-180,10,-180,92,-180,95,-180,30,-180,98,-180,29,-180,12,-180,93,-180,81,-180,80,-180,2,-180,79,-180,78,-180,77,-180,76,-180});
    states[242] = new State(-157);
    states[243] = new State(-158);
    states[244] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-132,245,-136,24,-137,27});
    states[245] = new State(-159);
    states[246] = new State(-160);
    states[247] = new State(new int[]{8,248});
    states[248] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-268,249,-166,162,-132,196,-136,24,-137,27});
    states[249] = new State(new int[]{9,250});
    states[250] = new State(-588);
    states[251] = new State(-161);
    states[252] = new State(new int[]{8,253});
    states[253] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-268,254,-267,256,-166,258,-132,196,-136,24,-137,27});
    states[254] = new State(new int[]{9,255});
    states[255] = new State(-589);
    states[256] = new State(new int[]{9,257});
    states[257] = new State(-590);
    states[258] = new State(new int[]{7,163,4,259,117,261,119,1346,9,-594},new int[]{-283,165,-284,1347});
    states[259] = new State(new int[]{117,261,119,1346},new int[]{-283,167,-284,260});
    states[260] = new State(-593);
    states[261] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587,115,-229,94,-229},new int[]{-281,169,-282,262,-263,266,-256,173,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-265,596,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,597,-209,527,-208,528,-285,598,-264,1345});
    states[262] = new State(new int[]{115,263,94,264});
    states[263] = new State(-224);
    states[264] = new State(-229,new int[]{-264,265});
    states[265] = new State(-228);
    states[266] = new State(-225);
    states[267] = new State(new int[]{112,218,111,219,125,220,126,221,127,222,128,223,124,224,6,-238,110,-238,109,-238,122,-238,123,-238,13,-238,115,-238,94,-238,114,-238,9,-238,10,-238,121,-238,104,-238,86,-238,92,-238,95,-238,30,-238,98,-238,29,-238,12,-238,93,-238,81,-238,80,-238,2,-238,79,-238,78,-238,77,-238,76,-238,131,-238},new int[]{-181,178});
    states[268] = new State(new int[]{8,180,112,-240,111,-240,125,-240,126,-240,127,-240,128,-240,124,-240,6,-240,110,-240,109,-240,122,-240,123,-240,13,-240,115,-240,94,-240,114,-240,9,-240,10,-240,121,-240,104,-240,86,-240,92,-240,95,-240,30,-240,98,-240,29,-240,12,-240,93,-240,81,-240,80,-240,2,-240,79,-240,78,-240,77,-240,76,-240,131,-240});
    states[269] = new State(new int[]{7,163,121,270,117,168,8,-242,112,-242,111,-242,125,-242,126,-242,127,-242,128,-242,124,-242,6,-242,110,-242,109,-242,122,-242,123,-242,13,-242,115,-242,94,-242,114,-242,9,-242,10,-242,104,-242,86,-242,92,-242,95,-242,30,-242,98,-242,29,-242,12,-242,93,-242,81,-242,80,-242,2,-242,79,-242,78,-242,77,-242,76,-242,131,-242},new int[]{-283,960});
    states[270] = new State(new int[]{8,272,137,23,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-263,271,-256,173,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-265,596,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,597,-209,527,-208,528,-285,598});
    states[271] = new State(-277);
    states[272] = new State(new int[]{9,273,137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-74,278,-72,284,-260,287,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[273] = new State(new int[]{121,274,115,-281,94,-281,114,-281,9,-281,10,-281,104,-281,86,-281,92,-281,95,-281,30,-281,98,-281,29,-281,12,-281,93,-281,81,-281,80,-281,2,-281,79,-281,78,-281,77,-281,76,-281,131,-281});
    states[274] = new State(new int[]{8,276,137,23,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-263,275,-256,173,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-265,596,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,597,-209,527,-208,528,-285,598});
    states[275] = new State(-279);
    states[276] = new State(new int[]{9,277,137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-74,278,-72,284,-260,287,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[277] = new State(new int[]{121,274,115,-283,94,-283,114,-283,9,-283,10,-283,104,-283,86,-283,92,-283,95,-283,30,-283,98,-283,29,-283,12,-283,93,-283,81,-283,80,-283,2,-283,79,-283,78,-283,77,-283,76,-283,131,-283});
    states[278] = new State(new int[]{9,279,94,964});
    states[279] = new State(new int[]{121,280,13,-237,115,-237,94,-237,114,-237,9,-237,10,-237,104,-237,86,-237,92,-237,95,-237,30,-237,98,-237,29,-237,12,-237,93,-237,81,-237,80,-237,2,-237,79,-237,78,-237,77,-237,76,-237,131,-237});
    states[280] = new State(new int[]{8,282,137,23,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-263,281,-256,173,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-265,596,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,597,-209,527,-208,528,-285,598});
    states[281] = new State(-280);
    states[282] = new State(new int[]{9,283,137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-74,278,-72,284,-260,287,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[283] = new State(new int[]{121,274,115,-284,94,-284,114,-284,9,-284,10,-284,104,-284,86,-284,92,-284,95,-284,30,-284,98,-284,29,-284,12,-284,93,-284,81,-284,80,-284,2,-284,79,-284,78,-284,77,-284,76,-284,131,-284});
    states[284] = new State(new int[]{94,285});
    states[285] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-72,286,-260,287,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[286] = new State(-249);
    states[287] = new State(new int[]{114,288,94,-251,9,-251});
    states[288] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,5,642},new int[]{-81,289,-91,127,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641});
    states[289] = new State(-252);
    states[290] = new State(new int[]{114,291,119,292,117,293,115,294,118,295,116,296,131,297,16,-586,13,-586,86,-586,10,-586,92,-586,95,-586,30,-586,98,-586,29,-586,94,-586,12,-586,9,-586,93,-586,81,-586,80,-586,2,-586,79,-586,78,-586,77,-586,76,-586,5,-586,6,-586,48,-586,55,-586,135,-586,137,-586,75,-586,73,-586,42,-586,39,-586,8,-586,18,-586,19,-586,138,-586,140,-586,139,-586,148,-586,150,-586,149,-586,54,-586,85,-586,37,-586,22,-586,91,-586,51,-586,32,-586,52,-586,96,-586,44,-586,33,-586,50,-586,57,-586,72,-586,70,-586,35,-586,68,-586,69,-586},new int[]{-182,135});
    states[291] = new State(-673);
    states[292] = new State(-674);
    states[293] = new State(-675);
    states[294] = new State(-676);
    states[295] = new State(-677);
    states[296] = new State(-678);
    states[297] = new State(-679);
    states[298] = new State(new int[]{5,299,110,303,109,304,122,305,123,306,120,307,114,-608,119,-608,117,-608,115,-608,118,-608,116,-608,131,-608,16,-608,13,-608,86,-608,10,-608,92,-608,95,-608,30,-608,98,-608,29,-608,94,-608,12,-608,9,-608,93,-608,81,-608,80,-608,2,-608,79,-608,78,-608,77,-608,76,-608,6,-608},new int[]{-183,137});
    states[299] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,5,-662,86,-662,10,-662,92,-662,95,-662,30,-662,98,-662,29,-662,94,-662,12,-662,9,-662,93,-662,2,-662,79,-662,78,-662,77,-662,76,-662,6,-662},new int[]{-102,300,-93,647,-76,308,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,646,-251,622});
    states[300] = new State(new int[]{5,301,86,-665,10,-665,92,-665,95,-665,30,-665,98,-665,29,-665,94,-665,12,-665,9,-665,93,-665,81,-665,80,-665,2,-665,79,-665,78,-665,77,-665,76,-665,6,-665});
    states[301] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-93,302,-76,308,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,646,-251,622});
    states[302] = new State(new int[]{110,303,109,304,122,305,123,306,120,307,86,-667,10,-667,92,-667,95,-667,30,-667,98,-667,29,-667,94,-667,12,-667,9,-667,93,-667,81,-667,80,-667,2,-667,79,-667,78,-667,77,-667,76,-667,6,-667},new int[]{-183,137});
    states[303] = new State(-682);
    states[304] = new State(-683);
    states[305] = new State(-684);
    states[306] = new State(-685);
    states[307] = new State(-686);
    states[308] = new State(new int[]{132,309,130,311,112,313,111,314,125,315,126,316,127,317,128,318,124,319,110,-680,109,-680,122,-680,123,-680,120,-680,114,-680,119,-680,117,-680,115,-680,118,-680,116,-680,131,-680,16,-680,13,-680,86,-680,10,-680,92,-680,95,-680,30,-680,98,-680,29,-680,94,-680,12,-680,9,-680,93,-680,81,-680,80,-680,2,-680,79,-680,78,-680,77,-680,76,-680,5,-680,6,-680,48,-680,55,-680,135,-680,137,-680,75,-680,73,-680,42,-680,39,-680,8,-680,18,-680,19,-680,138,-680,140,-680,139,-680,148,-680,150,-680,149,-680,54,-680,85,-680,37,-680,22,-680,91,-680,51,-680,32,-680,52,-680,96,-680,44,-680,33,-680,50,-680,57,-680,72,-680,70,-680,35,-680,68,-680,69,-680},new int[]{-184,139});
    states[309] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-268,310,-166,162,-132,196,-136,24,-137,27});
    states[310] = new State(-692);
    states[311] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-268,312,-166,162,-132,196,-136,24,-137,27});
    states[312] = new State(-691);
    states[313] = new State(-701);
    states[314] = new State(-702);
    states[315] = new State(-703);
    states[316] = new State(-704);
    states[317] = new State(-705);
    states[318] = new State(-706);
    states[319] = new State(-707);
    states[320] = new State(new int[]{132,-695,130,-695,112,-695,111,-695,125,-695,126,-695,127,-695,128,-695,124,-695,5,-695,110,-695,109,-695,122,-695,123,-695,120,-695,114,-695,119,-695,117,-695,115,-695,118,-695,116,-695,131,-695,16,-695,13,-695,86,-695,10,-695,92,-695,95,-695,30,-695,98,-695,29,-695,94,-695,12,-695,9,-695,93,-695,81,-695,80,-695,2,-695,79,-695,78,-695,77,-695,76,-695,6,-695,48,-695,55,-695,135,-695,137,-695,75,-695,73,-695,42,-695,39,-695,8,-695,18,-695,19,-695,138,-695,140,-695,139,-695,148,-695,150,-695,149,-695,54,-695,85,-695,37,-695,22,-695,91,-695,51,-695,32,-695,52,-695,96,-695,44,-695,33,-695,50,-695,57,-695,72,-695,70,-695,35,-695,68,-695,69,-695,113,-693});
    states[321] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,5,642,12,-752},new int[]{-64,322,-71,324,-84,1344,-81,327,-91,127,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641});
    states[322] = new State(new int[]{12,323});
    states[323] = new State(-713);
    states[324] = new State(new int[]{94,325,12,-751});
    states[325] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,5,642},new int[]{-84,326,-81,327,-91,127,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641});
    states[326] = new State(-754);
    states[327] = new State(new int[]{6,328,94,-755,12,-755});
    states[328] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,5,642},new int[]{-81,329,-91,127,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641});
    states[329] = new State(-756);
    states[330] = new State(new int[]{132,331,130,311,112,313,111,314,125,315,126,316,127,317,128,318,124,319,5,-680,110,-680,109,-680,122,-680,123,-680,120,-680,114,-680,119,-680,117,-680,115,-680,118,-680,116,-680,131,-680,16,-680,13,-680,86,-680,10,-680,92,-680,95,-680,30,-680,98,-680,29,-680,94,-680,12,-680,9,-680,93,-680,81,-680,80,-680,2,-680,79,-680,78,-680,77,-680,76,-680,6,-680,48,-680,55,-680,135,-680,137,-680,75,-680,73,-680,42,-680,39,-680,8,-680,18,-680,19,-680,138,-680,140,-680,139,-680,148,-680,150,-680,149,-680,54,-680,85,-680,37,-680,22,-680,91,-680,51,-680,32,-680,52,-680,96,-680,44,-680,33,-680,50,-680,57,-680,72,-680,70,-680,35,-680,68,-680,69,-680},new int[]{-184,139});
    states[331] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,11,334,8,608},new int[]{-268,310,-325,332,-326,333,-166,162,-132,196,-136,24,-137,27});
    states[332] = new State(-611);
    states[333] = new State(-612);
    states[334] = new State(new int[]{138,149,140,150,139,152,148,154,150,155,149,156,50,341,14,343,137,23,80,25,81,26,75,28,73,29,11,334,8,608,6,1342},new int[]{-338,335,-327,1343,-14,339,-150,146,-152,147,-151,151,-15,153,-329,340,-323,344,-268,345,-166,162,-132,196,-136,24,-137,27,-325,1340,-326,1341});
    states[335] = new State(new int[]{12,336,94,337});
    states[336] = new State(-615);
    states[337] = new State(new int[]{138,149,140,150,139,152,148,154,150,155,149,156,50,341,14,343,137,23,80,25,81,26,75,28,73,29,11,334,8,608,6,1342},new int[]{-327,338,-14,339,-150,146,-152,147,-151,151,-15,153,-329,340,-323,344,-268,345,-166,162,-132,196,-136,24,-137,27,-325,1340,-326,1341});
    states[338] = new State(-617);
    states[339] = new State(-618);
    states[340] = new State(-619);
    states[341] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-132,342,-136,24,-137,27});
    states[342] = new State(-625);
    states[343] = new State(-620);
    states[344] = new State(-621);
    states[345] = new State(new int[]{8,346});
    states[346] = new State(new int[]{14,351,138,149,140,150,139,152,148,154,150,155,149,156,137,23,80,25,81,26,75,28,73,29,50,1330,11,334,8,608},new int[]{-337,347,-334,1339,-14,352,-150,146,-152,147,-151,151,-15,153,-132,353,-136,24,-137,27,-323,1334,-268,345,-166,162,-325,1335,-326,1336});
    states[347] = new State(new int[]{9,348,10,349,94,1337});
    states[348] = new State(-614);
    states[349] = new State(new int[]{14,351,138,149,140,150,139,152,148,154,150,155,149,156,137,23,80,25,81,26,75,28,73,29,50,1330,11,334,8,608},new int[]{-334,350,-14,352,-150,146,-152,147,-151,151,-15,153,-132,353,-136,24,-137,27,-323,1334,-268,345,-166,162,-325,1335,-326,1336});
    states[350] = new State(-640);
    states[351] = new State(-652);
    states[352] = new State(-653);
    states[353] = new State(new int[]{5,354,9,-655,10,-655,94,-655,7,-247,4,-247,117,-247,8,-247});
    states[354] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-260,355,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[355] = new State(-654);
    states[356] = new State(new int[]{13,357,114,-214,94,-214,9,-214,10,-214,115,-214,121,-214,104,-214,86,-214,92,-214,95,-214,30,-214,98,-214,29,-214,12,-214,93,-214,81,-214,80,-214,2,-214,79,-214,78,-214,77,-214,76,-214,131,-214});
    states[357] = new State(-213);
    states[358] = new State(new int[]{11,359,7,-770,121,-770,117,-770,8,-770,112,-770,111,-770,125,-770,126,-770,127,-770,128,-770,124,-770,6,-770,110,-770,109,-770,122,-770,123,-770,13,-770,114,-770,94,-770,9,-770,10,-770,115,-770,104,-770,86,-770,92,-770,95,-770,30,-770,98,-770,29,-770,12,-770,93,-770,81,-770,80,-770,2,-770,79,-770,78,-770,77,-770,76,-770,131,-770});
    states[359] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,370,129,373,110,377,109,378},new int[]{-83,360,-75,191,-12,215,-10,225,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379,-249,380,-253,381,-226,382});
    states[360] = new State(new int[]{12,361,13,187});
    states[361] = new State(-272);
    states[362] = new State(-146);
    states[363] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,370,129,373,110,377,109,378,12,-172},new int[]{-69,364,-67,183,-86,366,-83,186,-75,191,-12,215,-10,225,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379,-249,380,-253,381,-226,382});
    states[364] = new State(new int[]{12,365});
    states[365] = new State(-153);
    states[366] = new State(-173);
    states[367] = new State(-147);
    states[368] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,370,129,373,110,377,109,378},new int[]{-10,369,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379});
    states[369] = new State(-148);
    states[370] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,370,129,373,110,377,109,378},new int[]{-83,371,-75,191,-12,215,-10,225,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379,-249,380,-253,381,-226,382});
    states[371] = new State(new int[]{9,372,13,187});
    states[372] = new State(-149);
    states[373] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,370,129,373,110,377,109,378},new int[]{-10,374,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379});
    states[374] = new State(-150);
    states[375] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,370,129,373,110,377,109,378},new int[]{-10,376,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379});
    states[376] = new State(-151);
    states[377] = new State(-154);
    states[378] = new State(-155);
    states[379] = new State(-152);
    states[380] = new State(-134);
    states[381] = new State(-135);
    states[382] = new State(-116);
    states[383] = new State(-243);
    states[384] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152},new int[]{-95,385,-166,386,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151});
    states[385] = new State(new int[]{8,180,112,-244,111,-244,125,-244,126,-244,127,-244,128,-244,124,-244,6,-244,110,-244,109,-244,122,-244,123,-244,13,-244,115,-244,94,-244,114,-244,9,-244,10,-244,121,-244,104,-244,86,-244,92,-244,95,-244,30,-244,98,-244,29,-244,12,-244,93,-244,81,-244,80,-244,2,-244,79,-244,78,-244,77,-244,76,-244,131,-244});
    states[386] = new State(new int[]{7,163,8,-242,112,-242,111,-242,125,-242,126,-242,127,-242,128,-242,124,-242,6,-242,110,-242,109,-242,122,-242,123,-242,13,-242,115,-242,94,-242,114,-242,9,-242,10,-242,121,-242,104,-242,86,-242,92,-242,95,-242,30,-242,98,-242,29,-242,12,-242,93,-242,81,-242,80,-242,2,-242,79,-242,78,-242,77,-242,76,-242,131,-242});
    states[387] = new State(-245);
    states[388] = new State(new int[]{9,389,137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-74,278,-72,284,-260,287,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[389] = new State(new int[]{121,274});
    states[390] = new State(-215);
    states[391] = new State(-216);
    states[392] = new State(-217);
    states[393] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-259,394,-260,395,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[394] = new State(-253);
    states[395] = new State(-468);
    states[396] = new State(-218);
    states[397] = new State(-254);
    states[398] = new State(-256);
    states[399] = new State(new int[]{11,400,55,1328});
    states[400] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,961,12,-268,94,-268},new int[]{-149,401,-255,1327,-256,1326,-85,175,-94,267,-95,268,-166,386,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151});
    states[401] = new State(new int[]{12,402,94,1324});
    states[402] = new State(new int[]{55,403});
    states[403] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-260,404,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[404] = new State(-262);
    states[405] = new State(-263);
    states[406] = new State(-257);
    states[407] = new State(new int[]{8,1199,20,-304,11,-304,86,-304,79,-304,78,-304,77,-304,76,-304,26,-304,137,-304,80,-304,81,-304,75,-304,73,-304,59,-304,25,-304,23,-304,41,-304,34,-304,27,-304,28,-304,43,-304,24,-304},new int[]{-169,408});
    states[408] = new State(new int[]{20,1190,11,-311,86,-311,79,-311,78,-311,77,-311,76,-311,26,-311,137,-311,80,-311,81,-311,75,-311,73,-311,59,-311,25,-311,23,-311,41,-311,34,-311,27,-311,28,-311,43,-311,24,-311},new int[]{-300,409,-299,1188,-298,1210});
    states[409] = new State(new int[]{11,1016,86,-328,79,-328,78,-328,77,-328,76,-328,26,-200,137,-200,80,-200,81,-200,75,-200,73,-200,59,-200,25,-200,23,-200,41,-200,34,-200,27,-200,28,-200,43,-200,24,-200},new int[]{-22,410,-29,1168,-31,414,-41,1169,-6,1170,-234,1033,-30,1280,-50,1282,-49,420,-51,1281});
    states[410] = new State(new int[]{86,411,79,1164,78,1165,77,1166,76,1167},new int[]{-7,412});
    states[411] = new State(-286);
    states[412] = new State(new int[]{11,1016,86,-328,79,-328,78,-328,77,-328,76,-328,26,-200,137,-200,80,-200,81,-200,75,-200,73,-200,59,-200,25,-200,23,-200,41,-200,34,-200,27,-200,28,-200,43,-200,24,-200},new int[]{-29,413,-31,414,-41,1169,-6,1170,-234,1033,-30,1280,-50,1282,-49,420,-51,1281});
    states[413] = new State(-323);
    states[414] = new State(new int[]{10,416,86,-334,79,-334,78,-334,77,-334,76,-334},new int[]{-176,415});
    states[415] = new State(-329);
    states[416] = new State(new int[]{11,1016,86,-335,79,-335,78,-335,77,-335,76,-335,26,-200,137,-200,80,-200,81,-200,75,-200,73,-200,59,-200,25,-200,23,-200,41,-200,34,-200,27,-200,28,-200,43,-200,24,-200},new int[]{-41,417,-30,418,-6,1170,-234,1033,-50,1282,-49,420,-51,1281});
    states[417] = new State(-337);
    states[418] = new State(new int[]{11,1016,86,-331,79,-331,78,-331,77,-331,76,-331,25,-200,23,-200,41,-200,34,-200,27,-200,28,-200,43,-200,24,-200},new int[]{-50,419,-49,420,-6,421,-234,1033,-51,1281});
    states[419] = new State(-340);
    states[420] = new State(-341);
    states[421] = new State(new int[]{25,1237,23,1238,41,1183,34,1218,27,1252,28,1259,11,1016,43,1266,24,1275},new int[]{-207,422,-234,423,-204,424,-242,425,-3,426,-215,1239,-213,1112,-210,1182,-214,1217,-212,1240,-200,1263,-201,1264,-203,1265});
    states[422] = new State(-350);
    states[423] = new State(-199);
    states[424] = new State(-351);
    states[425] = new State(-369);
    states[426] = new State(new int[]{27,428,43,1065,24,1107,41,1183,34,1218},new int[]{-215,427,-201,1064,-213,1112,-210,1182,-214,1217});
    states[427] = new State(-354);
    states[428] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,42,461,8,-364,104,-364,10,-364},new int[]{-157,429,-156,1047,-155,1048,-127,1049,-122,1050,-119,1051,-132,1056,-136,24,-137,27,-177,1057,-317,1059,-134,1063});
    states[429] = new State(new int[]{8,531,104,-452,10,-452},new int[]{-113,430});
    states[430] = new State(new int[]{104,432,10,1036},new int[]{-193,431});
    states[431] = new State(-361);
    states[432] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,10,-476},new int[]{-244,433,-4,122,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787});
    states[433] = new State(new int[]{10,434});
    states[434] = new State(-411);
    states[435] = new State(new int[]{135,1035,137,23,80,25,81,26,75,28,73,29,42,461,39,491,8,493,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156},new int[]{-99,436,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656});
    states[436] = new State(new int[]{17,437,8,448,7,650,136,652,4,653,104,-722,105,-722,106,-722,107,-722,108,-722,86,-722,10,-722,92,-722,95,-722,30,-722,98,-722,132,-722,130,-722,112,-722,111,-722,125,-722,126,-722,127,-722,128,-722,124,-722,5,-722,110,-722,109,-722,122,-722,123,-722,120,-722,114,-722,119,-722,117,-722,115,-722,118,-722,116,-722,131,-722,16,-722,13,-722,29,-722,94,-722,12,-722,9,-722,93,-722,81,-722,80,-722,2,-722,79,-722,78,-722,77,-722,76,-722,113,-722,6,-722,48,-722,55,-722,135,-722,137,-722,75,-722,73,-722,42,-722,39,-722,18,-722,19,-722,138,-722,140,-722,139,-722,148,-722,150,-722,149,-722,54,-722,85,-722,37,-722,22,-722,91,-722,51,-722,32,-722,52,-722,96,-722,44,-722,33,-722,50,-722,57,-722,72,-722,70,-722,35,-722,68,-722,69,-722,11,-733});
    states[437] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,5,642},new int[]{-105,438,-93,440,-76,308,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,646,-251,622});
    states[438] = new State(new int[]{12,439});
    states[439] = new State(-743);
    states[440] = new State(new int[]{5,299,110,303,109,304,122,305,123,306,120,307},new int[]{-183,137});
    states[441] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,29,42,461,39,491,8,493,18,247,19,252},new int[]{-88,442,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568});
    states[442] = new State(-714);
    states[443] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,29,42,461,39,491,8,493,18,247,19,252},new int[]{-88,444,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568});
    states[444] = new State(-715);
    states[445] = new State(-716);
    states[446] = new State(-725);
    states[447] = new State(new int[]{17,437,8,448,7,650,136,652,4,653,15,658,104,-723,105,-723,106,-723,107,-723,108,-723,86,-723,10,-723,92,-723,95,-723,30,-723,98,-723,132,-723,130,-723,112,-723,111,-723,125,-723,126,-723,127,-723,128,-723,124,-723,5,-723,110,-723,109,-723,122,-723,123,-723,120,-723,114,-723,119,-723,117,-723,115,-723,118,-723,116,-723,131,-723,16,-723,13,-723,29,-723,94,-723,12,-723,9,-723,93,-723,81,-723,80,-723,2,-723,79,-723,78,-723,77,-723,76,-723,113,-723,6,-723,48,-723,55,-723,135,-723,137,-723,75,-723,73,-723,42,-723,39,-723,18,-723,19,-723,138,-723,140,-723,139,-723,148,-723,150,-723,149,-723,54,-723,85,-723,37,-723,22,-723,91,-723,51,-723,32,-723,52,-723,96,-723,44,-723,33,-723,50,-723,57,-723,72,-723,70,-723,35,-723,68,-723,69,-723,11,-733});
    states[448] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,551,18,247,19,252,5,642,34,863,41,878,9,-750},new int[]{-63,449,-66,451,-82,550,-81,126,-91,127,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,454,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641,-305,936,-306,937});
    states[449] = new State(new int[]{9,450});
    states[450] = new State(-744);
    states[451] = new State(new int[]{94,452,12,-749,9,-749});
    states[452] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,551,18,247,19,252,5,642,34,863,41,878},new int[]{-82,453,-81,126,-91,127,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,454,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641,-305,936,-306,937});
    states[453] = new State(-575);
    states[454] = new State(new int[]{121,455,17,-735,8,-735,7,-735,136,-735,4,-735,15,-735,132,-735,130,-735,112,-735,111,-735,125,-735,126,-735,127,-735,128,-735,124,-735,5,-735,110,-735,109,-735,122,-735,123,-735,120,-735,114,-735,119,-735,117,-735,115,-735,118,-735,116,-735,131,-735,16,-735,13,-735,86,-735,10,-735,92,-735,95,-735,30,-735,98,-735,29,-735,94,-735,12,-735,9,-735,93,-735,81,-735,80,-735,2,-735,79,-735,78,-735,77,-735,76,-735,113,-735,11,-735});
    states[455] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,85,116,37,627,51,705,91,700,32,710,33,736,70,768,22,683,96,726,57,776,72,828,44,733},new int[]{-311,456,-91,457,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-313,624,-239,625,-138,626,-301,763,-231,764,-109,765,-108,766,-110,767,-32,824,-286,825,-154,826,-111,827,-232,829});
    states[456] = new State(-898);
    states[457] = new State(new int[]{13,128,86,-933,10,-933,92,-933,95,-933,30,-933,98,-933,29,-933,94,-933,12,-933,9,-933,93,-933,81,-933,80,-933,2,-933,79,-933,78,-933,77,-933,76,-933});
    states[458] = new State(new int[]{110,303,109,304,122,305,123,306,120,307,114,-608,119,-608,117,-608,115,-608,118,-608,116,-608,131,-608,16,-608,5,-608,13,-608,86,-608,10,-608,92,-608,95,-608,30,-608,98,-608,29,-608,94,-608,12,-608,9,-608,93,-608,81,-608,80,-608,2,-608,79,-608,78,-608,77,-608,76,-608,6,-608,48,-608,55,-608,135,-608,137,-608,75,-608,73,-608,42,-608,39,-608,8,-608,18,-608,19,-608,138,-608,140,-608,139,-608,148,-608,150,-608,149,-608,54,-608,85,-608,37,-608,22,-608,91,-608,51,-608,32,-608,52,-608,96,-608,44,-608,33,-608,50,-608,57,-608,72,-608,70,-608,35,-608,68,-608,69,-608},new int[]{-183,137});
    states[459] = new State(-735);
    states[460] = new State(-736);
    states[461] = new State(new int[]{109,463,110,464,111,465,112,466,114,467,115,468,116,469,117,470,118,471,119,472,122,473,123,474,124,475,125,476,126,477,127,478,128,479,129,480,131,481,133,482,134,483,104,485,105,486,106,487,107,488,108,489,113,490},new int[]{-186,462,-180,484});
    states[462] = new State(-763);
    states[463] = new State(-870);
    states[464] = new State(-871);
    states[465] = new State(-872);
    states[466] = new State(-873);
    states[467] = new State(-874);
    states[468] = new State(-875);
    states[469] = new State(-876);
    states[470] = new State(-877);
    states[471] = new State(-878);
    states[472] = new State(-879);
    states[473] = new State(-880);
    states[474] = new State(-881);
    states[475] = new State(-882);
    states[476] = new State(-883);
    states[477] = new State(-884);
    states[478] = new State(-885);
    states[479] = new State(-886);
    states[480] = new State(-887);
    states[481] = new State(-888);
    states[482] = new State(-889);
    states[483] = new State(-890);
    states[484] = new State(-891);
    states[485] = new State(-893);
    states[486] = new State(-894);
    states[487] = new State(-895);
    states[488] = new State(-896);
    states[489] = new State(-897);
    states[490] = new State(-892);
    states[491] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-132,492,-136,24,-137,27});
    states[492] = new State(-737);
    states[493] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,5,642},new int[]{-81,494,-91,496,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641});
    states[494] = new State(new int[]{9,495});
    states[495] = new State(-738);
    states[496] = new State(new int[]{94,497,13,128,9,-580});
    states[497] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-73,498,-91,972,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623});
    states[498] = new State(new int[]{94,970,5,510,10,-917,9,-917},new int[]{-307,499});
    states[499] = new State(new int[]{10,502,9,-905},new int[]{-314,500});
    states[500] = new State(new int[]{9,501});
    states[501] = new State(-709);
    states[502] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-309,503,-310,877,-143,506,-132,753,-136,24,-137,27});
    states[503] = new State(new int[]{10,504,9,-906});
    states[504] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-310,505,-143,506,-132,753,-136,24,-137,27});
    states[505] = new State(-915);
    states[506] = new State(new int[]{94,508,5,510,10,-917,9,-917},new int[]{-307,507});
    states[507] = new State(-916);
    states[508] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-132,509,-136,24,-137,27});
    states[509] = new State(-333);
    states[510] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-259,511,-260,395,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[511] = new State(-918);
    states[512] = new State(-258);
    states[513] = new State(new int[]{55,514});
    states[514] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-260,515,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[515] = new State(-269);
    states[516] = new State(-259);
    states[517] = new State(new int[]{55,518,115,-271,94,-271,114,-271,9,-271,10,-271,121,-271,104,-271,86,-271,92,-271,95,-271,30,-271,98,-271,29,-271,12,-271,93,-271,81,-271,80,-271,2,-271,79,-271,78,-271,77,-271,76,-271,131,-271});
    states[518] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-260,519,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[519] = new State(-270);
    states[520] = new State(-260);
    states[521] = new State(new int[]{55,522});
    states[522] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-260,523,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[523] = new State(-261);
    states[524] = new State(new int[]{21,399,45,407,46,513,31,517,71,521},new int[]{-266,525,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520});
    states[525] = new State(-255);
    states[526] = new State(-219);
    states[527] = new State(-273);
    states[528] = new State(-274);
    states[529] = new State(new int[]{8,531,115,-452,94,-452,114,-452,9,-452,10,-452,121,-452,104,-452,86,-452,92,-452,95,-452,30,-452,98,-452,29,-452,12,-452,93,-452,81,-452,80,-452,2,-452,79,-452,78,-452,77,-452,76,-452,131,-452},new int[]{-113,530});
    states[530] = new State(-275);
    states[531] = new State(new int[]{9,532,11,1016,137,-200,80,-200,81,-200,75,-200,73,-200,50,-200,26,-200,102,-200},new int[]{-114,533,-52,1034,-6,537,-234,1033});
    states[532] = new State(-453);
    states[533] = new State(new int[]{9,534,10,535});
    states[534] = new State(-454);
    states[535] = new State(new int[]{11,1016,137,-200,80,-200,81,-200,75,-200,73,-200,50,-200,26,-200,102,-200},new int[]{-52,536,-6,537,-234,1033});
    states[536] = new State(-456);
    states[537] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,50,1000,26,1006,102,1012,11,1016},new int[]{-280,538,-234,423,-144,539,-120,999,-132,998,-136,24,-137,27});
    states[538] = new State(-457);
    states[539] = new State(new int[]{5,540,94,996});
    states[540] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-259,541,-260,395,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[541] = new State(new int[]{104,542,9,-458,10,-458});
    states[542] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,5,642},new int[]{-81,543,-91,127,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641});
    states[543] = new State(-462);
    states[544] = new State(-739);
    states[545] = new State(-740);
    states[546] = new State(new int[]{11,547});
    states[547] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,551,18,247,19,252,5,642,34,863,41,878},new int[]{-66,548,-82,550,-81,126,-91,127,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,454,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641,-305,936,-306,937});
    states[548] = new State(new int[]{12,549,94,452});
    states[549] = new State(-742);
    states[550] = new State(-574);
    states[551] = new State(new int[]{9,973,53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,5,642},new int[]{-81,494,-91,552,-132,977,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641});
    states[552] = new State(new int[]{94,553,13,128,9,-580});
    states[553] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-73,554,-91,972,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623});
    states[554] = new State(new int[]{94,970,5,510,10,-917,9,-917},new int[]{-307,555});
    states[555] = new State(new int[]{10,502,9,-905},new int[]{-314,556});
    states[556] = new State(new int[]{9,557});
    states[557] = new State(new int[]{5,956,7,-709,132,-709,130,-709,112,-709,111,-709,125,-709,126,-709,127,-709,128,-709,124,-709,110,-709,109,-709,122,-709,123,-709,120,-709,114,-709,119,-709,117,-709,115,-709,118,-709,116,-709,131,-709,16,-709,13,-709,86,-709,10,-709,92,-709,95,-709,30,-709,98,-709,29,-709,94,-709,12,-709,9,-709,93,-709,81,-709,80,-709,2,-709,79,-709,78,-709,77,-709,76,-709,113,-709,121,-919},new int[]{-318,558,-308,559});
    states[558] = new State(-903);
    states[559] = new State(new int[]{121,560});
    states[560] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,85,116,37,627,51,705,91,700,32,710,33,736,70,768,22,683,96,726,57,776,72,828,44,733},new int[]{-311,561,-91,457,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-313,624,-239,625,-138,626,-301,763,-231,764,-109,765,-108,766,-110,767,-32,824,-286,825,-154,826,-111,827,-232,829});
    states[561] = new State(-907);
    states[562] = new State(new int[]{7,563,132,-717,130,-717,112,-717,111,-717,125,-717,126,-717,127,-717,128,-717,124,-717,5,-717,110,-717,109,-717,122,-717,123,-717,120,-717,114,-717,119,-717,117,-717,115,-717,118,-717,116,-717,131,-717,16,-717,13,-717,86,-717,10,-717,92,-717,95,-717,30,-717,98,-717,29,-717,94,-717,12,-717,9,-717,93,-717,81,-717,80,-717,2,-717,79,-717,78,-717,77,-717,76,-717,113,-717,6,-717,48,-717,55,-717,135,-717,137,-717,75,-717,73,-717,42,-717,39,-717,8,-717,18,-717,19,-717,138,-717,140,-717,139,-717,148,-717,150,-717,149,-717,54,-717,85,-717,37,-717,22,-717,91,-717,51,-717,32,-717,52,-717,96,-717,44,-717,33,-717,50,-717,57,-717,72,-717,70,-717,35,-717,68,-717,69,-717});
    states[563] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,79,32,78,33,77,34,76,35,66,36,61,37,122,38,19,39,18,40,60,41,20,42,123,43,124,44,125,45,126,46,127,47,128,48,129,49,130,50,131,51,132,52,21,53,71,54,85,55,22,56,23,57,26,58,27,59,28,60,69,61,93,62,29,63,30,64,31,65,24,66,98,67,95,68,32,69,33,70,34,71,37,72,38,73,39,74,97,75,40,76,41,77,43,78,44,79,45,80,91,81,46,82,96,83,47,84,25,85,48,86,68,87,92,88,49,89,50,90,51,91,52,92,53,93,54,94,55,95,56,96,58,97,99,98,100,99,103,100,101,101,102,102,59,103,72,104,35,105,36,106,42,461},new int[]{-133,564,-132,565,-136,24,-137,27,-277,566,-135,31,-177,567});
    states[564] = new State(-746);
    states[565] = new State(-776);
    states[566] = new State(-777);
    states[567] = new State(-778);
    states[568] = new State(-724);
    states[569] = new State(-696);
    states[570] = new State(-697);
    states[571] = new State(new int[]{113,572});
    states[572] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,29,42,461,39,491,8,493,18,247,19,252},new int[]{-88,573,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568});
    states[573] = new State(-694);
    states[574] = new State(-700);
    states[575] = new State(new int[]{8,576,132,-689,130,-689,112,-689,111,-689,125,-689,126,-689,127,-689,128,-689,124,-689,5,-689,110,-689,109,-689,122,-689,123,-689,120,-689,114,-689,119,-689,117,-689,115,-689,118,-689,116,-689,131,-689,16,-689,13,-689,86,-689,10,-689,92,-689,95,-689,30,-689,98,-689,29,-689,94,-689,12,-689,9,-689,93,-689,81,-689,80,-689,2,-689,79,-689,78,-689,77,-689,76,-689,6,-689,48,-689,55,-689,135,-689,137,-689,75,-689,73,-689,42,-689,39,-689,18,-689,19,-689,138,-689,140,-689,139,-689,148,-689,150,-689,149,-689,54,-689,85,-689,37,-689,22,-689,91,-689,51,-689,32,-689,52,-689,96,-689,44,-689,33,-689,50,-689,57,-689,72,-689,70,-689,35,-689,68,-689,69,-689});
    states[576] = new State(new int[]{14,581,138,149,140,150,139,152,148,154,150,155,149,156,50,583,137,23,80,25,81,26,75,28,73,29,11,334,8,608},new int[]{-336,577,-333,621,-14,582,-150,146,-152,147,-151,151,-15,153,-322,599,-268,600,-166,162,-132,196,-136,24,-137,27,-325,606,-326,607});
    states[577] = new State(new int[]{9,578,10,579,94,604});
    states[578] = new State(-610);
    states[579] = new State(new int[]{14,581,138,149,140,150,139,152,148,154,150,155,149,156,50,583,137,23,80,25,81,26,75,28,73,29,11,334,8,608},new int[]{-333,580,-14,582,-150,146,-152,147,-151,151,-15,153,-322,599,-268,600,-166,162,-132,196,-136,24,-137,27,-325,606,-326,607});
    states[580] = new State(-643);
    states[581] = new State(-645);
    states[582] = new State(-646);
    states[583] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-132,584,-136,24,-137,27});
    states[584] = new State(new int[]{5,585,9,-648,10,-648,94,-648});
    states[585] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-260,586,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[586] = new State(-647);
    states[587] = new State(new int[]{8,531,5,-452},new int[]{-113,588});
    states[588] = new State(new int[]{5,589});
    states[589] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-259,590,-260,395,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[590] = new State(-276);
    states[591] = new State(new int[]{121,592,114,-220,94,-220,9,-220,10,-220,115,-220,104,-220,86,-220,92,-220,95,-220,30,-220,98,-220,29,-220,12,-220,93,-220,81,-220,80,-220,2,-220,79,-220,78,-220,77,-220,76,-220,131,-220});
    states[592] = new State(new int[]{8,594,137,23,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-263,593,-256,173,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-265,596,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,597,-209,527,-208,528,-285,598});
    states[593] = new State(-278);
    states[594] = new State(new int[]{9,595,137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-74,278,-72,284,-260,287,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[595] = new State(new int[]{121,274,115,-282,94,-282,114,-282,9,-282,10,-282,104,-282,86,-282,92,-282,95,-282,30,-282,98,-282,29,-282,12,-282,93,-282,81,-282,80,-282,2,-282,79,-282,78,-282,77,-282,76,-282,131,-282});
    states[596] = new State(-232);
    states[597] = new State(-233);
    states[598] = new State(new int[]{121,592,115,-234,94,-234,114,-234,9,-234,10,-234,104,-234,86,-234,92,-234,95,-234,30,-234,98,-234,29,-234,12,-234,93,-234,81,-234,80,-234,2,-234,79,-234,78,-234,77,-234,76,-234,131,-234});
    states[599] = new State(-649);
    states[600] = new State(new int[]{8,601});
    states[601] = new State(new int[]{14,581,138,149,140,150,139,152,148,154,150,155,149,156,50,583,137,23,80,25,81,26,75,28,73,29,11,334,8,608},new int[]{-336,602,-333,621,-14,582,-150,146,-152,147,-151,151,-15,153,-322,599,-268,600,-166,162,-132,196,-136,24,-137,27,-325,606,-326,607});
    states[602] = new State(new int[]{9,603,10,579,94,604});
    states[603] = new State(-613);
    states[604] = new State(new int[]{14,581,138,149,140,150,139,152,148,154,150,155,149,156,50,583,137,23,80,25,81,26,75,28,73,29,11,334,8,608},new int[]{-333,605,-14,582,-150,146,-152,147,-151,151,-15,153,-322,599,-268,600,-166,162,-132,196,-136,24,-137,27,-325,606,-326,607});
    states[605] = new State(-644);
    states[606] = new State(-650);
    states[607] = new State(-651);
    states[608] = new State(new int[]{14,613,138,149,140,150,139,152,148,154,150,155,149,156,50,615,137,23,80,25,81,26,75,28,73,29,11,334,8,608},new int[]{-339,609,-328,620,-14,614,-150,146,-152,147,-151,151,-15,153,-323,617,-268,345,-166,162,-132,196,-136,24,-137,27,-325,618,-326,619});
    states[609] = new State(new int[]{9,610,94,611});
    states[610] = new State(-630);
    states[611] = new State(new int[]{14,613,138,149,140,150,139,152,148,154,150,155,149,156,50,615,137,23,80,25,81,26,75,28,73,29,11,334,8,608},new int[]{-328,612,-14,614,-150,146,-152,147,-151,151,-15,153,-323,617,-268,345,-166,162,-132,196,-136,24,-137,27,-325,618,-326,619});
    states[612] = new State(-638);
    states[613] = new State(-631);
    states[614] = new State(-632);
    states[615] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-132,616,-136,24,-137,27});
    states[616] = new State(-633);
    states[617] = new State(-634);
    states[618] = new State(-635);
    states[619] = new State(-636);
    states[620] = new State(-637);
    states[621] = new State(-642);
    states[622] = new State(-690);
    states[623] = new State(-583);
    states[624] = new State(-934);
    states[625] = new State(-921);
    states[626] = new State(-922);
    states[627] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-91,628,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623});
    states[628] = new State(new int[]{48,629,13,128});
    states[629] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,86,-476,10,-476,92,-476,95,-476,30,-476,98,-476,29,-476,94,-476,12,-476,9,-476,93,-476,2,-476,79,-476,78,-476,77,-476,76,-476},new int[]{-244,630,-4,122,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787});
    states[630] = new State(new int[]{29,631,86,-515,10,-515,92,-515,95,-515,30,-515,98,-515,94,-515,12,-515,9,-515,93,-515,81,-515,80,-515,2,-515,79,-515,78,-515,77,-515,76,-515});
    states[631] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,86,-476,10,-476,92,-476,95,-476,30,-476,98,-476,29,-476,94,-476,12,-476,9,-476,93,-476,2,-476,79,-476,78,-476,77,-476,76,-476},new int[]{-244,632,-4,122,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787});
    states[632] = new State(-516);
    states[633] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,86,-556,10,-556,92,-556,95,-556,30,-556,98,-556,29,-556,94,-556,12,-556,9,-556,93,-556,2,-556,79,-556,78,-556,77,-556,76,-556},new int[]{-132,492,-136,24,-137,27});
    states[634] = new State(new int[]{50,661,53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,5,642},new int[]{-81,494,-91,496,-99,635,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641});
    states[635] = new State(new int[]{94,636,17,437,8,448,7,650,136,652,4,653,15,658,132,-723,130,-723,112,-723,111,-723,125,-723,126,-723,127,-723,128,-723,124,-723,5,-723,110,-723,109,-723,122,-723,123,-723,120,-723,114,-723,119,-723,117,-723,115,-723,118,-723,116,-723,131,-723,16,-723,13,-723,9,-723,113,-723,11,-733});
    states[636] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,42,461,39,491,8,493,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156},new int[]{-319,637,-99,657,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656});
    states[637] = new State(new int[]{9,638,94,648});
    states[638] = new State(new int[]{104,485,105,486,106,487,107,488,108,489},new int[]{-180,639});
    states[639] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,5,642},new int[]{-81,640,-91,127,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641});
    states[640] = new State(-505);
    states[641] = new State(-581);
    states[642] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,5,-662,86,-662,10,-662,92,-662,95,-662,30,-662,98,-662,29,-662,94,-662,12,-662,9,-662,93,-662,2,-662,79,-662,78,-662,77,-662,76,-662,6,-662},new int[]{-102,643,-93,647,-76,308,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,646,-251,622});
    states[643] = new State(new int[]{5,644,86,-666,10,-666,92,-666,95,-666,30,-666,98,-666,29,-666,94,-666,12,-666,9,-666,93,-666,81,-666,80,-666,2,-666,79,-666,78,-666,77,-666,76,-666,6,-666});
    states[644] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-93,645,-76,308,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,646,-251,622});
    states[645] = new State(new int[]{110,303,109,304,122,305,123,306,120,307,86,-668,10,-668,92,-668,95,-668,30,-668,98,-668,29,-668,94,-668,12,-668,9,-668,93,-668,81,-668,80,-668,2,-668,79,-668,78,-668,77,-668,76,-668,6,-668},new int[]{-183,137});
    states[646] = new State(-689);
    states[647] = new State(new int[]{110,303,109,304,122,305,123,306,120,307,5,-661,86,-661,10,-661,92,-661,95,-661,30,-661,98,-661,29,-661,94,-661,12,-661,9,-661,93,-661,81,-661,80,-661,2,-661,79,-661,78,-661,77,-661,76,-661,6,-661},new int[]{-183,137});
    states[648] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,42,461,39,491,8,493,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156},new int[]{-99,649,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656});
    states[649] = new State(new int[]{17,437,8,448,7,650,136,652,4,653,9,-507,94,-507,11,-733});
    states[650] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,79,32,78,33,77,34,76,35,66,36,61,37,122,38,19,39,18,40,60,41,20,42,123,43,124,44,125,45,126,46,127,47,128,48,129,49,130,50,131,51,132,52,21,53,71,54,85,55,22,56,23,57,26,58,27,59,28,60,69,61,93,62,29,63,30,64,31,65,24,66,98,67,95,68,32,69,33,70,34,71,37,72,38,73,39,74,97,75,40,76,41,77,43,78,44,79,45,80,91,81,46,82,96,83,47,84,25,85,48,86,68,87,92,88,49,89,50,90,51,91,52,92,53,93,54,94,55,95,56,96,58,97,99,98,100,99,103,100,101,101,102,102,59,103,72,104,35,105,36,106,42,461},new int[]{-133,651,-132,565,-136,24,-137,27,-277,566,-135,31,-177,567});
    states[651] = new State(-745);
    states[652] = new State(-747);
    states[653] = new State(new int[]{117,168},new int[]{-283,654});
    states[654] = new State(-748);
    states[655] = new State(new int[]{7,144,11,-734});
    states[656] = new State(new int[]{7,563});
    states[657] = new State(new int[]{17,437,8,448,7,650,136,652,4,653,9,-506,94,-506,11,-733});
    states[658] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,42,461,39,491,8,493,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156},new int[]{-99,659,-103,660,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656});
    states[659] = new State(new int[]{17,437,8,448,7,650,136,652,4,653,15,658,104,-720,105,-720,106,-720,107,-720,108,-720,86,-720,10,-720,92,-720,95,-720,30,-720,98,-720,132,-720,130,-720,112,-720,111,-720,125,-720,126,-720,127,-720,128,-720,124,-720,5,-720,110,-720,109,-720,122,-720,123,-720,120,-720,114,-720,119,-720,117,-720,115,-720,118,-720,116,-720,131,-720,16,-720,13,-720,29,-720,94,-720,12,-720,9,-720,93,-720,81,-720,80,-720,2,-720,79,-720,78,-720,77,-720,76,-720,113,-720,6,-720,48,-720,55,-720,135,-720,137,-720,75,-720,73,-720,42,-720,39,-720,18,-720,19,-720,138,-720,140,-720,139,-720,148,-720,150,-720,149,-720,54,-720,85,-720,37,-720,22,-720,91,-720,51,-720,32,-720,52,-720,96,-720,44,-720,33,-720,50,-720,57,-720,72,-720,70,-720,35,-720,68,-720,69,-720,11,-733});
    states[660] = new State(-721);
    states[661] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-132,662,-136,24,-137,27});
    states[662] = new State(new int[]{94,663});
    states[663] = new State(new int[]{50,671},new int[]{-320,664});
    states[664] = new State(new int[]{9,665,94,668});
    states[665] = new State(new int[]{104,666});
    states[666] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,5,642},new int[]{-81,667,-91,127,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641});
    states[667] = new State(-502);
    states[668] = new State(new int[]{50,669});
    states[669] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-132,670,-136,24,-137,27});
    states[670] = new State(-509);
    states[671] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-132,672,-136,24,-137,27});
    states[672] = new State(-508);
    states[673] = new State(-478);
    states[674] = new State(-479);
    states[675] = new State(new int[]{148,677,149,678,137,23,80,25,81,26,75,28,73,29},new int[]{-128,676,-132,679,-136,24,-137,27});
    states[676] = new State(-511);
    states[677] = new State(-92);
    states[678] = new State(-93);
    states[679] = new State(-94);
    states[680] = new State(-480);
    states[681] = new State(-481);
    states[682] = new State(-482);
    states[683] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-91,684,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623});
    states[684] = new State(new int[]{55,685,13,128});
    states[685] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,370,129,373,110,377,109,378,29,693,86,-536},new int[]{-33,686,-237,953,-246,955,-68,946,-98,952,-86,951,-83,186,-75,191,-12,215,-10,225,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379,-249,380,-253,381,-226,382});
    states[686] = new State(new int[]{10,689,29,693,86,-536},new int[]{-237,687});
    states[687] = new State(new int[]{86,688});
    states[688] = new State(-527);
    states[689] = new State(new int[]{29,693,137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,370,129,373,110,377,109,378,86,-536},new int[]{-237,690,-246,692,-68,946,-98,952,-86,951,-83,186,-75,191,-12,215,-10,225,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379,-249,380,-253,381,-226,382});
    states[690] = new State(new int[]{86,691});
    states[691] = new State(-528);
    states[692] = new State(-531);
    states[693] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,697,150,155,149,698,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,10,-476,86,-476},new int[]{-236,694,-245,695,-244,121,-4,122,-100,123,-117,435,-99,447,-132,696,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787,-128,911});
    states[694] = new State(new int[]{10,119,86,-537});
    states[695] = new State(-513);
    states[696] = new State(new int[]{17,-735,8,-735,7,-735,136,-735,4,-735,15,-735,104,-735,105,-735,106,-735,107,-735,108,-735,86,-735,10,-735,11,-735,92,-735,95,-735,30,-735,98,-735,5,-94});
    states[697] = new State(new int[]{7,-177,11,-177,5,-92});
    states[698] = new State(new int[]{7,-179,11,-179,5,-93});
    states[699] = new State(-483);
    states[700] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,697,150,155,149,698,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,92,-476,10,-476},new int[]{-236,701,-245,695,-244,121,-4,122,-100,123,-117,435,-99,447,-132,696,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787,-128,911});
    states[701] = new State(new int[]{92,702,10,119});
    states[702] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,5,642},new int[]{-81,703,-91,127,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641});
    states[703] = new State(-538);
    states[704] = new State(-484);
    states[705] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-91,706,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623});
    states[706] = new State(new int[]{13,128,93,938,135,-541,137,-541,80,-541,81,-541,75,-541,73,-541,42,-541,39,-541,8,-541,18,-541,19,-541,138,-541,140,-541,139,-541,148,-541,150,-541,149,-541,54,-541,85,-541,37,-541,22,-541,91,-541,51,-541,32,-541,52,-541,96,-541,44,-541,33,-541,50,-541,57,-541,72,-541,70,-541,35,-541,86,-541,10,-541,92,-541,95,-541,30,-541,98,-541,29,-541,94,-541,12,-541,9,-541,2,-541,79,-541,78,-541,77,-541,76,-541},new int[]{-276,707});
    states[707] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,86,-476,10,-476,92,-476,95,-476,30,-476,98,-476,29,-476,94,-476,12,-476,9,-476,93,-476,2,-476,79,-476,78,-476,77,-476,76,-476},new int[]{-244,708,-4,122,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787});
    states[708] = new State(-539);
    states[709] = new State(-485);
    states[710] = new State(new int[]{50,945,137,-550,80,-550,81,-550,75,-550,73,-550},new int[]{-18,711});
    states[711] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-132,712,-136,24,-137,27});
    states[712] = new State(new int[]{104,941,5,942},new int[]{-270,713});
    states[713] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-91,714,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623});
    states[714] = new State(new int[]{13,128,68,939,69,940},new int[]{-104,715});
    states[715] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-91,716,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623});
    states[716] = new State(new int[]{13,128,93,938,135,-541,137,-541,80,-541,81,-541,75,-541,73,-541,42,-541,39,-541,8,-541,18,-541,19,-541,138,-541,140,-541,139,-541,148,-541,150,-541,149,-541,54,-541,85,-541,37,-541,22,-541,91,-541,51,-541,32,-541,52,-541,96,-541,44,-541,33,-541,50,-541,57,-541,72,-541,70,-541,35,-541,86,-541,10,-541,92,-541,95,-541,30,-541,98,-541,29,-541,94,-541,12,-541,9,-541,2,-541,79,-541,78,-541,77,-541,76,-541},new int[]{-276,717});
    states[717] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,86,-476,10,-476,92,-476,95,-476,30,-476,98,-476,29,-476,94,-476,12,-476,9,-476,93,-476,2,-476,79,-476,78,-476,77,-476,76,-476},new int[]{-244,718,-4,122,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787});
    states[718] = new State(-548);
    states[719] = new State(-486);
    states[720] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,551,18,247,19,252,5,642,34,863,41,878},new int[]{-66,721,-82,550,-81,126,-91,127,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,454,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641,-305,936,-306,937});
    states[721] = new State(new int[]{93,722,94,452});
    states[722] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,86,-476,10,-476,92,-476,95,-476,30,-476,98,-476,29,-476,94,-476,12,-476,9,-476,93,-476,2,-476,79,-476,78,-476,77,-476,76,-476},new int[]{-244,723,-4,122,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787});
    states[723] = new State(-555);
    states[724] = new State(-487);
    states[725] = new State(-488);
    states[726] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,697,150,155,149,698,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,10,-476,95,-476,30,-476},new int[]{-236,727,-245,695,-244,121,-4,122,-100,123,-117,435,-99,447,-132,696,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787,-128,911});
    states[727] = new State(new int[]{10,119,95,729,30,914},new int[]{-274,728});
    states[728] = new State(-557);
    states[729] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,697,150,155,149,698,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,86,-476,10,-476},new int[]{-236,730,-245,695,-244,121,-4,122,-100,123,-117,435,-99,447,-132,696,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787,-128,911});
    states[730] = new State(new int[]{86,731,10,119});
    states[731] = new State(-558);
    states[732] = new State(-489);
    states[733] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,5,642,86,-572,10,-572,92,-572,95,-572,30,-572,98,-572,29,-572,94,-572,12,-572,9,-572,93,-572,2,-572,79,-572,78,-572,77,-572,76,-572},new int[]{-81,734,-91,127,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641});
    states[734] = new State(-573);
    states[735] = new State(-490);
    states[736] = new State(new int[]{50,899,137,23,80,25,81,26,75,28,73,29},new int[]{-132,737,-136,24,-137,27});
    states[737] = new State(new int[]{5,897,131,-547},new int[]{-258,738});
    states[738] = new State(new int[]{131,739});
    states[739] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-91,740,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623});
    states[740] = new State(new int[]{93,741,13,128});
    states[741] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,86,-476,10,-476,92,-476,95,-476,30,-476,98,-476,29,-476,94,-476,12,-476,9,-476,93,-476,2,-476,79,-476,78,-476,77,-476,76,-476},new int[]{-244,742,-4,122,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787});
    states[742] = new State(-543);
    states[743] = new State(-491);
    states[744] = new State(new int[]{8,746,137,23,80,25,81,26,75,28,73,29},new int[]{-294,745,-143,754,-132,753,-136,24,-137,27});
    states[745] = new State(-501);
    states[746] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-132,747,-136,24,-137,27});
    states[747] = new State(new int[]{94,748});
    states[748] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-143,749,-132,753,-136,24,-137,27});
    states[749] = new State(new int[]{9,750,94,508});
    states[750] = new State(new int[]{104,751});
    states[751] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,5,642},new int[]{-81,752,-91,127,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641});
    states[752] = new State(-503);
    states[753] = new State(-332);
    states[754] = new State(new int[]{5,755,94,508,104,895});
    states[755] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-260,756,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[756] = new State(new int[]{104,893,114,894,86,-396,10,-396,92,-396,95,-396,30,-396,98,-396,29,-396,94,-396,12,-396,9,-396,93,-396,81,-396,80,-396,2,-396,79,-396,78,-396,77,-396,76,-396},new int[]{-321,757});
    states[757] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,830,129,373,110,377,109,378,60,158,34,863,41,878},new int[]{-80,758,-79,759,-78,240,-83,241,-75,191,-12,215,-10,225,-13,201,-132,760,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379,-249,380,-253,381,-226,382,-87,858,-227,859,-53,851,-306,862});
    states[758] = new State(-398);
    states[759] = new State(-399);
    states[760] = new State(new int[]{121,761,4,-156,11,-156,7,-156,136,-156,8,-156,113,-156,130,-156,132,-156,112,-156,111,-156,125,-156,126,-156,127,-156,128,-156,124,-156,110,-156,109,-156,122,-156,123,-156,114,-156,119,-156,117,-156,115,-156,118,-156,116,-156,131,-156,13,-156,86,-156,10,-156,92,-156,95,-156,30,-156,98,-156,29,-156,94,-156,12,-156,9,-156,93,-156,81,-156,80,-156,2,-156,79,-156,78,-156,77,-156,76,-156});
    states[761] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,85,116,37,627,51,705,91,700,32,710,33,736,70,768,22,683,96,726,57,776,72,828,44,733},new int[]{-311,762,-91,457,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-313,624,-239,625,-138,626,-301,763,-231,764,-109,765,-108,766,-110,767,-32,824,-286,825,-154,826,-111,827,-232,829});
    states[762] = new State(-401);
    states[763] = new State(-923);
    states[764] = new State(-924);
    states[765] = new State(-925);
    states[766] = new State(-926);
    states[767] = new State(-927);
    states[768] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-91,769,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623});
    states[769] = new State(new int[]{93,770,13,128});
    states[770] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,86,-476,10,-476,92,-476,95,-476,30,-476,98,-476,29,-476,94,-476,12,-476,9,-476,93,-476,2,-476,79,-476,78,-476,77,-476,76,-476},new int[]{-244,771,-4,122,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787});
    states[771] = new State(-498);
    states[772] = new State(-492);
    states[773] = new State(-576);
    states[774] = new State(-577);
    states[775] = new State(-493);
    states[776] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-91,777,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623});
    states[777] = new State(new int[]{93,778,13,128});
    states[778] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,86,-476,10,-476,92,-476,95,-476,30,-476,98,-476,29,-476,94,-476,12,-476,9,-476,93,-476,2,-476,79,-476,78,-476,77,-476,76,-476},new int[]{-244,779,-4,122,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787});
    states[779] = new State(-542);
    states[780] = new State(-494);
    states[781] = new State(new int[]{71,783,53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-91,782,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623});
    states[782] = new State(new int[]{13,128,86,-499,10,-499,92,-499,95,-499,30,-499,98,-499,29,-499,94,-499,12,-499,9,-499,93,-499,81,-499,80,-499,2,-499,79,-499,78,-499,77,-499,76,-499});
    states[783] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-91,784,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623});
    states[784] = new State(new int[]{13,128,86,-500,10,-500,92,-500,95,-500,30,-500,98,-500,29,-500,94,-500,12,-500,9,-500,93,-500,81,-500,80,-500,2,-500,79,-500,78,-500,77,-500,76,-500});
    states[785] = new State(-495);
    states[786] = new State(-496);
    states[787] = new State(-497);
    states[788] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-91,789,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623});
    states[789] = new State(new int[]{52,790,13,128});
    states[790] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,138,149,140,150,139,152,148,154,150,155,149,156,11,334,8,608},new int[]{-332,791,-331,823,-323,798,-268,345,-166,162,-132,196,-136,24,-137,27,-324,805,-335,812,-340,816,-14,815,-150,146,-152,147,-151,151,-15,153,-325,817,-326,820});
    states[791] = new State(new int[]{10,794,29,693,86,-536},new int[]{-237,792});
    states[792] = new State(new int[]{86,793});
    states[793] = new State(-517);
    states[794] = new State(new int[]{29,693,137,23,80,25,81,26,75,28,73,29,138,149,140,150,139,152,148,154,150,155,149,156,11,334,8,608,86,-536},new int[]{-237,795,-331,797,-323,798,-268,345,-166,162,-132,196,-136,24,-137,27,-324,805,-335,812,-340,816,-14,815,-150,146,-152,147,-151,151,-15,153,-325,817,-326,820});
    states[795] = new State(new int[]{86,796});
    states[796] = new State(-518);
    states[797] = new State(-520);
    states[798] = new State(new int[]{36,799,5,803});
    states[799] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-91,800,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623});
    states[800] = new State(new int[]{5,801,13,128});
    states[801] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,10,-476,29,-476,86,-476},new int[]{-244,802,-4,122,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787});
    states[802] = new State(-521);
    states[803] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,10,-476,29,-476,86,-476},new int[]{-244,804,-4,122,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787});
    states[804] = new State(-522);
    states[805] = new State(new int[]{36,806,5,810});
    states[806] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-91,807,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623});
    states[807] = new State(new int[]{5,808,13,128});
    states[808] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,10,-476,29,-476,86,-476},new int[]{-244,809,-4,122,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787});
    states[809] = new State(-523);
    states[810] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,10,-476,29,-476,86,-476},new int[]{-244,811,-4,122,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787});
    states[811] = new State(-524);
    states[812] = new State(new int[]{94,813,36,-626,5,-626});
    states[813] = new State(new int[]{138,149,140,150,139,152,148,154,150,155,149,156},new int[]{-340,814,-14,815,-150,146,-152,147,-151,151,-15,153});
    states[814] = new State(-628);
    states[815] = new State(-629);
    states[816] = new State(-627);
    states[817] = new State(new int[]{5,818});
    states[818] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,10,-476,29,-476,86,-476},new int[]{-244,819,-4,122,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787});
    states[819] = new State(-525);
    states[820] = new State(new int[]{5,821});
    states[821] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,10,-476,29,-476,86,-476},new int[]{-244,822,-4,122,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787});
    states[822] = new State(-526);
    states[823] = new State(-519);
    states[824] = new State(-928);
    states[825] = new State(-929);
    states[826] = new State(-930);
    states[827] = new State(-931);
    states[828] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-91,782,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623});
    states[829] = new State(-932);
    states[830] = new State(new int[]{9,842,137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,847,129,373,110,377,109,378,60,158},new int[]{-83,831,-62,832,-227,836,-87,838,-229,840,-75,191,-12,215,-10,225,-13,201,-132,846,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379,-249,380,-253,381,-226,382,-61,237,-79,850,-78,240,-53,851,-228,852,-230,861,-121,855});
    states[831] = new State(new int[]{9,372,13,187,94,-180});
    states[832] = new State(new int[]{9,833});
    states[833] = new State(new int[]{121,834,86,-183,10,-183,92,-183,95,-183,30,-183,98,-183,29,-183,94,-183,12,-183,9,-183,93,-183,81,-183,80,-183,2,-183,79,-183,78,-183,77,-183,76,-183});
    states[834] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,85,116,37,627,51,705,91,700,32,710,33,736,70,768,22,683,96,726,57,776,72,828,44,733},new int[]{-311,835,-91,457,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-313,624,-239,625,-138,626,-301,763,-231,764,-109,765,-108,766,-110,767,-32,824,-286,825,-154,826,-111,827,-232,829});
    states[835] = new State(-403);
    states[836] = new State(new int[]{9,837,94,-182});
    states[837] = new State(-184);
    states[838] = new State(new int[]{9,839,94,-181});
    states[839] = new State(-185);
    states[840] = new State(new int[]{9,841});
    states[841] = new State(-190);
    states[842] = new State(new int[]{5,510,121,-917},new int[]{-307,843});
    states[843] = new State(new int[]{121,844});
    states[844] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,85,116,37,627,51,705,91,700,32,710,33,736,70,768,22,683,96,726,57,776,72,828,44,733},new int[]{-311,845,-91,457,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-313,624,-239,625,-138,626,-301,763,-231,764,-109,765,-108,766,-110,767,-32,824,-286,825,-154,826,-111,827,-232,829});
    states[845] = new State(-402);
    states[846] = new State(new int[]{4,-156,11,-156,7,-156,136,-156,8,-156,113,-156,130,-156,132,-156,112,-156,111,-156,125,-156,126,-156,127,-156,128,-156,124,-156,110,-156,109,-156,122,-156,123,-156,114,-156,119,-156,117,-156,115,-156,118,-156,116,-156,131,-156,9,-156,13,-156,94,-156,5,-196});
    states[847] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,847,129,373,110,377,109,378,60,158,9,-186},new int[]{-83,831,-62,848,-227,836,-87,838,-229,840,-75,191,-12,215,-10,225,-13,201,-132,846,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379,-249,380,-253,381,-226,382,-61,237,-79,850,-78,240,-53,851,-228,852,-230,861,-121,855});
    states[848] = new State(new int[]{9,849});
    states[849] = new State(-183);
    states[850] = new State(-188);
    states[851] = new State(-405);
    states[852] = new State(new int[]{10,853,9,-191});
    states[853] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,9,-192},new int[]{-230,854,-121,855,-132,860,-136,24,-137,27});
    states[854] = new State(-194);
    states[855] = new State(new int[]{5,856});
    states[856] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,847,129,373,110,377,109,378},new int[]{-78,857,-83,241,-75,191,-12,215,-10,225,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379,-249,380,-253,381,-226,382,-87,858,-227,859});
    states[857] = new State(-195);
    states[858] = new State(-181);
    states[859] = new State(-182);
    states[860] = new State(-196);
    states[861] = new State(-193);
    states[862] = new State(-400);
    states[863] = new State(new int[]{8,867,5,510,121,-917},new int[]{-307,864});
    states[864] = new State(new int[]{121,865});
    states[865] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,85,116,37,627,51,705,91,700,32,710,33,736,70,768,22,683,96,726,57,776,72,828,44,733},new int[]{-311,866,-91,457,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-313,624,-239,625,-138,626,-301,763,-231,764,-109,765,-108,766,-110,767,-32,824,-286,825,-154,826,-111,827,-232,829});
    states[866] = new State(-908);
    states[867] = new State(new int[]{9,868,137,23,80,25,81,26,75,28,73,29},new int[]{-309,872,-310,877,-143,506,-132,753,-136,24,-137,27});
    states[868] = new State(new int[]{5,510,121,-917},new int[]{-307,869});
    states[869] = new State(new int[]{121,870});
    states[870] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,85,116,37,627,51,705,91,700,32,710,33,736,70,768,22,683,96,726,57,776,72,828,44,733},new int[]{-311,871,-91,457,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-313,624,-239,625,-138,626,-301,763,-231,764,-109,765,-108,766,-110,767,-32,824,-286,825,-154,826,-111,827,-232,829});
    states[871] = new State(-909);
    states[872] = new State(new int[]{9,873,10,504});
    states[873] = new State(new int[]{5,510,121,-917},new int[]{-307,874});
    states[874] = new State(new int[]{121,875});
    states[875] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,85,116,37,627,51,705,91,700,32,710,33,736,70,768,22,683,96,726,57,776,72,828,44,733},new int[]{-311,876,-91,457,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-313,624,-239,625,-138,626,-301,763,-231,764,-109,765,-108,766,-110,767,-32,824,-286,825,-154,826,-111,827,-232,829});
    states[876] = new State(-910);
    states[877] = new State(-914);
    states[878] = new State(new int[]{121,879,8,885});
    states[879] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,29,42,461,39,491,8,882,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,85,116,37,627,51,705,91,700,32,710,33,736,70,768,22,683,96,726,57,776,72,828,44,733},new int[]{-312,880,-197,881,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-4,883,-313,884,-239,625,-138,626,-301,763,-231,764,-109,765,-108,766,-110,767,-32,824,-286,825,-154,826,-111,827,-232,829});
    states[880] = new State(-911);
    states[881] = new State(-935);
    states[882] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,5,642},new int[]{-81,494,-91,496,-99,635,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641});
    states[883] = new State(-936);
    states[884] = new State(-937);
    states[885] = new State(new int[]{9,886,137,23,80,25,81,26,75,28,73,29},new int[]{-309,889,-310,877,-143,506,-132,753,-136,24,-137,27});
    states[886] = new State(new int[]{121,887});
    states[887] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,29,42,461,39,491,8,882,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,85,116,37,627,51,705,91,700,32,710,33,736,70,768,22,683,96,726,57,776,72,828,44,733},new int[]{-312,888,-197,881,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-4,883,-313,884,-239,625,-138,626,-301,763,-231,764,-109,765,-108,766,-110,767,-32,824,-286,825,-154,826,-111,827,-232,829});
    states[888] = new State(-912);
    states[889] = new State(new int[]{9,890,10,504});
    states[890] = new State(new int[]{121,891});
    states[891] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,29,42,461,39,491,8,882,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,85,116,37,627,51,705,91,700,32,710,33,736,70,768,22,683,96,726,57,776,72,828,44,733},new int[]{-312,892,-197,881,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-4,883,-313,884,-239,625,-138,626,-301,763,-231,764,-109,765,-108,766,-110,767,-32,824,-286,825,-154,826,-111,827,-232,829});
    states[892] = new State(-913);
    states[893] = new State(-394);
    states[894] = new State(-395);
    states[895] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,5,642},new int[]{-81,896,-91,127,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641});
    states[896] = new State(-397);
    states[897] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-260,898,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[898] = new State(-546);
    states[899] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-132,900,-136,24,-137,27});
    states[900] = new State(new int[]{5,901,131,907});
    states[901] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-260,902,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[902] = new State(new int[]{131,903});
    states[903] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-91,904,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623});
    states[904] = new State(new int[]{93,905,13,128});
    states[905] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,86,-476,10,-476,92,-476,95,-476,30,-476,98,-476,29,-476,94,-476,12,-476,9,-476,93,-476,2,-476,79,-476,78,-476,77,-476,76,-476},new int[]{-244,906,-4,122,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787});
    states[906] = new State(-544);
    states[907] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-91,908,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623});
    states[908] = new State(new int[]{93,909,13,128});
    states[909] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,86,-476,10,-476,92,-476,95,-476,30,-476,98,-476,29,-476,94,-476,12,-476,9,-476,93,-476,2,-476,79,-476,78,-476,77,-476,76,-476},new int[]{-244,910,-4,122,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787});
    states[910] = new State(-545);
    states[911] = new State(new int[]{5,912});
    states[912] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,697,150,155,149,698,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,86,-476,10,-476,92,-476,95,-476,30,-476,98,-476},new int[]{-245,913,-244,121,-4,122,-100,123,-117,435,-99,447,-132,696,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787,-128,911});
    states[913] = new State(-475);
    states[914] = new State(new int[]{74,922,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,697,150,155,149,698,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,10,-476,86,-476},new int[]{-56,915,-59,917,-58,934,-236,935,-245,695,-244,121,-4,122,-100,123,-117,435,-99,447,-132,696,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787,-128,911});
    states[915] = new State(new int[]{86,916});
    states[916] = new State(-559);
    states[917] = new State(new int[]{10,919,29,932,86,-565},new int[]{-238,918});
    states[918] = new State(-560);
    states[919] = new State(new int[]{74,922,29,932,86,-565},new int[]{-58,920,-238,921});
    states[920] = new State(-564);
    states[921] = new State(-561);
    states[922] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-60,923,-165,926,-166,927,-132,928,-136,24,-137,27,-125,929});
    states[923] = new State(new int[]{93,924});
    states[924] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,10,-476,29,-476,86,-476},new int[]{-244,925,-4,122,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787});
    states[925] = new State(-567);
    states[926] = new State(-568);
    states[927] = new State(new int[]{7,163,93,-570});
    states[928] = new State(new int[]{7,-247,93,-247,5,-571});
    states[929] = new State(new int[]{5,930});
    states[930] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-165,931,-166,927,-132,196,-136,24,-137,27});
    states[931] = new State(-569);
    states[932] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,697,150,155,149,698,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,10,-476,86,-476},new int[]{-236,933,-245,695,-244,121,-4,122,-100,123,-117,435,-99,447,-132,696,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787,-128,911});
    states[933] = new State(new int[]{10,119,86,-566});
    states[934] = new State(-563);
    states[935] = new State(new int[]{10,119,86,-562});
    states[936] = new State(-579);
    states[937] = new State(-904);
    states[938] = new State(-540);
    states[939] = new State(-553);
    states[940] = new State(-554);
    states[941] = new State(-551);
    states[942] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-166,943,-132,196,-136,24,-137,27});
    states[943] = new State(new int[]{104,944,7,163});
    states[944] = new State(-552);
    states[945] = new State(-549);
    states[946] = new State(new int[]{5,947,94,949});
    states[947] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,10,-476,29,-476,86,-476},new int[]{-244,948,-4,122,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787});
    states[948] = new State(-532);
    states[949] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,370,129,373,110,377,109,378},new int[]{-98,950,-86,951,-83,186,-75,191,-12,215,-10,225,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379,-249,380,-253,381,-226,382});
    states[950] = new State(-534);
    states[951] = new State(-535);
    states[952] = new State(-533);
    states[953] = new State(new int[]{86,954});
    states[954] = new State(-529);
    states[955] = new State(-530);
    states[956] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,961,136,393,21,399,45,407,46,513,31,517,71,521,62,524},new int[]{-261,957,-256,958,-85,175,-94,267,-95,268,-166,959,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-240,966,-233,967,-265,968,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-285,969});
    states[957] = new State(-920);
    states[958] = new State(-469);
    states[959] = new State(new int[]{7,163,117,168,8,-242,112,-242,111,-242,125,-242,126,-242,127,-242,128,-242,124,-242,6,-242,110,-242,109,-242,122,-242,123,-242,121,-242},new int[]{-283,960});
    states[960] = new State(-221);
    states[961] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-74,962,-72,284,-260,287,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[962] = new State(new int[]{9,963,94,964});
    states[963] = new State(-237);
    states[964] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-72,965,-260,287,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[965] = new State(-250);
    states[966] = new State(-470);
    states[967] = new State(-471);
    states[968] = new State(-472);
    states[969] = new State(-473);
    states[970] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-91,971,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623});
    states[971] = new State(new int[]{13,128,94,-113,5,-113,10,-113,9,-113});
    states[972] = new State(new int[]{13,128,94,-112,5,-112,10,-112,9,-112});
    states[973] = new State(new int[]{5,956,121,-919},new int[]{-308,974});
    states[974] = new State(new int[]{121,975});
    states[975] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,85,116,37,627,51,705,91,700,32,710,33,736,70,768,22,683,96,726,57,776,72,828,44,733},new int[]{-311,976,-91,457,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-313,624,-239,625,-138,626,-301,763,-231,764,-109,765,-108,766,-110,767,-32,824,-286,825,-154,826,-111,827,-232,829});
    states[976] = new State(-899);
    states[977] = new State(new int[]{5,978,10,990,17,-735,8,-735,7,-735,136,-735,4,-735,15,-735,132,-735,130,-735,112,-735,111,-735,125,-735,126,-735,127,-735,128,-735,124,-735,110,-735,109,-735,122,-735,123,-735,120,-735,114,-735,119,-735,117,-735,115,-735,118,-735,116,-735,131,-735,16,-735,94,-735,13,-735,9,-735,113,-735,11,-735});
    states[978] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-259,979,-260,395,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[979] = new State(new int[]{9,980,10,984});
    states[980] = new State(new int[]{5,956,121,-919},new int[]{-308,981});
    states[981] = new State(new int[]{121,982});
    states[982] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,85,116,37,627,51,705,91,700,32,710,33,736,70,768,22,683,96,726,57,776,72,828,44,733},new int[]{-311,983,-91,457,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-313,624,-239,625,-138,626,-301,763,-231,764,-109,765,-108,766,-110,767,-32,824,-286,825,-154,826,-111,827,-232,829});
    states[983] = new State(-900);
    states[984] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-309,985,-310,877,-143,506,-132,753,-136,24,-137,27});
    states[985] = new State(new int[]{9,986,10,504});
    states[986] = new State(new int[]{5,956,121,-919},new int[]{-308,987});
    states[987] = new State(new int[]{121,988});
    states[988] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,85,116,37,627,51,705,91,700,32,710,33,736,70,768,22,683,96,726,57,776,72,828,44,733},new int[]{-311,989,-91,457,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-313,624,-239,625,-138,626,-301,763,-231,764,-109,765,-108,766,-110,767,-32,824,-286,825,-154,826,-111,827,-232,829});
    states[989] = new State(-902);
    states[990] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-309,991,-310,877,-143,506,-132,753,-136,24,-137,27});
    states[991] = new State(new int[]{9,992,10,504});
    states[992] = new State(new int[]{5,956,121,-919},new int[]{-308,993});
    states[993] = new State(new int[]{121,994});
    states[994] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,85,116,37,627,51,705,91,700,32,710,33,736,70,768,22,683,96,726,57,776,72,828,44,733},new int[]{-311,995,-91,457,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-313,624,-239,625,-138,626,-301,763,-231,764,-109,765,-108,766,-110,767,-32,824,-286,825,-154,826,-111,827,-232,829});
    states[995] = new State(-901);
    states[996] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-120,997,-132,998,-136,24,-137,27});
    states[997] = new State(-466);
    states[998] = new State(-467);
    states[999] = new State(-465);
    states[1000] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-144,1001,-120,999,-132,998,-136,24,-137,27});
    states[1001] = new State(new int[]{5,1002,94,996});
    states[1002] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-259,1003,-260,395,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[1003] = new State(new int[]{104,1004,9,-459,10,-459});
    states[1004] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,5,642},new int[]{-81,1005,-91,127,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641});
    states[1005] = new State(-463);
    states[1006] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-144,1007,-120,999,-132,998,-136,24,-137,27});
    states[1007] = new State(new int[]{5,1008,94,996});
    states[1008] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-259,1009,-260,395,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[1009] = new State(new int[]{104,1010,9,-460,10,-460});
    states[1010] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,5,642},new int[]{-81,1011,-91,127,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641});
    states[1011] = new State(-464);
    states[1012] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-144,1013,-120,999,-132,998,-136,24,-137,27});
    states[1013] = new State(new int[]{5,1014,94,996});
    states[1014] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-259,1015,-260,395,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[1015] = new State(-461);
    states[1016] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-235,1017,-8,1032,-9,1021,-166,1022,-132,1027,-136,24,-137,27,-285,1030});
    states[1017] = new State(new int[]{12,1018,94,1019});
    states[1018] = new State(-201);
    states[1019] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-8,1020,-9,1021,-166,1022,-132,1027,-136,24,-137,27,-285,1030});
    states[1020] = new State(-203);
    states[1021] = new State(-204);
    states[1022] = new State(new int[]{7,163,8,1024,117,168,12,-606,94,-606},new int[]{-65,1023,-283,960});
    states[1023] = new State(-727);
    states[1024] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,551,18,247,19,252,5,642,34,863,41,878,9,-750},new int[]{-63,1025,-66,451,-82,550,-81,126,-91,127,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,454,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641,-305,936,-306,937});
    states[1025] = new State(new int[]{9,1026});
    states[1026] = new State(-607);
    states[1027] = new State(new int[]{5,1028,7,-247,8,-247,117,-247,12,-247,94,-247});
    states[1028] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-9,1029,-166,1022,-132,196,-136,24,-137,27,-285,1030});
    states[1029] = new State(-205);
    states[1030] = new State(new int[]{8,1024,12,-606,94,-606},new int[]{-65,1031});
    states[1031] = new State(-728);
    states[1032] = new State(-202);
    states[1033] = new State(-198);
    states[1034] = new State(-455);
    states[1035] = new State(-726);
    states[1036] = new State(new int[]{141,1040,143,1041,144,1042,145,1043,147,1044,146,1045,101,-764,85,-764,56,-764,26,-764,64,-764,47,-764,50,-764,59,-764,11,-764,25,-764,23,-764,41,-764,34,-764,27,-764,28,-764,43,-764,24,-764,86,-764,79,-764,78,-764,77,-764,76,-764,20,-764,142,-764,38,-764},new int[]{-192,1037,-195,1046});
    states[1037] = new State(new int[]{10,1038});
    states[1038] = new State(new int[]{141,1040,143,1041,144,1042,145,1043,147,1044,146,1045,101,-765,85,-765,56,-765,26,-765,64,-765,47,-765,50,-765,59,-765,11,-765,25,-765,23,-765,41,-765,34,-765,27,-765,28,-765,43,-765,24,-765,86,-765,79,-765,78,-765,77,-765,76,-765,20,-765,142,-765,38,-765},new int[]{-195,1039});
    states[1039] = new State(-769);
    states[1040] = new State(-779);
    states[1041] = new State(-780);
    states[1042] = new State(-781);
    states[1043] = new State(-782);
    states[1044] = new State(-783);
    states[1045] = new State(-784);
    states[1046] = new State(-768);
    states[1047] = new State(-363);
    states[1048] = new State(-429);
    states[1049] = new State(-430);
    states[1050] = new State(new int[]{8,-435,104,-435,10,-435,5,-435,7,-432});
    states[1051] = new State(new int[]{117,1053,8,-438,104,-438,10,-438,7,-438,5,-438},new int[]{-140,1052});
    states[1052] = new State(-439);
    states[1053] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-143,1054,-132,753,-136,24,-137,27});
    states[1054] = new State(new int[]{115,1055,94,508});
    states[1055] = new State(-310);
    states[1056] = new State(-440);
    states[1057] = new State(new int[]{117,1053,8,-436,104,-436,10,-436,5,-436},new int[]{-140,1058});
    states[1058] = new State(-437);
    states[1059] = new State(new int[]{7,1060});
    states[1060] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,42,461},new int[]{-127,1061,-134,1062,-122,1050,-119,1051,-132,1056,-136,24,-137,27,-177,1057});
    states[1061] = new State(-431);
    states[1062] = new State(-434);
    states[1063] = new State(-433);
    states[1064] = new State(-422);
    states[1065] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,79,32,78,33,77,34,76,35},new int[]{-158,1066,-132,1105,-136,24,-137,27,-135,1106});
    states[1066] = new State(new int[]{7,1090,11,1096,5,-379},new int[]{-218,1067,-223,1093});
    states[1067] = new State(new int[]{80,1079,81,1085,10,-386},new int[]{-188,1068});
    states[1068] = new State(new int[]{10,1069});
    states[1069] = new State(new int[]{60,1074,146,1076,145,1077,141,1078,11,-376,25,-376,23,-376,41,-376,34,-376,27,-376,28,-376,43,-376,24,-376,86,-376,79,-376,78,-376,77,-376,76,-376},new int[]{-191,1070,-196,1071});
    states[1070] = new State(-372);
    states[1071] = new State(new int[]{10,1072});
    states[1072] = new State(new int[]{60,1074,11,-376,25,-376,23,-376,41,-376,34,-376,27,-376,28,-376,43,-376,24,-376,86,-376,79,-376,78,-376,77,-376,76,-376},new int[]{-191,1073});
    states[1073] = new State(-373);
    states[1074] = new State(new int[]{10,1075});
    states[1075] = new State(-377);
    states[1076] = new State(-785);
    states[1077] = new State(-786);
    states[1078] = new State(-787);
    states[1079] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,551,18,247,19,252,5,642,34,863,41,878,10,-385},new int[]{-101,1080,-82,1084,-81,126,-91,127,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,454,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641,-305,936,-306,937});
    states[1080] = new State(new int[]{81,1082,10,-389},new int[]{-189,1081});
    states[1081] = new State(-387);
    states[1082] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,10,-476},new int[]{-244,1083,-4,122,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787});
    states[1083] = new State(-390);
    states[1084] = new State(-384);
    states[1085] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,10,-476},new int[]{-244,1086,-4,122,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787});
    states[1086] = new State(new int[]{80,1088,10,-391},new int[]{-190,1087});
    states[1087] = new State(-388);
    states[1088] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,551,18,247,19,252,5,642,34,863,41,878,10,-385},new int[]{-101,1089,-82,1084,-81,126,-91,127,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,454,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641,-305,936,-306,937});
    states[1089] = new State(-392);
    states[1090] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,79,32,78,33,77,34,76,35},new int[]{-132,1091,-135,1092,-136,24,-137,27});
    states[1091] = new State(-367);
    states[1092] = new State(-368);
    states[1093] = new State(new int[]{5,1094});
    states[1094] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-259,1095,-260,395,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[1095] = new State(-378);
    states[1096] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-222,1097,-221,1104,-143,1101,-132,753,-136,24,-137,27});
    states[1097] = new State(new int[]{12,1098,10,1099});
    states[1098] = new State(-380);
    states[1099] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-221,1100,-143,1101,-132,753,-136,24,-137,27});
    states[1100] = new State(-382);
    states[1101] = new State(new int[]{5,1102,94,508});
    states[1102] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-259,1103,-260,395,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[1103] = new State(-383);
    states[1104] = new State(-381);
    states[1105] = new State(-365);
    states[1106] = new State(-366);
    states[1107] = new State(new int[]{43,1108});
    states[1108] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,79,32,78,33,77,34,76,35},new int[]{-158,1109,-132,1105,-136,24,-137,27,-135,1106});
    states[1109] = new State(new int[]{7,1090,11,1096,5,-379},new int[]{-218,1110,-223,1093});
    states[1110] = new State(new int[]{10,1111});
    states[1111] = new State(-375);
    states[1112] = new State(new int[]{101,1243,11,-357,25,-357,23,-357,41,-357,34,-357,27,-357,28,-357,43,-357,24,-357,86,-357,79,-357,78,-357,77,-357,76,-357,56,-63,26,-63,64,-63,47,-63,50,-63,59,-63,85,-63},new int[]{-162,1113,-40,1114,-36,1117,-57,1242});
    states[1113] = new State(-423);
    states[1114] = new State(new int[]{85,116},new int[]{-239,1115});
    states[1115] = new State(new int[]{10,1116});
    states[1116] = new State(-450);
    states[1117] = new State(new int[]{56,1120,26,1141,64,1145,47,1305,50,1320,59,1322,85,-62},new int[]{-42,1118,-153,1119,-26,1126,-48,1143,-273,1147,-292,1307});
    states[1118] = new State(-64);
    states[1119] = new State(-80);
    states[1120] = new State(new int[]{148,677,149,678,137,23,80,25,81,26,75,28,73,29},new int[]{-141,1121,-128,1125,-132,679,-136,24,-137,27});
    states[1121] = new State(new int[]{10,1122,94,1123});
    states[1122] = new State(-89);
    states[1123] = new State(new int[]{148,677,149,678,137,23,80,25,81,26,75,28,73,29},new int[]{-128,1124,-132,679,-136,24,-137,27});
    states[1124] = new State(-91);
    states[1125] = new State(-90);
    states[1126] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,56,-81,26,-81,64,-81,47,-81,50,-81,59,-81,85,-81},new int[]{-24,1127,-25,1128,-126,1130,-132,1140,-136,24,-137,27});
    states[1127] = new State(-96);
    states[1128] = new State(new int[]{10,1129});
    states[1129] = new State(-106);
    states[1130] = new State(new int[]{114,1131,5,1136});
    states[1131] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,1134,129,373,110,377,109,378},new int[]{-97,1132,-83,1133,-75,191,-12,215,-10,225,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379,-249,380,-253,381,-226,382,-87,1135});
    states[1132] = new State(-107);
    states[1133] = new State(new int[]{13,187,10,-109,86,-109,79,-109,78,-109,77,-109,76,-109});
    states[1134] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,847,129,373,110,377,109,378,60,158,9,-186},new int[]{-83,831,-62,848,-227,836,-87,838,-75,191,-12,215,-10,225,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379,-249,380,-253,381,-226,382,-61,237,-79,850,-78,240,-53,851});
    states[1135] = new State(-110);
    states[1136] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-260,1137,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[1137] = new State(new int[]{114,1138});
    states[1138] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,847,129,373,110,377,109,378},new int[]{-78,1139,-83,241,-75,191,-12,215,-10,225,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379,-249,380,-253,381,-226,382,-87,858,-227,859});
    states[1139] = new State(-108);
    states[1140] = new State(-111);
    states[1141] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-24,1142,-25,1128,-126,1130,-132,1140,-136,24,-137,27});
    states[1142] = new State(-95);
    states[1143] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,56,-82,26,-82,64,-82,47,-82,50,-82,59,-82,85,-82},new int[]{-24,1144,-25,1128,-126,1130,-132,1140,-136,24,-137,27});
    states[1144] = new State(-98);
    states[1145] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-24,1146,-25,1128,-126,1130,-132,1140,-136,24,-137,27});
    states[1146] = new State(-97);
    states[1147] = new State(new int[]{11,1016,56,-83,26,-83,64,-83,47,-83,50,-83,59,-83,85,-83,137,-200,80,-200,81,-200,75,-200,73,-200},new int[]{-45,1148,-6,1149,-234,1033});
    states[1148] = new State(-100);
    states[1149] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,11,1016},new int[]{-46,1150,-234,423,-129,1151,-132,1297,-136,24,-137,27,-130,1302});
    states[1150] = new State(-197);
    states[1151] = new State(new int[]{114,1152});
    states[1152] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587,66,1291,67,1292,141,1293,24,1294,25,1295,23,-292,40,-292,61,-292},new int[]{-271,1153,-260,1155,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591,-27,1156,-20,1157,-21,1289,-19,1296});
    states[1153] = new State(new int[]{10,1154});
    states[1154] = new State(-206);
    states[1155] = new State(-211);
    states[1156] = new State(-212);
    states[1157] = new State(new int[]{23,1283,40,1284,61,1285},new int[]{-275,1158});
    states[1158] = new State(new int[]{8,1199,20,-304,11,-304,86,-304,79,-304,78,-304,77,-304,76,-304,26,-304,137,-304,80,-304,81,-304,75,-304,73,-304,59,-304,25,-304,23,-304,41,-304,34,-304,27,-304,28,-304,43,-304,24,-304,10,-304},new int[]{-169,1159});
    states[1159] = new State(new int[]{20,1190,11,-311,86,-311,79,-311,78,-311,77,-311,76,-311,26,-311,137,-311,80,-311,81,-311,75,-311,73,-311,59,-311,25,-311,23,-311,41,-311,34,-311,27,-311,28,-311,43,-311,24,-311,10,-311},new int[]{-300,1160,-299,1188,-298,1210});
    states[1160] = new State(new int[]{11,1016,10,-302,86,-328,79,-328,78,-328,77,-328,76,-328,26,-200,137,-200,80,-200,81,-200,75,-200,73,-200,59,-200,25,-200,23,-200,41,-200,34,-200,27,-200,28,-200,43,-200,24,-200},new int[]{-23,1161,-22,1162,-29,1168,-31,414,-41,1169,-6,1170,-234,1033,-30,1280,-50,1282,-49,420,-51,1281});
    states[1161] = new State(-285);
    states[1162] = new State(new int[]{86,1163,79,1164,78,1165,77,1166,76,1167},new int[]{-7,412});
    states[1163] = new State(-303);
    states[1164] = new State(-324);
    states[1165] = new State(-325);
    states[1166] = new State(-326);
    states[1167] = new State(-327);
    states[1168] = new State(-322);
    states[1169] = new State(-336);
    states[1170] = new State(new int[]{26,1172,137,23,80,25,81,26,75,28,73,29,59,1176,25,1237,23,1238,11,1016,41,1183,34,1218,27,1252,28,1259,43,1266,24,1275},new int[]{-47,1171,-234,423,-207,422,-204,424,-242,425,-295,1174,-294,1175,-143,754,-132,753,-136,24,-137,27,-3,1180,-215,1239,-213,1112,-210,1182,-214,1217,-212,1240,-200,1263,-201,1264,-203,1265});
    states[1171] = new State(-338);
    states[1172] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-25,1173,-126,1130,-132,1140,-136,24,-137,27});
    states[1173] = new State(-343);
    states[1174] = new State(-344);
    states[1175] = new State(-348);
    states[1176] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-143,1177,-132,753,-136,24,-137,27});
    states[1177] = new State(new int[]{5,1178,94,508});
    states[1178] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-260,1179,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[1179] = new State(-349);
    states[1180] = new State(new int[]{27,428,43,1065,24,1107,137,23,80,25,81,26,75,28,73,29,59,1176,41,1183,34,1218},new int[]{-295,1181,-215,427,-201,1064,-294,1175,-143,754,-132,753,-136,24,-137,27,-213,1112,-210,1182,-214,1217});
    states[1181] = new State(-345);
    states[1182] = new State(-358);
    states[1183] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,42,461},new int[]{-156,1184,-155,1048,-127,1049,-122,1050,-119,1051,-132,1056,-136,24,-137,27,-177,1057,-317,1059,-134,1063});
    states[1184] = new State(new int[]{8,531,10,-452,104,-452},new int[]{-113,1185});
    states[1185] = new State(new int[]{10,1215,104,-766},new int[]{-193,1186,-194,1211});
    states[1186] = new State(new int[]{20,1190,101,-311,85,-311,56,-311,26,-311,64,-311,47,-311,50,-311,59,-311,11,-311,25,-311,23,-311,41,-311,34,-311,27,-311,28,-311,43,-311,24,-311,86,-311,79,-311,78,-311,77,-311,76,-311,142,-311,38,-311},new int[]{-300,1187,-299,1188,-298,1210});
    states[1187] = new State(-441);
    states[1188] = new State(new int[]{20,1190,11,-312,86,-312,79,-312,78,-312,77,-312,76,-312,26,-312,137,-312,80,-312,81,-312,75,-312,73,-312,59,-312,25,-312,23,-312,41,-312,34,-312,27,-312,28,-312,43,-312,24,-312,10,-312,101,-312,85,-312,56,-312,64,-312,47,-312,50,-312,142,-312,38,-312},new int[]{-298,1189});
    states[1189] = new State(-314);
    states[1190] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-143,1191,-132,753,-136,24,-137,27});
    states[1191] = new State(new int[]{5,1192,94,508});
    states[1192] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,1198,46,513,31,517,71,521,62,524,41,529,34,587,23,1207,27,1208},new int[]{-272,1193,-269,1209,-260,1197,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[1193] = new State(new int[]{10,1194,94,1195});
    states[1194] = new State(-315);
    states[1195] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,1198,46,513,31,517,71,521,62,524,41,529,34,587,23,1207,27,1208},new int[]{-269,1196,-260,1197,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[1196] = new State(-317);
    states[1197] = new State(-318);
    states[1198] = new State(new int[]{8,1199,10,-320,94,-320,20,-304,11,-304,86,-304,79,-304,78,-304,77,-304,76,-304,26,-304,137,-304,80,-304,81,-304,75,-304,73,-304,59,-304,25,-304,23,-304,41,-304,34,-304,27,-304,28,-304,43,-304,24,-304},new int[]{-169,408});
    states[1199] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-168,1200,-167,1206,-166,1204,-132,196,-136,24,-137,27,-285,1205});
    states[1200] = new State(new int[]{9,1201,94,1202});
    states[1201] = new State(-305);
    states[1202] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-167,1203,-166,1204,-132,196,-136,24,-137,27,-285,1205});
    states[1203] = new State(-307);
    states[1204] = new State(new int[]{7,163,117,168,9,-308,94,-308},new int[]{-283,960});
    states[1205] = new State(-309);
    states[1206] = new State(-306);
    states[1207] = new State(-319);
    states[1208] = new State(-321);
    states[1209] = new State(-316);
    states[1210] = new State(-313);
    states[1211] = new State(new int[]{104,1212});
    states[1212] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,10,-476},new int[]{-244,1213,-4,122,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787});
    states[1213] = new State(new int[]{10,1214});
    states[1214] = new State(-426);
    states[1215] = new State(new int[]{141,1040,143,1041,144,1042,145,1043,147,1044,146,1045,20,-764,101,-764,85,-764,56,-764,26,-764,64,-764,47,-764,50,-764,59,-764,11,-764,25,-764,23,-764,41,-764,34,-764,27,-764,28,-764,43,-764,24,-764,86,-764,79,-764,78,-764,77,-764,76,-764,142,-764},new int[]{-192,1216,-195,1046});
    states[1216] = new State(new int[]{10,1038,104,-767});
    states[1217] = new State(-359);
    states[1218] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,42,461},new int[]{-155,1219,-127,1049,-122,1050,-119,1051,-132,1056,-136,24,-137,27,-177,1057,-317,1059,-134,1063});
    states[1219] = new State(new int[]{8,531,5,-452,10,-452,104,-452},new int[]{-113,1220});
    states[1220] = new State(new int[]{5,1223,10,1215,104,-766},new int[]{-193,1221,-194,1233});
    states[1221] = new State(new int[]{20,1190,101,-311,85,-311,56,-311,26,-311,64,-311,47,-311,50,-311,59,-311,11,-311,25,-311,23,-311,41,-311,34,-311,27,-311,28,-311,43,-311,24,-311,86,-311,79,-311,78,-311,77,-311,76,-311,142,-311,38,-311},new int[]{-300,1222,-299,1188,-298,1210});
    states[1222] = new State(-442);
    states[1223] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-259,1224,-260,395,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[1224] = new State(new int[]{10,1215,104,-766},new int[]{-193,1225,-194,1227});
    states[1225] = new State(new int[]{20,1190,101,-311,85,-311,56,-311,26,-311,64,-311,47,-311,50,-311,59,-311,11,-311,25,-311,23,-311,41,-311,34,-311,27,-311,28,-311,43,-311,24,-311,86,-311,79,-311,78,-311,77,-311,76,-311,142,-311,38,-311},new int[]{-300,1226,-299,1188,-298,1210});
    states[1226] = new State(-443);
    states[1227] = new State(new int[]{104,1228});
    states[1228] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,551,18,247,19,252,34,863,41,878},new int[]{-92,1229,-91,1231,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,454,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-305,1232,-306,937});
    states[1229] = new State(new int[]{10,1230});
    states[1230] = new State(-424);
    states[1231] = new State(new int[]{13,128,10,-584});
    states[1232] = new State(-585);
    states[1233] = new State(new int[]{104,1234});
    states[1234] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,551,18,247,19,252,34,863,41,878},new int[]{-92,1235,-91,1231,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,454,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-305,1232,-306,937});
    states[1235] = new State(new int[]{10,1236});
    states[1236] = new State(-425);
    states[1237] = new State(-346);
    states[1238] = new State(-347);
    states[1239] = new State(-355);
    states[1240] = new State(new int[]{101,1243,11,-356,25,-356,23,-356,41,-356,34,-356,27,-356,28,-356,43,-356,24,-356,86,-356,79,-356,78,-356,77,-356,76,-356,56,-63,26,-63,64,-63,47,-63,50,-63,59,-63,85,-63},new int[]{-162,1241,-40,1114,-36,1117,-57,1242});
    states[1241] = new State(-409);
    states[1242] = new State(-451);
    states[1243] = new State(new int[]{10,1251,137,23,80,25,81,26,75,28,73,29,138,149,140,150,139,152},new int[]{-96,1244,-132,1248,-136,24,-137,27,-150,1249,-152,147,-151,151});
    states[1244] = new State(new int[]{75,1245,10,1250});
    states[1245] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,138,149,140,150,139,152},new int[]{-96,1246,-132,1248,-136,24,-137,27,-150,1249,-152,147,-151,151});
    states[1246] = new State(new int[]{10,1247});
    states[1247] = new State(-444);
    states[1248] = new State(-447);
    states[1249] = new State(-448);
    states[1250] = new State(-445);
    states[1251] = new State(-446);
    states[1252] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,42,461,8,-364,104,-364,10,-364},new int[]{-157,1253,-156,1047,-155,1048,-127,1049,-122,1050,-119,1051,-132,1056,-136,24,-137,27,-177,1057,-317,1059,-134,1063});
    states[1253] = new State(new int[]{8,531,104,-452,10,-452},new int[]{-113,1254});
    states[1254] = new State(new int[]{104,1256,10,1036},new int[]{-193,1255});
    states[1255] = new State(-360);
    states[1256] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,10,-476},new int[]{-244,1257,-4,122,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787});
    states[1257] = new State(new int[]{10,1258});
    states[1258] = new State(-410);
    states[1259] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,42,461,8,-364,10,-364},new int[]{-157,1260,-156,1047,-155,1048,-127,1049,-122,1050,-119,1051,-132,1056,-136,24,-137,27,-177,1057,-317,1059,-134,1063});
    states[1260] = new State(new int[]{8,531,10,-452},new int[]{-113,1261});
    states[1261] = new State(new int[]{10,1036},new int[]{-193,1262});
    states[1262] = new State(-362);
    states[1263] = new State(-352);
    states[1264] = new State(-421);
    states[1265] = new State(-353);
    states[1266] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,79,32,78,33,77,34,76,35},new int[]{-158,1267,-132,1105,-136,24,-137,27,-135,1106});
    states[1267] = new State(new int[]{7,1090,11,1096,5,-379},new int[]{-218,1268,-223,1093});
    states[1268] = new State(new int[]{80,1079,81,1085,10,-386},new int[]{-188,1269});
    states[1269] = new State(new int[]{10,1270});
    states[1270] = new State(new int[]{60,1074,146,1076,145,1077,141,1078,11,-376,25,-376,23,-376,41,-376,34,-376,27,-376,28,-376,43,-376,24,-376,86,-376,79,-376,78,-376,77,-376,76,-376},new int[]{-191,1271,-196,1272});
    states[1271] = new State(-370);
    states[1272] = new State(new int[]{10,1273});
    states[1273] = new State(new int[]{60,1074,11,-376,25,-376,23,-376,41,-376,34,-376,27,-376,28,-376,43,-376,24,-376,86,-376,79,-376,78,-376,77,-376,76,-376},new int[]{-191,1274});
    states[1274] = new State(-371);
    states[1275] = new State(new int[]{43,1276});
    states[1276] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,79,32,78,33,77,34,76,35},new int[]{-158,1277,-132,1105,-136,24,-137,27,-135,1106});
    states[1277] = new State(new int[]{7,1090,11,1096,5,-379},new int[]{-218,1278,-223,1093});
    states[1278] = new State(new int[]{10,1279});
    states[1279] = new State(-374);
    states[1280] = new State(new int[]{11,1016,86,-330,79,-330,78,-330,77,-330,76,-330,25,-200,23,-200,41,-200,34,-200,27,-200,28,-200,43,-200,24,-200},new int[]{-50,419,-49,420,-6,421,-234,1033,-51,1281});
    states[1281] = new State(-342);
    states[1282] = new State(-339);
    states[1283] = new State(-296);
    states[1284] = new State(-297);
    states[1285] = new State(new int[]{23,1286,45,1287,40,1288,8,-298,20,-298,11,-298,86,-298,79,-298,78,-298,77,-298,76,-298,26,-298,137,-298,80,-298,81,-298,75,-298,73,-298,59,-298,25,-298,41,-298,34,-298,27,-298,28,-298,43,-298,24,-298,10,-298});
    states[1286] = new State(-299);
    states[1287] = new State(-300);
    states[1288] = new State(-301);
    states[1289] = new State(new int[]{66,1291,67,1292,141,1293,24,1294,25,1295,23,-293,40,-293,61,-293},new int[]{-19,1290});
    states[1290] = new State(-295);
    states[1291] = new State(-287);
    states[1292] = new State(-288);
    states[1293] = new State(-289);
    states[1294] = new State(-290);
    states[1295] = new State(-291);
    states[1296] = new State(-294);
    states[1297] = new State(new int[]{117,1299,114,-208},new int[]{-140,1298});
    states[1298] = new State(-209);
    states[1299] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-143,1300,-132,753,-136,24,-137,27});
    states[1300] = new State(new int[]{116,1301,115,1055,94,508});
    states[1301] = new State(-210);
    states[1302] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587,66,1291,67,1292,141,1293,24,1294,25,1295,23,-292,40,-292,61,-292},new int[]{-271,1303,-260,1155,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591,-27,1156,-20,1157,-21,1289,-19,1296});
    states[1303] = new State(new int[]{10,1304});
    states[1304] = new State(-207);
    states[1305] = new State(new int[]{11,1016,137,-200,80,-200,81,-200,75,-200,73,-200},new int[]{-45,1306,-6,1149,-234,1033});
    states[1306] = new State(-99);
    states[1307] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,8,1312,56,-84,26,-84,64,-84,47,-84,50,-84,59,-84,85,-84},new int[]{-296,1308,-293,1309,-294,1310,-143,754,-132,753,-136,24,-137,27});
    states[1308] = new State(-105);
    states[1309] = new State(-101);
    states[1310] = new State(new int[]{10,1311});
    states[1311] = new State(-393);
    states[1312] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-132,1313,-136,24,-137,27});
    states[1313] = new State(new int[]{94,1314});
    states[1314] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-143,1315,-132,753,-136,24,-137,27});
    states[1315] = new State(new int[]{9,1316,94,508});
    states[1316] = new State(new int[]{104,1317});
    states[1317] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-91,1318,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623});
    states[1318] = new State(new int[]{10,1319,13,128});
    states[1319] = new State(-102);
    states[1320] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,8,1312},new int[]{-296,1321,-293,1309,-294,1310,-143,754,-132,753,-136,24,-137,27});
    states[1321] = new State(-103);
    states[1322] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,8,1312},new int[]{-296,1323,-293,1309,-294,1310,-143,754,-132,753,-136,24,-137,27});
    states[1323] = new State(-104);
    states[1324] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,961,12,-268,94,-268},new int[]{-255,1325,-256,1326,-85,175,-94,267,-95,268,-166,386,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151});
    states[1325] = new State(-266);
    states[1326] = new State(-267);
    states[1327] = new State(-265);
    states[1328] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-260,1329,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[1329] = new State(-264);
    states[1330] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-132,1331,-136,24,-137,27});
    states[1331] = new State(new int[]{5,1332,9,-657,10,-657,94,-657});
    states[1332] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-260,1333,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[1333] = new State(-656);
    states[1334] = new State(-658);
    states[1335] = new State(-659);
    states[1336] = new State(-660);
    states[1337] = new State(new int[]{14,351,138,149,140,150,139,152,148,154,150,155,149,156,137,23,80,25,81,26,75,28,73,29,50,1330,11,334,8,608},new int[]{-334,1338,-14,352,-150,146,-152,147,-151,151,-15,153,-132,353,-136,24,-137,27,-323,1334,-268,345,-166,162,-325,1335,-326,1336});
    states[1338] = new State(-641);
    states[1339] = new State(-639);
    states[1340] = new State(-622);
    states[1341] = new State(-623);
    states[1342] = new State(-624);
    states[1343] = new State(-616);
    states[1344] = new State(-753);
    states[1345] = new State(-227);
    states[1346] = new State(-223);
    states[1347] = new State(-592);
    states[1348] = new State(new int[]{8,1349});
    states[1349] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,42,461,39,491,8,493,18,247,19,252},new int[]{-316,1350,-315,1358,-132,1354,-136,24,-137,27,-89,1357,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622});
    states[1350] = new State(new int[]{9,1351,94,1352});
    states[1351] = new State(-601);
    states[1352] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,42,461,39,491,8,493,18,247,19,252},new int[]{-315,1353,-132,1354,-136,24,-137,27,-89,1357,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622});
    states[1353] = new State(-605);
    states[1354] = new State(new int[]{104,1355,17,-735,8,-735,7,-735,136,-735,4,-735,15,-735,132,-735,130,-735,112,-735,111,-735,125,-735,126,-735,127,-735,128,-735,124,-735,110,-735,109,-735,122,-735,123,-735,120,-735,114,-735,119,-735,117,-735,115,-735,118,-735,116,-735,131,-735,9,-735,94,-735,113,-735,11,-735});
    states[1355] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252},new int[]{-89,1356,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622});
    states[1356] = new State(new int[]{114,291,119,292,117,293,115,294,118,295,116,296,131,297,9,-602,94,-602},new int[]{-182,135});
    states[1357] = new State(new int[]{114,291,119,292,117,293,115,294,118,295,116,296,131,297,9,-603,94,-603},new int[]{-182,135});
    states[1358] = new State(-604);
    states[1359] = new State(new int[]{13,187,5,-663,12,-663});
    states[1360] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,370,129,373,110,377,109,378},new int[]{-83,1361,-75,191,-12,215,-10,225,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379,-249,380,-253,381,-226,382});
    states[1361] = new State(new int[]{13,187,94,-176,9,-176,12,-176,5,-176});
    states[1362] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,370,129,373,110,377,109,378,5,-664,12,-664},new int[]{-107,1363,-83,1359,-75,191,-12,215,-10,225,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379,-249,380,-253,381,-226,382});
    states[1363] = new State(new int[]{5,1364,12,-670});
    states[1364] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,370,129,373,110,377,109,378},new int[]{-83,1365,-75,191,-12,215,-10,225,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379,-249,380,-253,381,-226,382});
    states[1365] = new State(new int[]{13,187,12,-672});
    states[1366] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,79,32,78,33,77,34,76,35,66,36,61,37,122,38,19,39,18,40,60,41,20,42,123,43,124,44,125,45,126,46,127,47,128,48,129,49,130,50,131,51,132,52,21,53,71,54,85,55,22,56,23,57,26,58,27,59,28,60,69,61,93,62,29,63,30,64,31,65,24,66,98,67,95,68,32,69,33,70,34,71,37,72,38,73,39,74,97,75,40,76,41,77,43,78,44,79,45,80,91,81,46,82,96,83,47,84,25,85,48,86,68,87,92,88,49,89,50,90,51,91,52,92,53,93,54,94,55,95,56,96,58,97,99,98,100,99,103,100,101,101,102,102,59,103,72,104,35,105,36,106,42,108,86,109},new int[]{-123,1367,-132,22,-136,24,-137,27,-277,30,-135,31,-278,107});
    states[1367] = new State(-165);
    states[1368] = new State(-166);
    states[1369] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,551,18,247,19,252,5,642,34,863,41,878,9,-170},new int[]{-70,1370,-66,1372,-82,550,-81,126,-91,127,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,454,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641,-305,936,-306,937});
    states[1370] = new State(new int[]{9,1371});
    states[1371] = new State(-167);
    states[1372] = new State(new int[]{94,452,9,-169});
    states[1373] = new State(-137);
    states[1374] = new State(new int[]{137,23,80,25,81,26,75,28,73,227,138,149,140,150,139,152,148,154,150,155,149,156,39,244,18,247,19,252,11,363,53,367,135,368,8,370,129,373,110,377,109,378},new int[]{-75,1375,-12,215,-10,225,-13,201,-132,226,-136,24,-137,27,-150,242,-152,147,-151,151,-15,243,-241,246,-279,251,-224,362,-185,375,-159,379,-249,380,-253,381});
    states[1375] = new State(new int[]{110,1376,109,1377,122,1378,123,1379,13,-115,6,-115,94,-115,9,-115,12,-115,5,-115,86,-115,10,-115,92,-115,95,-115,30,-115,98,-115,29,-115,93,-115,81,-115,80,-115,2,-115,79,-115,78,-115,77,-115,76,-115},new int[]{-179,192});
    states[1376] = new State(-127);
    states[1377] = new State(-128);
    states[1378] = new State(-129);
    states[1379] = new State(-130);
    states[1380] = new State(-118);
    states[1381] = new State(-119);
    states[1382] = new State(-120);
    states[1383] = new State(-121);
    states[1384] = new State(-122);
    states[1385] = new State(-123);
    states[1386] = new State(-124);
    states[1387] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152},new int[]{-85,1388,-94,267,-95,268,-166,386,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151});
    states[1388] = new State(new int[]{110,1376,109,1377,122,1378,123,1379,13,-236,115,-236,94,-236,114,-236,9,-236,10,-236,121,-236,104,-236,86,-236,92,-236,95,-236,30,-236,98,-236,29,-236,12,-236,93,-236,81,-236,80,-236,2,-236,79,-236,78,-236,77,-236,76,-236,131,-236},new int[]{-179,176});
    states[1389] = new State(-33);
    states[1390] = new State(new int[]{56,1120,26,1141,64,1145,47,1305,50,1320,59,1322,11,1016,85,-59,86,-59,97,-59,41,-200,34,-200,25,-200,23,-200,27,-200,28,-200},new int[]{-43,1391,-153,1392,-26,1393,-48,1394,-273,1395,-292,1396,-205,1397,-6,1398,-234,1033});
    states[1391] = new State(-61);
    states[1392] = new State(-71);
    states[1393] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,56,-72,26,-72,64,-72,47,-72,50,-72,59,-72,11,-72,41,-72,34,-72,25,-72,23,-72,27,-72,28,-72,85,-72,86,-72,97,-72},new int[]{-24,1127,-25,1128,-126,1130,-132,1140,-136,24,-137,27});
    states[1394] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,56,-73,26,-73,64,-73,47,-73,50,-73,59,-73,11,-73,41,-73,34,-73,25,-73,23,-73,27,-73,28,-73,85,-73,86,-73,97,-73},new int[]{-24,1144,-25,1128,-126,1130,-132,1140,-136,24,-137,27});
    states[1395] = new State(new int[]{11,1016,56,-74,26,-74,64,-74,47,-74,50,-74,59,-74,41,-74,34,-74,25,-74,23,-74,27,-74,28,-74,85,-74,86,-74,97,-74,137,-200,80,-200,81,-200,75,-200,73,-200},new int[]{-45,1148,-6,1149,-234,1033});
    states[1396] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,8,1312,56,-75,26,-75,64,-75,47,-75,50,-75,59,-75,11,-75,41,-75,34,-75,25,-75,23,-75,27,-75,28,-75,85,-75,86,-75,97,-75},new int[]{-296,1308,-293,1309,-294,1310,-143,754,-132,753,-136,24,-137,27});
    states[1397] = new State(-76);
    states[1398] = new State(new int[]{41,1411,34,1418,25,1237,23,1238,27,1446,28,1259,11,1016},new int[]{-198,1399,-234,423,-199,1400,-206,1401,-213,1402,-210,1182,-214,1217,-3,1435,-202,1443,-212,1444});
    states[1399] = new State(-79);
    states[1400] = new State(-77);
    states[1401] = new State(-412);
    states[1402] = new State(new int[]{142,1404,101,1243,56,-60,26,-60,64,-60,47,-60,50,-60,59,-60,11,-60,41,-60,34,-60,25,-60,23,-60,27,-60,28,-60,85,-60},new int[]{-164,1403,-163,1406,-38,1407,-39,1390,-57,1410});
    states[1403] = new State(-414);
    states[1404] = new State(new int[]{10,1405});
    states[1405] = new State(-420);
    states[1406] = new State(-427);
    states[1407] = new State(new int[]{85,116},new int[]{-239,1408});
    states[1408] = new State(new int[]{10,1409});
    states[1409] = new State(-449);
    states[1410] = new State(-428);
    states[1411] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,42,461},new int[]{-156,1412,-155,1048,-127,1049,-122,1050,-119,1051,-132,1056,-136,24,-137,27,-177,1057,-317,1059,-134,1063});
    states[1412] = new State(new int[]{8,531,10,-452,104,-452},new int[]{-113,1413});
    states[1413] = new State(new int[]{10,1215,104,-766},new int[]{-193,1186,-194,1414});
    states[1414] = new State(new int[]{104,1415});
    states[1415] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,10,-476},new int[]{-244,1416,-4,122,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787});
    states[1416] = new State(new int[]{10,1417});
    states[1417] = new State(-419);
    states[1418] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,42,461},new int[]{-155,1419,-127,1049,-122,1050,-119,1051,-132,1056,-136,24,-137,27,-177,1057,-317,1059,-134,1063});
    states[1419] = new State(new int[]{8,531,5,-452,10,-452,104,-452},new int[]{-113,1420});
    states[1420] = new State(new int[]{5,1421,10,1215,104,-766},new int[]{-193,1221,-194,1429});
    states[1421] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-259,1422,-260,395,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[1422] = new State(new int[]{10,1215,104,-766},new int[]{-193,1225,-194,1423});
    states[1423] = new State(new int[]{104,1424});
    states[1424] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,551,18,247,19,252,34,863,41,878},new int[]{-91,1425,-305,1427,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,454,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-306,937});
    states[1425] = new State(new int[]{10,1426,13,128});
    states[1426] = new State(-415);
    states[1427] = new State(new int[]{10,1428});
    states[1428] = new State(-417);
    states[1429] = new State(new int[]{104,1430});
    states[1430] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,551,18,247,19,252,34,863,41,878},new int[]{-91,1431,-305,1433,-90,132,-89,290,-93,458,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,454,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-306,937});
    states[1431] = new State(new int[]{10,1432,13,128});
    states[1432] = new State(-416);
    states[1433] = new State(new int[]{10,1434});
    states[1434] = new State(-418);
    states[1435] = new State(new int[]{27,1437,41,1411,34,1418},new int[]{-206,1436,-213,1402,-210,1182,-214,1217});
    states[1436] = new State(-413);
    states[1437] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,42,461,8,-364,104,-364,10,-364},new int[]{-157,1438,-156,1047,-155,1048,-127,1049,-122,1050,-119,1051,-132,1056,-136,24,-137,27,-177,1057,-317,1059,-134,1063});
    states[1438] = new State(new int[]{8,531,104,-452,10,-452},new int[]{-113,1439});
    states[1439] = new State(new int[]{104,1440,10,1036},new int[]{-193,431});
    states[1440] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,10,-476},new int[]{-244,1441,-4,122,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787});
    states[1441] = new State(new int[]{10,1442});
    states[1442] = new State(-408);
    states[1443] = new State(-78);
    states[1444] = new State(-60,new int[]{-163,1445,-38,1407,-39,1390});
    states[1445] = new State(-406);
    states[1446] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,42,461,8,-364,104,-364,10,-364},new int[]{-157,1447,-156,1047,-155,1048,-127,1049,-122,1050,-119,1051,-132,1056,-136,24,-137,27,-177,1057,-317,1059,-134,1063});
    states[1447] = new State(new int[]{8,531,104,-452,10,-452},new int[]{-113,1448});
    states[1448] = new State(new int[]{104,1449,10,1036},new int[]{-193,1255});
    states[1449] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,154,150,155,149,156,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,10,-476},new int[]{-244,1450,-4,122,-100,123,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787});
    states[1450] = new State(new int[]{10,1451});
    states[1451] = new State(-407);
    states[1452] = new State(new int[]{3,1454,49,-13,85,-13,56,-13,26,-13,64,-13,47,-13,50,-13,59,-13,11,-13,41,-13,34,-13,25,-13,23,-13,27,-13,28,-13,40,-13,86,-13,97,-13},new int[]{-170,1453});
    states[1453] = new State(-15);
    states[1454] = new State(new int[]{137,1455,138,1456});
    states[1455] = new State(-16);
    states[1456] = new State(-17);
    states[1457] = new State(-14);
    states[1458] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-132,1459,-136,24,-137,27});
    states[1459] = new State(new int[]{10,1461,8,1462},new int[]{-173,1460});
    states[1460] = new State(-26);
    states[1461] = new State(-27);
    states[1462] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-175,1463,-131,1469,-132,1468,-136,24,-137,27});
    states[1463] = new State(new int[]{9,1464,94,1466});
    states[1464] = new State(new int[]{10,1465});
    states[1465] = new State(-28);
    states[1466] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-131,1467,-132,1468,-136,24,-137,27});
    states[1467] = new State(-30);
    states[1468] = new State(-31);
    states[1469] = new State(-29);
    states[1470] = new State(-3);
    states[1471] = new State(new int[]{99,1526,100,1527,103,1528,11,1016},new int[]{-291,1472,-234,423,-2,1521});
    states[1472] = new State(new int[]{40,1493,49,-36,56,-36,26,-36,64,-36,47,-36,50,-36,59,-36,11,-36,41,-36,34,-36,25,-36,23,-36,27,-36,28,-36,86,-36,97,-36,85,-36},new int[]{-147,1473,-148,1490,-287,1519});
    states[1473] = new State(new int[]{38,1487},new int[]{-146,1474});
    states[1474] = new State(new int[]{86,1477,97,1478,85,1484},new int[]{-139,1475});
    states[1475] = new State(new int[]{7,1476});
    states[1476] = new State(-42);
    states[1477] = new State(-52);
    states[1478] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,697,150,155,149,698,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,86,-476,98,-476,10,-476},new int[]{-236,1479,-245,695,-244,121,-4,122,-100,123,-117,435,-99,447,-132,696,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787,-128,911});
    states[1479] = new State(new int[]{86,1480,98,1481,10,119});
    states[1480] = new State(-53);
    states[1481] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,697,150,155,149,698,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,86,-476,10,-476},new int[]{-236,1482,-245,695,-244,121,-4,122,-100,123,-117,435,-99,447,-132,696,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787,-128,911});
    states[1482] = new State(new int[]{86,1483,10,119});
    states[1483] = new State(-54);
    states[1484] = new State(new int[]{135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,633,8,634,18,247,19,252,138,149,140,150,139,152,148,697,150,155,149,698,54,675,85,116,37,627,22,683,91,700,51,705,32,710,52,720,96,726,44,733,33,736,50,744,57,776,72,781,70,768,35,788,86,-476,10,-476},new int[]{-236,1485,-245,695,-244,121,-4,122,-100,123,-117,435,-99,447,-132,696,-136,24,-137,27,-177,460,-241,544,-279,545,-14,655,-150,146,-152,147,-151,151,-15,153,-16,546,-54,656,-103,568,-197,673,-118,674,-239,680,-138,681,-32,682,-231,699,-301,704,-109,709,-302,719,-145,724,-286,725,-232,732,-108,735,-297,743,-55,772,-160,773,-159,774,-154,775,-111,780,-112,785,-110,786,-330,787,-128,911});
    states[1485] = new State(new int[]{86,1486,10,119});
    states[1486] = new State(-55);
    states[1487] = new State(-36,new int[]{-287,1488});
    states[1488] = new State(new int[]{49,14,56,-60,26,-60,64,-60,47,-60,50,-60,59,-60,11,-60,41,-60,34,-60,25,-60,23,-60,27,-60,28,-60,86,-60,97,-60,85,-60},new int[]{-38,1489,-39,1390});
    states[1489] = new State(-50);
    states[1490] = new State(new int[]{86,1477,97,1478,85,1484},new int[]{-139,1491});
    states[1491] = new State(new int[]{7,1492});
    states[1492] = new State(-43);
    states[1493] = new State(-36,new int[]{-287,1494});
    states[1494] = new State(new int[]{49,14,26,-57,64,-57,47,-57,50,-57,59,-57,11,-57,41,-57,34,-57,38,-57},new int[]{-37,1495,-35,1496});
    states[1495] = new State(-49);
    states[1496] = new State(new int[]{26,1141,64,1145,47,1305,50,1320,59,1322,11,1016,38,-56,41,-200,34,-200},new int[]{-44,1497,-26,1498,-48,1499,-273,1500,-292,1501,-217,1502,-6,1503,-234,1033,-216,1518});
    states[1497] = new State(-58);
    states[1498] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,26,-65,64,-65,47,-65,50,-65,59,-65,11,-65,41,-65,34,-65,38,-65},new int[]{-24,1127,-25,1128,-126,1130,-132,1140,-136,24,-137,27});
    states[1499] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,26,-66,64,-66,47,-66,50,-66,59,-66,11,-66,41,-66,34,-66,38,-66},new int[]{-24,1144,-25,1128,-126,1130,-132,1140,-136,24,-137,27});
    states[1500] = new State(new int[]{11,1016,26,-67,64,-67,47,-67,50,-67,59,-67,41,-67,34,-67,38,-67,137,-200,80,-200,81,-200,75,-200,73,-200},new int[]{-45,1148,-6,1149,-234,1033});
    states[1501] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,8,1312,26,-68,64,-68,47,-68,50,-68,59,-68,11,-68,41,-68,34,-68,38,-68},new int[]{-296,1308,-293,1309,-294,1310,-143,754,-132,753,-136,24,-137,27});
    states[1502] = new State(-69);
    states[1503] = new State(new int[]{41,1510,11,1016,34,1513},new int[]{-210,1504,-234,423,-214,1507});
    states[1504] = new State(new int[]{142,1505,26,-85,64,-85,47,-85,50,-85,59,-85,11,-85,41,-85,34,-85,38,-85});
    states[1505] = new State(new int[]{10,1506});
    states[1506] = new State(-86);
    states[1507] = new State(new int[]{142,1508,26,-87,64,-87,47,-87,50,-87,59,-87,11,-87,41,-87,34,-87,38,-87});
    states[1508] = new State(new int[]{10,1509});
    states[1509] = new State(-88);
    states[1510] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,42,461},new int[]{-156,1511,-155,1048,-127,1049,-122,1050,-119,1051,-132,1056,-136,24,-137,27,-177,1057,-317,1059,-134,1063});
    states[1511] = new State(new int[]{8,531,10,-452},new int[]{-113,1512});
    states[1512] = new State(new int[]{10,1036},new int[]{-193,1186});
    states[1513] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,42,461},new int[]{-155,1514,-127,1049,-122,1050,-119,1051,-132,1056,-136,24,-137,27,-177,1057,-317,1059,-134,1063});
    states[1514] = new State(new int[]{8,531,5,-452,10,-452},new int[]{-113,1515});
    states[1515] = new State(new int[]{5,1516,10,1036},new int[]{-193,1221});
    states[1516] = new State(new int[]{137,358,80,25,81,26,75,28,73,29,148,154,150,155,149,156,110,377,109,378,138,149,140,150,139,152,8,388,136,393,21,399,45,407,46,513,31,517,71,521,62,524,41,529,34,587},new int[]{-259,1517,-260,395,-256,356,-85,175,-94,267,-95,268,-166,269,-132,196,-136,24,-137,27,-15,383,-185,384,-150,387,-152,147,-151,151,-257,390,-240,391,-233,392,-265,396,-266,397,-262,398,-254,405,-28,406,-247,512,-115,516,-116,520,-211,526,-209,527,-208,528,-285,591});
    states[1517] = new State(new int[]{10,1036},new int[]{-193,1225});
    states[1518] = new State(-70);
    states[1519] = new State(new int[]{49,14,56,-60,26,-60,64,-60,47,-60,50,-60,59,-60,11,-60,41,-60,34,-60,25,-60,23,-60,27,-60,28,-60,86,-60,97,-60,85,-60},new int[]{-38,1520,-39,1390});
    states[1520] = new State(-51);
    states[1521] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-124,1522,-132,1525,-136,24,-137,27});
    states[1522] = new State(new int[]{10,1523});
    states[1523] = new State(new int[]{3,1454,40,-12,86,-12,97,-12,85,-12,49,-12,56,-12,26,-12,64,-12,47,-12,50,-12,59,-12,11,-12,41,-12,34,-12,25,-12,23,-12,27,-12,28,-12},new int[]{-171,1524,-172,1452,-170,1457});
    states[1524] = new State(-44);
    states[1525] = new State(-48);
    states[1526] = new State(-46);
    states[1527] = new State(-47);
    states[1528] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,79,32,78,33,77,34,76,35,66,36,61,37,122,38,19,39,18,40,60,41,20,42,123,43,124,44,125,45,126,46,127,47,128,48,129,49,130,50,131,51,132,52,21,53,71,54,85,55,22,56,23,57,26,58,27,59,28,60,69,61,93,62,29,63,30,64,31,65,24,66,98,67,95,68,32,69,33,70,34,71,37,72,38,73,39,74,97,75,40,76,41,77,43,78,44,79,45,80,91,81,46,82,96,83,47,84,25,85,48,86,68,87,92,88,49,89,50,90,51,91,52,92,53,93,54,94,55,95,56,96,58,97,99,98,100,99,103,100,101,101,102,102,59,103,72,104,35,105,36,106,42,108,86,109},new int[]{-142,1529,-123,112,-132,22,-136,24,-137,27,-277,30,-135,31,-278,107});
    states[1529] = new State(new int[]{10,1530,7,20});
    states[1530] = new State(new int[]{3,1454,40,-12,86,-12,97,-12,85,-12,49,-12,56,-12,26,-12,64,-12,47,-12,50,-12,59,-12,11,-12,41,-12,34,-12,25,-12,23,-12,27,-12,28,-12},new int[]{-171,1531,-172,1452,-170,1457});
    states[1531] = new State(-45);
    states[1532] = new State(-4);
    states[1533] = new State(new int[]{47,1535,53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,493,18,247,19,252,5,642},new int[]{-81,1534,-91,127,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,445,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641});
    states[1534] = new State(-5);
    states[1535] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-129,1536,-132,1537,-136,24,-137,27});
    states[1536] = new State(-6);
    states[1537] = new State(new int[]{117,1053,2,-208},new int[]{-140,1298});
    states[1538] = new State(new int[]{137,23,80,25,81,26,75,28,73,29},new int[]{-303,1539,-304,1540,-132,1544,-136,24,-137,27});
    states[1539] = new State(-7);
    states[1540] = new State(new int[]{7,1541,117,168,2,-731},new int[]{-283,1543});
    states[1541] = new State(new int[]{137,23,80,25,81,26,75,28,73,29,79,32,78,33,77,34,76,35,66,36,61,37,122,38,19,39,18,40,60,41,20,42,123,43,124,44,125,45,126,46,127,47,128,48,129,49,130,50,131,51,132,52,21,53,71,54,85,55,22,56,23,57,26,58,27,59,28,60,69,61,93,62,29,63,30,64,31,65,24,66,98,67,95,68,32,69,33,70,34,71,37,72,38,73,39,74,97,75,40,76,41,77,43,78,44,79,45,80,91,81,46,82,96,83,47,84,25,85,48,86,68,87,92,88,49,89,50,90,51,91,52,92,53,93,54,94,55,95,56,96,58,97,99,98,100,99,103,100,101,101,102,102,59,103,72,104,35,105,36,106,42,108,86,109},new int[]{-123,1542,-132,22,-136,24,-137,27,-277,30,-135,31,-278,107});
    states[1542] = new State(-730);
    states[1543] = new State(-732);
    states[1544] = new State(-729);
    states[1545] = new State(new int[]{53,142,138,149,140,150,139,152,148,154,150,155,149,156,60,158,11,321,129,441,110,377,109,378,135,446,137,23,80,25,81,26,75,28,73,227,42,461,39,491,8,634,18,247,19,252,5,642,50,744},new int[]{-243,1546,-81,1547,-91,127,-90,132,-89,290,-93,298,-76,330,-88,320,-14,143,-150,146,-152,147,-151,151,-15,153,-53,157,-185,443,-100,1548,-117,435,-99,447,-132,459,-136,24,-137,27,-177,460,-241,544,-279,545,-16,546,-54,562,-103,568,-159,569,-252,570,-77,571,-248,574,-250,575,-251,622,-225,623,-105,641,-4,1549,-297,1550});
    states[1546] = new State(-8);
    states[1547] = new State(-9);
    states[1548] = new State(new int[]{104,485,105,486,106,487,107,488,108,489,132,-716,130,-716,112,-716,111,-716,125,-716,126,-716,127,-716,128,-716,124,-716,5,-716,110,-716,109,-716,122,-716,123,-716,120,-716,114,-716,119,-716,117,-716,115,-716,118,-716,116,-716,131,-716,16,-716,13,-716,2,-716,113,-716},new int[]{-180,124});
    states[1549] = new State(-10);
    states[1550] = new State(-11);

    rules[1] = new Rule(-341, new int[]{-1,2});
    rules[2] = new Rule(-1, new int[]{-219});
    rules[3] = new Rule(-1, new int[]{-289});
    rules[4] = new Rule(-1, new int[]{-161});
    rules[5] = new Rule(-161, new int[]{82,-81});
    rules[6] = new Rule(-161, new int[]{82,47,-129});
    rules[7] = new Rule(-161, new int[]{84,-303});
    rules[8] = new Rule(-161, new int[]{83,-243});
    rules[9] = new Rule(-243, new int[]{-81});
    rules[10] = new Rule(-243, new int[]{-4});
    rules[11] = new Rule(-243, new int[]{-297});
    rules[12] = new Rule(-171, new int[]{});
    rules[13] = new Rule(-171, new int[]{-172});
    rules[14] = new Rule(-172, new int[]{-170});
    rules[15] = new Rule(-172, new int[]{-172,-170});
    rules[16] = new Rule(-170, new int[]{3,137});
    rules[17] = new Rule(-170, new int[]{3,138});
    rules[18] = new Rule(-219, new int[]{-220,-171,-287,-17,-174});
    rules[19] = new Rule(-174, new int[]{7});
    rules[20] = new Rule(-174, new int[]{10});
    rules[21] = new Rule(-174, new int[]{5});
    rules[22] = new Rule(-174, new int[]{94});
    rules[23] = new Rule(-174, new int[]{6});
    rules[24] = new Rule(-174, new int[]{});
    rules[25] = new Rule(-220, new int[]{});
    rules[26] = new Rule(-220, new int[]{58,-132,-173});
    rules[27] = new Rule(-173, new int[]{10});
    rules[28] = new Rule(-173, new int[]{8,-175,9,10});
    rules[29] = new Rule(-175, new int[]{-131});
    rules[30] = new Rule(-175, new int[]{-175,94,-131});
    rules[31] = new Rule(-131, new int[]{-132});
    rules[32] = new Rule(-17, new int[]{-34,-239});
    rules[33] = new Rule(-34, new int[]{-38});
    rules[34] = new Rule(-142, new int[]{-123});
    rules[35] = new Rule(-142, new int[]{-142,7,-123});
    rules[36] = new Rule(-287, new int[]{});
    rules[37] = new Rule(-287, new int[]{-287,49,-288,10});
    rules[38] = new Rule(-288, new int[]{-290});
    rules[39] = new Rule(-288, new int[]{-288,94,-290});
    rules[40] = new Rule(-290, new int[]{-142});
    rules[41] = new Rule(-290, new int[]{-142,131,138});
    rules[42] = new Rule(-289, new int[]{-6,-291,-147,-146,-139,7});
    rules[43] = new Rule(-289, new int[]{-6,-291,-148,-139,7});
    rules[44] = new Rule(-291, new int[]{-2,-124,10,-171});
    rules[45] = new Rule(-291, new int[]{103,-142,10,-171});
    rules[46] = new Rule(-2, new int[]{99});
    rules[47] = new Rule(-2, new int[]{100});
    rules[48] = new Rule(-124, new int[]{-132});
    rules[49] = new Rule(-147, new int[]{40,-287,-37});
    rules[50] = new Rule(-146, new int[]{38,-287,-38});
    rules[51] = new Rule(-148, new int[]{-287,-38});
    rules[52] = new Rule(-139, new int[]{86});
    rules[53] = new Rule(-139, new int[]{97,-236,86});
    rules[54] = new Rule(-139, new int[]{97,-236,98,-236,86});
    rules[55] = new Rule(-139, new int[]{85,-236,86});
    rules[56] = new Rule(-37, new int[]{-35});
    rules[57] = new Rule(-35, new int[]{});
    rules[58] = new Rule(-35, new int[]{-35,-44});
    rules[59] = new Rule(-38, new int[]{-39});
    rules[60] = new Rule(-39, new int[]{});
    rules[61] = new Rule(-39, new int[]{-39,-43});
    rules[62] = new Rule(-40, new int[]{-36});
    rules[63] = new Rule(-36, new int[]{});
    rules[64] = new Rule(-36, new int[]{-36,-42});
    rules[65] = new Rule(-44, new int[]{-26});
    rules[66] = new Rule(-44, new int[]{-48});
    rules[67] = new Rule(-44, new int[]{-273});
    rules[68] = new Rule(-44, new int[]{-292});
    rules[69] = new Rule(-44, new int[]{-217});
    rules[70] = new Rule(-44, new int[]{-216});
    rules[71] = new Rule(-43, new int[]{-153});
    rules[72] = new Rule(-43, new int[]{-26});
    rules[73] = new Rule(-43, new int[]{-48});
    rules[74] = new Rule(-43, new int[]{-273});
    rules[75] = new Rule(-43, new int[]{-292});
    rules[76] = new Rule(-43, new int[]{-205});
    rules[77] = new Rule(-198, new int[]{-199});
    rules[78] = new Rule(-198, new int[]{-202});
    rules[79] = new Rule(-205, new int[]{-6,-198});
    rules[80] = new Rule(-42, new int[]{-153});
    rules[81] = new Rule(-42, new int[]{-26});
    rules[82] = new Rule(-42, new int[]{-48});
    rules[83] = new Rule(-42, new int[]{-273});
    rules[84] = new Rule(-42, new int[]{-292});
    rules[85] = new Rule(-217, new int[]{-6,-210});
    rules[86] = new Rule(-217, new int[]{-6,-210,142,10});
    rules[87] = new Rule(-216, new int[]{-6,-214});
    rules[88] = new Rule(-216, new int[]{-6,-214,142,10});
    rules[89] = new Rule(-153, new int[]{56,-141,10});
    rules[90] = new Rule(-141, new int[]{-128});
    rules[91] = new Rule(-141, new int[]{-141,94,-128});
    rules[92] = new Rule(-128, new int[]{148});
    rules[93] = new Rule(-128, new int[]{149});
    rules[94] = new Rule(-128, new int[]{-132});
    rules[95] = new Rule(-26, new int[]{26,-24});
    rules[96] = new Rule(-26, new int[]{-26,-24});
    rules[97] = new Rule(-48, new int[]{64,-24});
    rules[98] = new Rule(-48, new int[]{-48,-24});
    rules[99] = new Rule(-273, new int[]{47,-45});
    rules[100] = new Rule(-273, new int[]{-273,-45});
    rules[101] = new Rule(-296, new int[]{-293});
    rules[102] = new Rule(-296, new int[]{8,-132,94,-143,9,104,-91,10});
    rules[103] = new Rule(-292, new int[]{50,-296});
    rules[104] = new Rule(-292, new int[]{59,-296});
    rules[105] = new Rule(-292, new int[]{-292,-296});
    rules[106] = new Rule(-24, new int[]{-25,10});
    rules[107] = new Rule(-25, new int[]{-126,114,-97});
    rules[108] = new Rule(-25, new int[]{-126,5,-260,114,-78});
    rules[109] = new Rule(-97, new int[]{-83});
    rules[110] = new Rule(-97, new int[]{-87});
    rules[111] = new Rule(-126, new int[]{-132});
    rules[112] = new Rule(-73, new int[]{-91});
    rules[113] = new Rule(-73, new int[]{-73,94,-91});
    rules[114] = new Rule(-83, new int[]{-75});
    rules[115] = new Rule(-83, new int[]{-75,-178,-75});
    rules[116] = new Rule(-83, new int[]{-226});
    rules[117] = new Rule(-226, new int[]{-83,13,-83,5,-83});
    rules[118] = new Rule(-178, new int[]{114});
    rules[119] = new Rule(-178, new int[]{119});
    rules[120] = new Rule(-178, new int[]{117});
    rules[121] = new Rule(-178, new int[]{115});
    rules[122] = new Rule(-178, new int[]{118});
    rules[123] = new Rule(-178, new int[]{116});
    rules[124] = new Rule(-178, new int[]{131});
    rules[125] = new Rule(-75, new int[]{-12});
    rules[126] = new Rule(-75, new int[]{-75,-179,-12});
    rules[127] = new Rule(-179, new int[]{110});
    rules[128] = new Rule(-179, new int[]{109});
    rules[129] = new Rule(-179, new int[]{122});
    rules[130] = new Rule(-179, new int[]{123});
    rules[131] = new Rule(-249, new int[]{-12,-187,-268});
    rules[132] = new Rule(-253, new int[]{-10,113,-10});
    rules[133] = new Rule(-12, new int[]{-10});
    rules[134] = new Rule(-12, new int[]{-249});
    rules[135] = new Rule(-12, new int[]{-253});
    rules[136] = new Rule(-12, new int[]{-12,-181,-10});
    rules[137] = new Rule(-12, new int[]{-12,-181,-253});
    rules[138] = new Rule(-181, new int[]{112});
    rules[139] = new Rule(-181, new int[]{111});
    rules[140] = new Rule(-181, new int[]{125});
    rules[141] = new Rule(-181, new int[]{126});
    rules[142] = new Rule(-181, new int[]{127});
    rules[143] = new Rule(-181, new int[]{128});
    rules[144] = new Rule(-181, new int[]{124});
    rules[145] = new Rule(-10, new int[]{-13});
    rules[146] = new Rule(-10, new int[]{-224});
    rules[147] = new Rule(-10, new int[]{53});
    rules[148] = new Rule(-10, new int[]{135,-10});
    rules[149] = new Rule(-10, new int[]{8,-83,9});
    rules[150] = new Rule(-10, new int[]{129,-10});
    rules[151] = new Rule(-10, new int[]{-185,-10});
    rules[152] = new Rule(-10, new int[]{-159});
    rules[153] = new Rule(-224, new int[]{11,-69,12});
    rules[154] = new Rule(-185, new int[]{110});
    rules[155] = new Rule(-185, new int[]{109});
    rules[156] = new Rule(-13, new int[]{-132});
    rules[157] = new Rule(-13, new int[]{-150});
    rules[158] = new Rule(-13, new int[]{-15});
    rules[159] = new Rule(-13, new int[]{39,-132});
    rules[160] = new Rule(-13, new int[]{-241});
    rules[161] = new Rule(-13, new int[]{-279});
    rules[162] = new Rule(-13, new int[]{-13,-11});
    rules[163] = new Rule(-13, new int[]{-13,4,-283});
    rules[164] = new Rule(-13, new int[]{-13,11,-106,12});
    rules[165] = new Rule(-11, new int[]{7,-123});
    rules[166] = new Rule(-11, new int[]{136});
    rules[167] = new Rule(-11, new int[]{8,-70,9});
    rules[168] = new Rule(-11, new int[]{11,-69,12});
    rules[169] = new Rule(-70, new int[]{-66});
    rules[170] = new Rule(-70, new int[]{});
    rules[171] = new Rule(-69, new int[]{-67});
    rules[172] = new Rule(-69, new int[]{});
    rules[173] = new Rule(-67, new int[]{-86});
    rules[174] = new Rule(-67, new int[]{-67,94,-86});
    rules[175] = new Rule(-86, new int[]{-83});
    rules[176] = new Rule(-86, new int[]{-83,6,-83});
    rules[177] = new Rule(-15, new int[]{148});
    rules[178] = new Rule(-15, new int[]{150});
    rules[179] = new Rule(-15, new int[]{149});
    rules[180] = new Rule(-78, new int[]{-83});
    rules[181] = new Rule(-78, new int[]{-87});
    rules[182] = new Rule(-78, new int[]{-227});
    rules[183] = new Rule(-87, new int[]{8,-62,9});
    rules[184] = new Rule(-87, new int[]{8,-227,9});
    rules[185] = new Rule(-87, new int[]{8,-87,9});
    rules[186] = new Rule(-62, new int[]{});
    rules[187] = new Rule(-62, new int[]{-61});
    rules[188] = new Rule(-61, new int[]{-79});
    rules[189] = new Rule(-61, new int[]{-61,94,-79});
    rules[190] = new Rule(-227, new int[]{8,-229,9});
    rules[191] = new Rule(-229, new int[]{-228});
    rules[192] = new Rule(-229, new int[]{-228,10});
    rules[193] = new Rule(-228, new int[]{-230});
    rules[194] = new Rule(-228, new int[]{-228,10,-230});
    rules[195] = new Rule(-230, new int[]{-121,5,-78});
    rules[196] = new Rule(-121, new int[]{-132});
    rules[197] = new Rule(-45, new int[]{-6,-46});
    rules[198] = new Rule(-6, new int[]{-234});
    rules[199] = new Rule(-6, new int[]{-6,-234});
    rules[200] = new Rule(-6, new int[]{});
    rules[201] = new Rule(-234, new int[]{11,-235,12});
    rules[202] = new Rule(-235, new int[]{-8});
    rules[203] = new Rule(-235, new int[]{-235,94,-8});
    rules[204] = new Rule(-8, new int[]{-9});
    rules[205] = new Rule(-8, new int[]{-132,5,-9});
    rules[206] = new Rule(-46, new int[]{-129,114,-271,10});
    rules[207] = new Rule(-46, new int[]{-130,-271,10});
    rules[208] = new Rule(-129, new int[]{-132});
    rules[209] = new Rule(-129, new int[]{-132,-140});
    rules[210] = new Rule(-130, new int[]{-132,117,-143,116});
    rules[211] = new Rule(-271, new int[]{-260});
    rules[212] = new Rule(-271, new int[]{-27});
    rules[213] = new Rule(-257, new int[]{-256,13});
    rules[214] = new Rule(-260, new int[]{-256});
    rules[215] = new Rule(-260, new int[]{-257});
    rules[216] = new Rule(-260, new int[]{-240});
    rules[217] = new Rule(-260, new int[]{-233});
    rules[218] = new Rule(-260, new int[]{-265});
    rules[219] = new Rule(-260, new int[]{-211});
    rules[220] = new Rule(-260, new int[]{-285});
    rules[221] = new Rule(-285, new int[]{-166,-283});
    rules[222] = new Rule(-283, new int[]{117,-281,115});
    rules[223] = new Rule(-284, new int[]{119});
    rules[224] = new Rule(-284, new int[]{117,-282,115});
    rules[225] = new Rule(-281, new int[]{-263});
    rules[226] = new Rule(-281, new int[]{-281,94,-263});
    rules[227] = new Rule(-282, new int[]{-264});
    rules[228] = new Rule(-282, new int[]{-282,94,-264});
    rules[229] = new Rule(-264, new int[]{});
    rules[230] = new Rule(-263, new int[]{-256});
    rules[231] = new Rule(-263, new int[]{-256,13});
    rules[232] = new Rule(-263, new int[]{-265});
    rules[233] = new Rule(-263, new int[]{-211});
    rules[234] = new Rule(-263, new int[]{-285});
    rules[235] = new Rule(-256, new int[]{-85});
    rules[236] = new Rule(-256, new int[]{-85,6,-85});
    rules[237] = new Rule(-256, new int[]{8,-74,9});
    rules[238] = new Rule(-85, new int[]{-94});
    rules[239] = new Rule(-85, new int[]{-85,-179,-94});
    rules[240] = new Rule(-94, new int[]{-95});
    rules[241] = new Rule(-94, new int[]{-94,-181,-95});
    rules[242] = new Rule(-95, new int[]{-166});
    rules[243] = new Rule(-95, new int[]{-15});
    rules[244] = new Rule(-95, new int[]{-185,-95});
    rules[245] = new Rule(-95, new int[]{-150});
    rules[246] = new Rule(-95, new int[]{-95,8,-69,9});
    rules[247] = new Rule(-166, new int[]{-132});
    rules[248] = new Rule(-166, new int[]{-166,7,-123});
    rules[249] = new Rule(-74, new int[]{-72,94,-72});
    rules[250] = new Rule(-74, new int[]{-74,94,-72});
    rules[251] = new Rule(-72, new int[]{-260});
    rules[252] = new Rule(-72, new int[]{-260,114,-81});
    rules[253] = new Rule(-233, new int[]{136,-259});
    rules[254] = new Rule(-265, new int[]{-266});
    rules[255] = new Rule(-265, new int[]{62,-266});
    rules[256] = new Rule(-266, new int[]{-262});
    rules[257] = new Rule(-266, new int[]{-28});
    rules[258] = new Rule(-266, new int[]{-247});
    rules[259] = new Rule(-266, new int[]{-115});
    rules[260] = new Rule(-266, new int[]{-116});
    rules[261] = new Rule(-116, new int[]{71,55,-260});
    rules[262] = new Rule(-262, new int[]{21,11,-149,12,55,-260});
    rules[263] = new Rule(-262, new int[]{-254});
    rules[264] = new Rule(-254, new int[]{21,55,-260});
    rules[265] = new Rule(-149, new int[]{-255});
    rules[266] = new Rule(-149, new int[]{-149,94,-255});
    rules[267] = new Rule(-255, new int[]{-256});
    rules[268] = new Rule(-255, new int[]{});
    rules[269] = new Rule(-247, new int[]{46,55,-260});
    rules[270] = new Rule(-115, new int[]{31,55,-260});
    rules[271] = new Rule(-115, new int[]{31});
    rules[272] = new Rule(-240, new int[]{137,11,-83,12});
    rules[273] = new Rule(-211, new int[]{-209});
    rules[274] = new Rule(-209, new int[]{-208});
    rules[275] = new Rule(-208, new int[]{41,-113});
    rules[276] = new Rule(-208, new int[]{34,-113,5,-259});
    rules[277] = new Rule(-208, new int[]{-166,121,-263});
    rules[278] = new Rule(-208, new int[]{-285,121,-263});
    rules[279] = new Rule(-208, new int[]{8,9,121,-263});
    rules[280] = new Rule(-208, new int[]{8,-74,9,121,-263});
    rules[281] = new Rule(-208, new int[]{-166,121,8,9});
    rules[282] = new Rule(-208, new int[]{-285,121,8,9});
    rules[283] = new Rule(-208, new int[]{8,9,121,8,9});
    rules[284] = new Rule(-208, new int[]{8,-74,9,121,8,9});
    rules[285] = new Rule(-27, new int[]{-20,-275,-169,-300,-23});
    rules[286] = new Rule(-28, new int[]{45,-169,-300,-22,86});
    rules[287] = new Rule(-19, new int[]{66});
    rules[288] = new Rule(-19, new int[]{67});
    rules[289] = new Rule(-19, new int[]{141});
    rules[290] = new Rule(-19, new int[]{24});
    rules[291] = new Rule(-19, new int[]{25});
    rules[292] = new Rule(-20, new int[]{});
    rules[293] = new Rule(-20, new int[]{-21});
    rules[294] = new Rule(-21, new int[]{-19});
    rules[295] = new Rule(-21, new int[]{-21,-19});
    rules[296] = new Rule(-275, new int[]{23});
    rules[297] = new Rule(-275, new int[]{40});
    rules[298] = new Rule(-275, new int[]{61});
    rules[299] = new Rule(-275, new int[]{61,23});
    rules[300] = new Rule(-275, new int[]{61,45});
    rules[301] = new Rule(-275, new int[]{61,40});
    rules[302] = new Rule(-23, new int[]{});
    rules[303] = new Rule(-23, new int[]{-22,86});
    rules[304] = new Rule(-169, new int[]{});
    rules[305] = new Rule(-169, new int[]{8,-168,9});
    rules[306] = new Rule(-168, new int[]{-167});
    rules[307] = new Rule(-168, new int[]{-168,94,-167});
    rules[308] = new Rule(-167, new int[]{-166});
    rules[309] = new Rule(-167, new int[]{-285});
    rules[310] = new Rule(-140, new int[]{117,-143,115});
    rules[311] = new Rule(-300, new int[]{});
    rules[312] = new Rule(-300, new int[]{-299});
    rules[313] = new Rule(-299, new int[]{-298});
    rules[314] = new Rule(-299, new int[]{-299,-298});
    rules[315] = new Rule(-298, new int[]{20,-143,5,-272,10});
    rules[316] = new Rule(-272, new int[]{-269});
    rules[317] = new Rule(-272, new int[]{-272,94,-269});
    rules[318] = new Rule(-269, new int[]{-260});
    rules[319] = new Rule(-269, new int[]{23});
    rules[320] = new Rule(-269, new int[]{45});
    rules[321] = new Rule(-269, new int[]{27});
    rules[322] = new Rule(-22, new int[]{-29});
    rules[323] = new Rule(-22, new int[]{-22,-7,-29});
    rules[324] = new Rule(-7, new int[]{79});
    rules[325] = new Rule(-7, new int[]{78});
    rules[326] = new Rule(-7, new int[]{77});
    rules[327] = new Rule(-7, new int[]{76});
    rules[328] = new Rule(-29, new int[]{});
    rules[329] = new Rule(-29, new int[]{-31,-176});
    rules[330] = new Rule(-29, new int[]{-30});
    rules[331] = new Rule(-29, new int[]{-31,10,-30});
    rules[332] = new Rule(-143, new int[]{-132});
    rules[333] = new Rule(-143, new int[]{-143,94,-132});
    rules[334] = new Rule(-176, new int[]{});
    rules[335] = new Rule(-176, new int[]{10});
    rules[336] = new Rule(-31, new int[]{-41});
    rules[337] = new Rule(-31, new int[]{-31,10,-41});
    rules[338] = new Rule(-41, new int[]{-6,-47});
    rules[339] = new Rule(-30, new int[]{-50});
    rules[340] = new Rule(-30, new int[]{-30,-50});
    rules[341] = new Rule(-50, new int[]{-49});
    rules[342] = new Rule(-50, new int[]{-51});
    rules[343] = new Rule(-47, new int[]{26,-25});
    rules[344] = new Rule(-47, new int[]{-295});
    rules[345] = new Rule(-47, new int[]{-3,-295});
    rules[346] = new Rule(-3, new int[]{25});
    rules[347] = new Rule(-3, new int[]{23});
    rules[348] = new Rule(-295, new int[]{-294});
    rules[349] = new Rule(-295, new int[]{59,-143,5,-260});
    rules[350] = new Rule(-49, new int[]{-6,-207});
    rules[351] = new Rule(-49, new int[]{-6,-204});
    rules[352] = new Rule(-204, new int[]{-200});
    rules[353] = new Rule(-204, new int[]{-203});
    rules[354] = new Rule(-207, new int[]{-3,-215});
    rules[355] = new Rule(-207, new int[]{-215});
    rules[356] = new Rule(-207, new int[]{-212});
    rules[357] = new Rule(-215, new int[]{-213});
    rules[358] = new Rule(-213, new int[]{-210});
    rules[359] = new Rule(-213, new int[]{-214});
    rules[360] = new Rule(-212, new int[]{27,-157,-113,-193});
    rules[361] = new Rule(-212, new int[]{-3,27,-157,-113,-193});
    rules[362] = new Rule(-212, new int[]{28,-157,-113,-193});
    rules[363] = new Rule(-157, new int[]{-156});
    rules[364] = new Rule(-157, new int[]{});
    rules[365] = new Rule(-158, new int[]{-132});
    rules[366] = new Rule(-158, new int[]{-135});
    rules[367] = new Rule(-158, new int[]{-158,7,-132});
    rules[368] = new Rule(-158, new int[]{-158,7,-135});
    rules[369] = new Rule(-51, new int[]{-6,-242});
    rules[370] = new Rule(-242, new int[]{43,-158,-218,-188,10,-191});
    rules[371] = new Rule(-242, new int[]{43,-158,-218,-188,10,-196,10,-191});
    rules[372] = new Rule(-242, new int[]{-3,43,-158,-218,-188,10,-191});
    rules[373] = new Rule(-242, new int[]{-3,43,-158,-218,-188,10,-196,10,-191});
    rules[374] = new Rule(-242, new int[]{24,43,-158,-218,10});
    rules[375] = new Rule(-242, new int[]{-3,24,43,-158,-218,10});
    rules[376] = new Rule(-191, new int[]{});
    rules[377] = new Rule(-191, new int[]{60,10});
    rules[378] = new Rule(-218, new int[]{-223,5,-259});
    rules[379] = new Rule(-223, new int[]{});
    rules[380] = new Rule(-223, new int[]{11,-222,12});
    rules[381] = new Rule(-222, new int[]{-221});
    rules[382] = new Rule(-222, new int[]{-222,10,-221});
    rules[383] = new Rule(-221, new int[]{-143,5,-259});
    rules[384] = new Rule(-101, new int[]{-82});
    rules[385] = new Rule(-101, new int[]{});
    rules[386] = new Rule(-188, new int[]{});
    rules[387] = new Rule(-188, new int[]{80,-101,-189});
    rules[388] = new Rule(-188, new int[]{81,-244,-190});
    rules[389] = new Rule(-189, new int[]{});
    rules[390] = new Rule(-189, new int[]{81,-244});
    rules[391] = new Rule(-190, new int[]{});
    rules[392] = new Rule(-190, new int[]{80,-101});
    rules[393] = new Rule(-293, new int[]{-294,10});
    rules[394] = new Rule(-321, new int[]{104});
    rules[395] = new Rule(-321, new int[]{114});
    rules[396] = new Rule(-294, new int[]{-143,5,-260});
    rules[397] = new Rule(-294, new int[]{-143,104,-81});
    rules[398] = new Rule(-294, new int[]{-143,5,-260,-321,-80});
    rules[399] = new Rule(-80, new int[]{-79});
    rules[400] = new Rule(-80, new int[]{-306});
    rules[401] = new Rule(-80, new int[]{-132,121,-311});
    rules[402] = new Rule(-80, new int[]{8,9,-307,121,-311});
    rules[403] = new Rule(-80, new int[]{8,-62,9,121,-311});
    rules[404] = new Rule(-79, new int[]{-78});
    rules[405] = new Rule(-79, new int[]{-53});
    rules[406] = new Rule(-202, new int[]{-212,-163});
    rules[407] = new Rule(-202, new int[]{27,-157,-113,104,-244,10});
    rules[408] = new Rule(-202, new int[]{-3,27,-157,-113,104,-244,10});
    rules[409] = new Rule(-203, new int[]{-212,-162});
    rules[410] = new Rule(-203, new int[]{27,-157,-113,104,-244,10});
    rules[411] = new Rule(-203, new int[]{-3,27,-157,-113,104,-244,10});
    rules[412] = new Rule(-199, new int[]{-206});
    rules[413] = new Rule(-199, new int[]{-3,-206});
    rules[414] = new Rule(-206, new int[]{-213,-164});
    rules[415] = new Rule(-206, new int[]{34,-155,-113,5,-259,-194,104,-91,10});
    rules[416] = new Rule(-206, new int[]{34,-155,-113,-194,104,-91,10});
    rules[417] = new Rule(-206, new int[]{34,-155,-113,5,-259,-194,104,-305,10});
    rules[418] = new Rule(-206, new int[]{34,-155,-113,-194,104,-305,10});
    rules[419] = new Rule(-206, new int[]{41,-156,-113,-194,104,-244,10});
    rules[420] = new Rule(-206, new int[]{-213,142,10});
    rules[421] = new Rule(-200, new int[]{-201});
    rules[422] = new Rule(-200, new int[]{-3,-201});
    rules[423] = new Rule(-201, new int[]{-213,-162});
    rules[424] = new Rule(-201, new int[]{34,-155,-113,5,-259,-194,104,-92,10});
    rules[425] = new Rule(-201, new int[]{34,-155,-113,-194,104,-92,10});
    rules[426] = new Rule(-201, new int[]{41,-156,-113,-194,104,-244,10});
    rules[427] = new Rule(-164, new int[]{-163});
    rules[428] = new Rule(-164, new int[]{-57});
    rules[429] = new Rule(-156, new int[]{-155});
    rules[430] = new Rule(-155, new int[]{-127});
    rules[431] = new Rule(-155, new int[]{-317,7,-127});
    rules[432] = new Rule(-134, new int[]{-122});
    rules[433] = new Rule(-317, new int[]{-134});
    rules[434] = new Rule(-317, new int[]{-317,7,-134});
    rules[435] = new Rule(-127, new int[]{-122});
    rules[436] = new Rule(-127, new int[]{-177});
    rules[437] = new Rule(-127, new int[]{-177,-140});
    rules[438] = new Rule(-122, new int[]{-119});
    rules[439] = new Rule(-122, new int[]{-119,-140});
    rules[440] = new Rule(-119, new int[]{-132});
    rules[441] = new Rule(-210, new int[]{41,-156,-113,-193,-300});
    rules[442] = new Rule(-214, new int[]{34,-155,-113,-193,-300});
    rules[443] = new Rule(-214, new int[]{34,-155,-113,5,-259,-193,-300});
    rules[444] = new Rule(-57, new int[]{101,-96,75,-96,10});
    rules[445] = new Rule(-57, new int[]{101,-96,10});
    rules[446] = new Rule(-57, new int[]{101,10});
    rules[447] = new Rule(-96, new int[]{-132});
    rules[448] = new Rule(-96, new int[]{-150});
    rules[449] = new Rule(-163, new int[]{-38,-239,10});
    rules[450] = new Rule(-162, new int[]{-40,-239,10});
    rules[451] = new Rule(-162, new int[]{-57});
    rules[452] = new Rule(-113, new int[]{});
    rules[453] = new Rule(-113, new int[]{8,9});
    rules[454] = new Rule(-113, new int[]{8,-114,9});
    rules[455] = new Rule(-114, new int[]{-52});
    rules[456] = new Rule(-114, new int[]{-114,10,-52});
    rules[457] = new Rule(-52, new int[]{-6,-280});
    rules[458] = new Rule(-280, new int[]{-144,5,-259});
    rules[459] = new Rule(-280, new int[]{50,-144,5,-259});
    rules[460] = new Rule(-280, new int[]{26,-144,5,-259});
    rules[461] = new Rule(-280, new int[]{102,-144,5,-259});
    rules[462] = new Rule(-280, new int[]{-144,5,-259,104,-81});
    rules[463] = new Rule(-280, new int[]{50,-144,5,-259,104,-81});
    rules[464] = new Rule(-280, new int[]{26,-144,5,-259,104,-81});
    rules[465] = new Rule(-144, new int[]{-120});
    rules[466] = new Rule(-144, new int[]{-144,94,-120});
    rules[467] = new Rule(-120, new int[]{-132});
    rules[468] = new Rule(-259, new int[]{-260});
    rules[469] = new Rule(-261, new int[]{-256});
    rules[470] = new Rule(-261, new int[]{-240});
    rules[471] = new Rule(-261, new int[]{-233});
    rules[472] = new Rule(-261, new int[]{-265});
    rules[473] = new Rule(-261, new int[]{-285});
    rules[474] = new Rule(-245, new int[]{-244});
    rules[475] = new Rule(-245, new int[]{-128,5,-245});
    rules[476] = new Rule(-244, new int[]{});
    rules[477] = new Rule(-244, new int[]{-4});
    rules[478] = new Rule(-244, new int[]{-197});
    rules[479] = new Rule(-244, new int[]{-118});
    rules[480] = new Rule(-244, new int[]{-239});
    rules[481] = new Rule(-244, new int[]{-138});
    rules[482] = new Rule(-244, new int[]{-32});
    rules[483] = new Rule(-244, new int[]{-231});
    rules[484] = new Rule(-244, new int[]{-301});
    rules[485] = new Rule(-244, new int[]{-109});
    rules[486] = new Rule(-244, new int[]{-302});
    rules[487] = new Rule(-244, new int[]{-145});
    rules[488] = new Rule(-244, new int[]{-286});
    rules[489] = new Rule(-244, new int[]{-232});
    rules[490] = new Rule(-244, new int[]{-108});
    rules[491] = new Rule(-244, new int[]{-297});
    rules[492] = new Rule(-244, new int[]{-55});
    rules[493] = new Rule(-244, new int[]{-154});
    rules[494] = new Rule(-244, new int[]{-111});
    rules[495] = new Rule(-244, new int[]{-112});
    rules[496] = new Rule(-244, new int[]{-110});
    rules[497] = new Rule(-244, new int[]{-330});
    rules[498] = new Rule(-110, new int[]{70,-91,93,-244});
    rules[499] = new Rule(-111, new int[]{72,-91});
    rules[500] = new Rule(-112, new int[]{72,71,-91});
    rules[501] = new Rule(-297, new int[]{50,-294});
    rules[502] = new Rule(-297, new int[]{8,50,-132,94,-320,9,104,-81});
    rules[503] = new Rule(-297, new int[]{50,8,-132,94,-143,9,104,-81});
    rules[504] = new Rule(-4, new int[]{-100,-180,-82});
    rules[505] = new Rule(-4, new int[]{8,-99,94,-319,9,-180,-81});
    rules[506] = new Rule(-319, new int[]{-99});
    rules[507] = new Rule(-319, new int[]{-319,94,-99});
    rules[508] = new Rule(-320, new int[]{50,-132});
    rules[509] = new Rule(-320, new int[]{-320,94,50,-132});
    rules[510] = new Rule(-197, new int[]{-100});
    rules[511] = new Rule(-118, new int[]{54,-128});
    rules[512] = new Rule(-239, new int[]{85,-236,86});
    rules[513] = new Rule(-236, new int[]{-245});
    rules[514] = new Rule(-236, new int[]{-236,10,-245});
    rules[515] = new Rule(-138, new int[]{37,-91,48,-244});
    rules[516] = new Rule(-138, new int[]{37,-91,48,-244,29,-244});
    rules[517] = new Rule(-330, new int[]{35,-91,52,-332,-237,86});
    rules[518] = new Rule(-330, new int[]{35,-91,52,-332,10,-237,86});
    rules[519] = new Rule(-332, new int[]{-331});
    rules[520] = new Rule(-332, new int[]{-332,10,-331});
    rules[521] = new Rule(-331, new int[]{-323,36,-91,5,-244});
    rules[522] = new Rule(-331, new int[]{-323,5,-244});
    rules[523] = new Rule(-331, new int[]{-324,36,-91,5,-244});
    rules[524] = new Rule(-331, new int[]{-324,5,-244});
    rules[525] = new Rule(-331, new int[]{-325,5,-244});
    rules[526] = new Rule(-331, new int[]{-326,5,-244});
    rules[527] = new Rule(-32, new int[]{22,-91,55,-33,-237,86});
    rules[528] = new Rule(-32, new int[]{22,-91,55,-33,10,-237,86});
    rules[529] = new Rule(-32, new int[]{22,-91,55,-237,86});
    rules[530] = new Rule(-33, new int[]{-246});
    rules[531] = new Rule(-33, new int[]{-33,10,-246});
    rules[532] = new Rule(-246, new int[]{-68,5,-244});
    rules[533] = new Rule(-68, new int[]{-98});
    rules[534] = new Rule(-68, new int[]{-68,94,-98});
    rules[535] = new Rule(-98, new int[]{-86});
    rules[536] = new Rule(-237, new int[]{});
    rules[537] = new Rule(-237, new int[]{29,-236});
    rules[538] = new Rule(-231, new int[]{91,-236,92,-81});
    rules[539] = new Rule(-301, new int[]{51,-91,-276,-244});
    rules[540] = new Rule(-276, new int[]{93});
    rules[541] = new Rule(-276, new int[]{});
    rules[542] = new Rule(-154, new int[]{57,-91,93,-244});
    rules[543] = new Rule(-108, new int[]{33,-132,-258,131,-91,93,-244});
    rules[544] = new Rule(-108, new int[]{33,50,-132,5,-260,131,-91,93,-244});
    rules[545] = new Rule(-108, new int[]{33,50,-132,131,-91,93,-244});
    rules[546] = new Rule(-258, new int[]{5,-260});
    rules[547] = new Rule(-258, new int[]{});
    rules[548] = new Rule(-109, new int[]{32,-18,-132,-270,-91,-104,-91,-276,-244});
    rules[549] = new Rule(-18, new int[]{50});
    rules[550] = new Rule(-18, new int[]{});
    rules[551] = new Rule(-270, new int[]{104});
    rules[552] = new Rule(-270, new int[]{5,-166,104});
    rules[553] = new Rule(-104, new int[]{68});
    rules[554] = new Rule(-104, new int[]{69});
    rules[555] = new Rule(-302, new int[]{52,-66,93,-244});
    rules[556] = new Rule(-145, new int[]{39});
    rules[557] = new Rule(-286, new int[]{96,-236,-274});
    rules[558] = new Rule(-274, new int[]{95,-236,86});
    rules[559] = new Rule(-274, new int[]{30,-56,86});
    rules[560] = new Rule(-56, new int[]{-59,-238});
    rules[561] = new Rule(-56, new int[]{-59,10,-238});
    rules[562] = new Rule(-56, new int[]{-236});
    rules[563] = new Rule(-59, new int[]{-58});
    rules[564] = new Rule(-59, new int[]{-59,10,-58});
    rules[565] = new Rule(-238, new int[]{});
    rules[566] = new Rule(-238, new int[]{29,-236});
    rules[567] = new Rule(-58, new int[]{74,-60,93,-244});
    rules[568] = new Rule(-60, new int[]{-165});
    rules[569] = new Rule(-60, new int[]{-125,5,-165});
    rules[570] = new Rule(-165, new int[]{-166});
    rules[571] = new Rule(-125, new int[]{-132});
    rules[572] = new Rule(-232, new int[]{44});
    rules[573] = new Rule(-232, new int[]{44,-81});
    rules[574] = new Rule(-66, new int[]{-82});
    rules[575] = new Rule(-66, new int[]{-66,94,-82});
    rules[576] = new Rule(-55, new int[]{-160});
    rules[577] = new Rule(-160, new int[]{-159});
    rules[578] = new Rule(-82, new int[]{-81});
    rules[579] = new Rule(-82, new int[]{-305});
    rules[580] = new Rule(-81, new int[]{-91});
    rules[581] = new Rule(-81, new int[]{-105});
    rules[582] = new Rule(-91, new int[]{-90});
    rules[583] = new Rule(-91, new int[]{-225});
    rules[584] = new Rule(-92, new int[]{-91});
    rules[585] = new Rule(-92, new int[]{-305});
    rules[586] = new Rule(-90, new int[]{-89});
    rules[587] = new Rule(-90, new int[]{-90,16,-89});
    rules[588] = new Rule(-241, new int[]{18,8,-268,9});
    rules[589] = new Rule(-279, new int[]{19,8,-268,9});
    rules[590] = new Rule(-279, new int[]{19,8,-267,9});
    rules[591] = new Rule(-225, new int[]{-91,13,-91,5,-91});
    rules[592] = new Rule(-267, new int[]{-166,-284});
    rules[593] = new Rule(-267, new int[]{-166,4,-284});
    rules[594] = new Rule(-268, new int[]{-166});
    rules[595] = new Rule(-268, new int[]{-166,-283});
    rules[596] = new Rule(-268, new int[]{-166,4,-283});
    rules[597] = new Rule(-5, new int[]{8,-62,9});
    rules[598] = new Rule(-5, new int[]{});
    rules[599] = new Rule(-159, new int[]{73,-268,-65});
    rules[600] = new Rule(-159, new int[]{73,-268,11,-63,12,-5});
    rules[601] = new Rule(-159, new int[]{73,23,8,-316,9});
    rules[602] = new Rule(-315, new int[]{-132,104,-89});
    rules[603] = new Rule(-315, new int[]{-89});
    rules[604] = new Rule(-316, new int[]{-315});
    rules[605] = new Rule(-316, new int[]{-316,94,-315});
    rules[606] = new Rule(-65, new int[]{});
    rules[607] = new Rule(-65, new int[]{8,-63,9});
    rules[608] = new Rule(-89, new int[]{-93});
    rules[609] = new Rule(-89, new int[]{-89,-182,-93});
    rules[610] = new Rule(-89, new int[]{-250,8,-336,9});
    rules[611] = new Rule(-89, new int[]{-76,132,-325});
    rules[612] = new Rule(-89, new int[]{-76,132,-326});
    rules[613] = new Rule(-322, new int[]{-268,8,-336,9});
    rules[614] = new Rule(-323, new int[]{-268,8,-337,9});
    rules[615] = new Rule(-325, new int[]{11,-338,12});
    rules[616] = new Rule(-338, new int[]{-327});
    rules[617] = new Rule(-338, new int[]{-338,94,-327});
    rules[618] = new Rule(-327, new int[]{-14});
    rules[619] = new Rule(-327, new int[]{-329});
    rules[620] = new Rule(-327, new int[]{14});
    rules[621] = new Rule(-327, new int[]{-323});
    rules[622] = new Rule(-327, new int[]{-325});
    rules[623] = new Rule(-327, new int[]{-326});
    rules[624] = new Rule(-327, new int[]{6});
    rules[625] = new Rule(-329, new int[]{50,-132});
    rules[626] = new Rule(-324, new int[]{-335});
    rules[627] = new Rule(-335, new int[]{-340});
    rules[628] = new Rule(-335, new int[]{-335,94,-340});
    rules[629] = new Rule(-340, new int[]{-14});
    rules[630] = new Rule(-326, new int[]{8,-339,9});
    rules[631] = new Rule(-328, new int[]{14});
    rules[632] = new Rule(-328, new int[]{-14});
    rules[633] = new Rule(-328, new int[]{50,-132});
    rules[634] = new Rule(-328, new int[]{-323});
    rules[635] = new Rule(-328, new int[]{-325});
    rules[636] = new Rule(-328, new int[]{-326});
    rules[637] = new Rule(-339, new int[]{-328});
    rules[638] = new Rule(-339, new int[]{-339,94,-328});
    rules[639] = new Rule(-337, new int[]{-334});
    rules[640] = new Rule(-337, new int[]{-337,10,-334});
    rules[641] = new Rule(-337, new int[]{-337,94,-334});
    rules[642] = new Rule(-336, new int[]{-333});
    rules[643] = new Rule(-336, new int[]{-336,10,-333});
    rules[644] = new Rule(-336, new int[]{-336,94,-333});
    rules[645] = new Rule(-333, new int[]{14});
    rules[646] = new Rule(-333, new int[]{-14});
    rules[647] = new Rule(-333, new int[]{50,-132,5,-260});
    rules[648] = new Rule(-333, new int[]{50,-132});
    rules[649] = new Rule(-333, new int[]{-322});
    rules[650] = new Rule(-333, new int[]{-325});
    rules[651] = new Rule(-333, new int[]{-326});
    rules[652] = new Rule(-334, new int[]{14});
    rules[653] = new Rule(-334, new int[]{-14});
    rules[654] = new Rule(-334, new int[]{-132,5,-260});
    rules[655] = new Rule(-334, new int[]{-132});
    rules[656] = new Rule(-334, new int[]{50,-132,5,-260});
    rules[657] = new Rule(-334, new int[]{50,-132});
    rules[658] = new Rule(-334, new int[]{-323});
    rules[659] = new Rule(-334, new int[]{-325});
    rules[660] = new Rule(-334, new int[]{-326});
    rules[661] = new Rule(-102, new int[]{-93});
    rules[662] = new Rule(-102, new int[]{});
    rules[663] = new Rule(-107, new int[]{-83});
    rules[664] = new Rule(-107, new int[]{});
    rules[665] = new Rule(-105, new int[]{-93,5,-102});
    rules[666] = new Rule(-105, new int[]{5,-102});
    rules[667] = new Rule(-105, new int[]{-93,5,-102,5,-93});
    rules[668] = new Rule(-105, new int[]{5,-102,5,-93});
    rules[669] = new Rule(-106, new int[]{-83,5,-107});
    rules[670] = new Rule(-106, new int[]{5,-107});
    rules[671] = new Rule(-106, new int[]{-83,5,-107,5,-83});
    rules[672] = new Rule(-106, new int[]{5,-107,5,-83});
    rules[673] = new Rule(-182, new int[]{114});
    rules[674] = new Rule(-182, new int[]{119});
    rules[675] = new Rule(-182, new int[]{117});
    rules[676] = new Rule(-182, new int[]{115});
    rules[677] = new Rule(-182, new int[]{118});
    rules[678] = new Rule(-182, new int[]{116});
    rules[679] = new Rule(-182, new int[]{131});
    rules[680] = new Rule(-93, new int[]{-76});
    rules[681] = new Rule(-93, new int[]{-93,-183,-76});
    rules[682] = new Rule(-183, new int[]{110});
    rules[683] = new Rule(-183, new int[]{109});
    rules[684] = new Rule(-183, new int[]{122});
    rules[685] = new Rule(-183, new int[]{123});
    rules[686] = new Rule(-183, new int[]{120});
    rules[687] = new Rule(-187, new int[]{130});
    rules[688] = new Rule(-187, new int[]{132});
    rules[689] = new Rule(-248, new int[]{-250});
    rules[690] = new Rule(-248, new int[]{-251});
    rules[691] = new Rule(-251, new int[]{-76,130,-268});
    rules[692] = new Rule(-250, new int[]{-76,132,-268});
    rules[693] = new Rule(-77, new int[]{-88});
    rules[694] = new Rule(-252, new int[]{-77,113,-88});
    rules[695] = new Rule(-76, new int[]{-88});
    rules[696] = new Rule(-76, new int[]{-159});
    rules[697] = new Rule(-76, new int[]{-252});
    rules[698] = new Rule(-76, new int[]{-76,-184,-88});
    rules[699] = new Rule(-76, new int[]{-76,-184,-252});
    rules[700] = new Rule(-76, new int[]{-248});
    rules[701] = new Rule(-184, new int[]{112});
    rules[702] = new Rule(-184, new int[]{111});
    rules[703] = new Rule(-184, new int[]{125});
    rules[704] = new Rule(-184, new int[]{126});
    rules[705] = new Rule(-184, new int[]{127});
    rules[706] = new Rule(-184, new int[]{128});
    rules[707] = new Rule(-184, new int[]{124});
    rules[708] = new Rule(-53, new int[]{60,8,-268,9});
    rules[709] = new Rule(-54, new int[]{8,-91,94,-73,-307,-314,9});
    rules[710] = new Rule(-88, new int[]{53});
    rules[711] = new Rule(-88, new int[]{-14});
    rules[712] = new Rule(-88, new int[]{-53});
    rules[713] = new Rule(-88, new int[]{11,-64,12});
    rules[714] = new Rule(-88, new int[]{129,-88});
    rules[715] = new Rule(-88, new int[]{-185,-88});
    rules[716] = new Rule(-88, new int[]{-100});
    rules[717] = new Rule(-88, new int[]{-54});
    rules[718] = new Rule(-14, new int[]{-150});
    rules[719] = new Rule(-14, new int[]{-15});
    rules[720] = new Rule(-103, new int[]{-99,15,-99});
    rules[721] = new Rule(-103, new int[]{-99,15,-103});
    rules[722] = new Rule(-100, new int[]{-117,-99});
    rules[723] = new Rule(-100, new int[]{-99});
    rules[724] = new Rule(-100, new int[]{-103});
    rules[725] = new Rule(-117, new int[]{135});
    rules[726] = new Rule(-117, new int[]{-117,135});
    rules[727] = new Rule(-9, new int[]{-166,-65});
    rules[728] = new Rule(-9, new int[]{-285,-65});
    rules[729] = new Rule(-304, new int[]{-132});
    rules[730] = new Rule(-304, new int[]{-304,7,-123});
    rules[731] = new Rule(-303, new int[]{-304});
    rules[732] = new Rule(-303, new int[]{-304,-283});
    rules[733] = new Rule(-16, new int[]{-99});
    rules[734] = new Rule(-16, new int[]{-14});
    rules[735] = new Rule(-99, new int[]{-132});
    rules[736] = new Rule(-99, new int[]{-177});
    rules[737] = new Rule(-99, new int[]{39,-132});
    rules[738] = new Rule(-99, new int[]{8,-81,9});
    rules[739] = new Rule(-99, new int[]{-241});
    rules[740] = new Rule(-99, new int[]{-279});
    rules[741] = new Rule(-99, new int[]{-14,7,-123});
    rules[742] = new Rule(-99, new int[]{-16,11,-66,12});
    rules[743] = new Rule(-99, new int[]{-99,17,-105,12});
    rules[744] = new Rule(-99, new int[]{-99,8,-63,9});
    rules[745] = new Rule(-99, new int[]{-99,7,-133});
    rules[746] = new Rule(-99, new int[]{-54,7,-133});
    rules[747] = new Rule(-99, new int[]{-99,136});
    rules[748] = new Rule(-99, new int[]{-99,4,-283});
    rules[749] = new Rule(-63, new int[]{-66});
    rules[750] = new Rule(-63, new int[]{});
    rules[751] = new Rule(-64, new int[]{-71});
    rules[752] = new Rule(-64, new int[]{});
    rules[753] = new Rule(-71, new int[]{-84});
    rules[754] = new Rule(-71, new int[]{-71,94,-84});
    rules[755] = new Rule(-84, new int[]{-81});
    rules[756] = new Rule(-84, new int[]{-81,6,-81});
    rules[757] = new Rule(-151, new int[]{138});
    rules[758] = new Rule(-151, new int[]{140});
    rules[759] = new Rule(-150, new int[]{-152});
    rules[760] = new Rule(-150, new int[]{139});
    rules[761] = new Rule(-152, new int[]{-151});
    rules[762] = new Rule(-152, new int[]{-152,-151});
    rules[763] = new Rule(-177, new int[]{42,-186});
    rules[764] = new Rule(-193, new int[]{10});
    rules[765] = new Rule(-193, new int[]{10,-192,10});
    rules[766] = new Rule(-194, new int[]{});
    rules[767] = new Rule(-194, new int[]{10,-192});
    rules[768] = new Rule(-192, new int[]{-195});
    rules[769] = new Rule(-192, new int[]{-192,10,-195});
    rules[770] = new Rule(-132, new int[]{137});
    rules[771] = new Rule(-132, new int[]{-136});
    rules[772] = new Rule(-132, new int[]{-137});
    rules[773] = new Rule(-123, new int[]{-132});
    rules[774] = new Rule(-123, new int[]{-277});
    rules[775] = new Rule(-123, new int[]{-278});
    rules[776] = new Rule(-133, new int[]{-132});
    rules[777] = new Rule(-133, new int[]{-277});
    rules[778] = new Rule(-133, new int[]{-177});
    rules[779] = new Rule(-195, new int[]{141});
    rules[780] = new Rule(-195, new int[]{143});
    rules[781] = new Rule(-195, new int[]{144});
    rules[782] = new Rule(-195, new int[]{145});
    rules[783] = new Rule(-195, new int[]{147});
    rules[784] = new Rule(-195, new int[]{146});
    rules[785] = new Rule(-196, new int[]{146});
    rules[786] = new Rule(-196, new int[]{145});
    rules[787] = new Rule(-196, new int[]{141});
    rules[788] = new Rule(-136, new int[]{80});
    rules[789] = new Rule(-136, new int[]{81});
    rules[790] = new Rule(-137, new int[]{75});
    rules[791] = new Rule(-137, new int[]{73});
    rules[792] = new Rule(-135, new int[]{79});
    rules[793] = new Rule(-135, new int[]{78});
    rules[794] = new Rule(-135, new int[]{77});
    rules[795] = new Rule(-135, new int[]{76});
    rules[796] = new Rule(-277, new int[]{-135});
    rules[797] = new Rule(-277, new int[]{66});
    rules[798] = new Rule(-277, new int[]{61});
    rules[799] = new Rule(-277, new int[]{122});
    rules[800] = new Rule(-277, new int[]{19});
    rules[801] = new Rule(-277, new int[]{18});
    rules[802] = new Rule(-277, new int[]{60});
    rules[803] = new Rule(-277, new int[]{20});
    rules[804] = new Rule(-277, new int[]{123});
    rules[805] = new Rule(-277, new int[]{124});
    rules[806] = new Rule(-277, new int[]{125});
    rules[807] = new Rule(-277, new int[]{126});
    rules[808] = new Rule(-277, new int[]{127});
    rules[809] = new Rule(-277, new int[]{128});
    rules[810] = new Rule(-277, new int[]{129});
    rules[811] = new Rule(-277, new int[]{130});
    rules[812] = new Rule(-277, new int[]{131});
    rules[813] = new Rule(-277, new int[]{132});
    rules[814] = new Rule(-277, new int[]{21});
    rules[815] = new Rule(-277, new int[]{71});
    rules[816] = new Rule(-277, new int[]{85});
    rules[817] = new Rule(-277, new int[]{22});
    rules[818] = new Rule(-277, new int[]{23});
    rules[819] = new Rule(-277, new int[]{26});
    rules[820] = new Rule(-277, new int[]{27});
    rules[821] = new Rule(-277, new int[]{28});
    rules[822] = new Rule(-277, new int[]{69});
    rules[823] = new Rule(-277, new int[]{93});
    rules[824] = new Rule(-277, new int[]{29});
    rules[825] = new Rule(-277, new int[]{30});
    rules[826] = new Rule(-277, new int[]{31});
    rules[827] = new Rule(-277, new int[]{24});
    rules[828] = new Rule(-277, new int[]{98});
    rules[829] = new Rule(-277, new int[]{95});
    rules[830] = new Rule(-277, new int[]{32});
    rules[831] = new Rule(-277, new int[]{33});
    rules[832] = new Rule(-277, new int[]{34});
    rules[833] = new Rule(-277, new int[]{37});
    rules[834] = new Rule(-277, new int[]{38});
    rules[835] = new Rule(-277, new int[]{39});
    rules[836] = new Rule(-277, new int[]{97});
    rules[837] = new Rule(-277, new int[]{40});
    rules[838] = new Rule(-277, new int[]{41});
    rules[839] = new Rule(-277, new int[]{43});
    rules[840] = new Rule(-277, new int[]{44});
    rules[841] = new Rule(-277, new int[]{45});
    rules[842] = new Rule(-277, new int[]{91});
    rules[843] = new Rule(-277, new int[]{46});
    rules[844] = new Rule(-277, new int[]{96});
    rules[845] = new Rule(-277, new int[]{47});
    rules[846] = new Rule(-277, new int[]{25});
    rules[847] = new Rule(-277, new int[]{48});
    rules[848] = new Rule(-277, new int[]{68});
    rules[849] = new Rule(-277, new int[]{92});
    rules[850] = new Rule(-277, new int[]{49});
    rules[851] = new Rule(-277, new int[]{50});
    rules[852] = new Rule(-277, new int[]{51});
    rules[853] = new Rule(-277, new int[]{52});
    rules[854] = new Rule(-277, new int[]{53});
    rules[855] = new Rule(-277, new int[]{54});
    rules[856] = new Rule(-277, new int[]{55});
    rules[857] = new Rule(-277, new int[]{56});
    rules[858] = new Rule(-277, new int[]{58});
    rules[859] = new Rule(-277, new int[]{99});
    rules[860] = new Rule(-277, new int[]{100});
    rules[861] = new Rule(-277, new int[]{103});
    rules[862] = new Rule(-277, new int[]{101});
    rules[863] = new Rule(-277, new int[]{102});
    rules[864] = new Rule(-277, new int[]{59});
    rules[865] = new Rule(-277, new int[]{72});
    rules[866] = new Rule(-277, new int[]{35});
    rules[867] = new Rule(-277, new int[]{36});
    rules[868] = new Rule(-278, new int[]{42});
    rules[869] = new Rule(-278, new int[]{86});
    rules[870] = new Rule(-186, new int[]{109});
    rules[871] = new Rule(-186, new int[]{110});
    rules[872] = new Rule(-186, new int[]{111});
    rules[873] = new Rule(-186, new int[]{112});
    rules[874] = new Rule(-186, new int[]{114});
    rules[875] = new Rule(-186, new int[]{115});
    rules[876] = new Rule(-186, new int[]{116});
    rules[877] = new Rule(-186, new int[]{117});
    rules[878] = new Rule(-186, new int[]{118});
    rules[879] = new Rule(-186, new int[]{119});
    rules[880] = new Rule(-186, new int[]{122});
    rules[881] = new Rule(-186, new int[]{123});
    rules[882] = new Rule(-186, new int[]{124});
    rules[883] = new Rule(-186, new int[]{125});
    rules[884] = new Rule(-186, new int[]{126});
    rules[885] = new Rule(-186, new int[]{127});
    rules[886] = new Rule(-186, new int[]{128});
    rules[887] = new Rule(-186, new int[]{129});
    rules[888] = new Rule(-186, new int[]{131});
    rules[889] = new Rule(-186, new int[]{133});
    rules[890] = new Rule(-186, new int[]{134});
    rules[891] = new Rule(-186, new int[]{-180});
    rules[892] = new Rule(-186, new int[]{113});
    rules[893] = new Rule(-180, new int[]{104});
    rules[894] = new Rule(-180, new int[]{105});
    rules[895] = new Rule(-180, new int[]{106});
    rules[896] = new Rule(-180, new int[]{107});
    rules[897] = new Rule(-180, new int[]{108});
    rules[898] = new Rule(-305, new int[]{-132,121,-311});
    rules[899] = new Rule(-305, new int[]{8,9,-308,121,-311});
    rules[900] = new Rule(-305, new int[]{8,-132,5,-259,9,-308,121,-311});
    rules[901] = new Rule(-305, new int[]{8,-132,10,-309,9,-308,121,-311});
    rules[902] = new Rule(-305, new int[]{8,-132,5,-259,10,-309,9,-308,121,-311});
    rules[903] = new Rule(-305, new int[]{8,-91,94,-73,-307,-314,9,-318});
    rules[904] = new Rule(-305, new int[]{-306});
    rules[905] = new Rule(-314, new int[]{});
    rules[906] = new Rule(-314, new int[]{10,-309});
    rules[907] = new Rule(-318, new int[]{-308,121,-311});
    rules[908] = new Rule(-306, new int[]{34,-307,121,-311});
    rules[909] = new Rule(-306, new int[]{34,8,9,-307,121,-311});
    rules[910] = new Rule(-306, new int[]{34,8,-309,9,-307,121,-311});
    rules[911] = new Rule(-306, new int[]{41,121,-312});
    rules[912] = new Rule(-306, new int[]{41,8,9,121,-312});
    rules[913] = new Rule(-306, new int[]{41,8,-309,9,121,-312});
    rules[914] = new Rule(-309, new int[]{-310});
    rules[915] = new Rule(-309, new int[]{-309,10,-310});
    rules[916] = new Rule(-310, new int[]{-143,-307});
    rules[917] = new Rule(-307, new int[]{});
    rules[918] = new Rule(-307, new int[]{5,-259});
    rules[919] = new Rule(-308, new int[]{});
    rules[920] = new Rule(-308, new int[]{5,-261});
    rules[921] = new Rule(-313, new int[]{-239});
    rules[922] = new Rule(-313, new int[]{-138});
    rules[923] = new Rule(-313, new int[]{-301});
    rules[924] = new Rule(-313, new int[]{-231});
    rules[925] = new Rule(-313, new int[]{-109});
    rules[926] = new Rule(-313, new int[]{-108});
    rules[927] = new Rule(-313, new int[]{-110});
    rules[928] = new Rule(-313, new int[]{-32});
    rules[929] = new Rule(-313, new int[]{-286});
    rules[930] = new Rule(-313, new int[]{-154});
    rules[931] = new Rule(-313, new int[]{-111});
    rules[932] = new Rule(-313, new int[]{-232});
    rules[933] = new Rule(-311, new int[]{-91});
    rules[934] = new Rule(-311, new int[]{-313});
    rules[935] = new Rule(-312, new int[]{-197});
    rules[936] = new Rule(-312, new int[]{-4});
    rules[937] = new Rule(-312, new int[]{-313});
  }

  protected override void Initialize() {
    this.InitSpecialTokens((int)Tokens.error, (int)Tokens.EOF);
    this.InitStates(states);
    this.InitRules(rules);
    this.InitNonTerminals(nonTerms);
  }

  protected override void DoAction(int action)
    {
  CurrentSemanticValue = new Union();
    switch (action)
    {
      case 2: // parse_goal -> program_file
{ root = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 3: // parse_goal -> unit_file
{ root = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 4: // parse_goal -> parts
{ root = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 5: // parts -> tkParseModeExpression, expr
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 6: // parts -> tkParseModeExpression, tkType, type_decl_identifier
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 7: // parts -> tkParseModeType, variable_as_type
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 8: // parts -> tkParseModeStatement, stmt_or_expression
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 9: // stmt_or_expression -> expr
{ CurrentSemanticValue.stn = new expression_as_statement(ValueStack[ValueStack.Depth-1].ex,CurrentLocationSpan);}
        break;
      case 10: // stmt_or_expression -> assignment
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 11: // stmt_or_expression -> var_stmt
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 12: // optional_head_compiler_directives -> /* empty */
{ CurrentSemanticValue.ob = null; }
        break;
      case 13: // optional_head_compiler_directives -> head_compiler_directives
{ CurrentSemanticValue.ob = null; }
        break;
      case 14: // head_compiler_directives -> one_compiler_directive
{ CurrentSemanticValue.ob = null; }
        break;
      case 15: // head_compiler_directives -> head_compiler_directives, one_compiler_directive
{ CurrentSemanticValue.ob = null; }
        break;
      case 16: // one_compiler_directive -> tkDirectiveName, tkIdentifier
{
			parsertools.AddErrorFromResource("UNSUPPORTED_OLD_DIRECTIVES",CurrentLocationSpan);
			CurrentSemanticValue.ob = null;
        }
        break;
      case 17: // one_compiler_directive -> tkDirectiveName, tkStringLiteral
{
			parsertools.AddErrorFromResource("UNSUPPORTED_OLD_DIRECTIVES",CurrentLocationSpan);
			CurrentSemanticValue.ob = null;
        }
        break;
      case 18: // program_file -> program_header, optional_head_compiler_directives, uses_clause, 
               //                 program_block, optional_tk_point
{ 
			CurrentSemanticValue.stn = NewProgramModule(ValueStack[ValueStack.Depth-5].stn as program_name, ValueStack[ValueStack.Depth-4].ob, ValueStack[ValueStack.Depth-3].stn as uses_list, ValueStack[ValueStack.Depth-2].stn, ValueStack[ValueStack.Depth-1].ob, CurrentLocationSpan);
        }
        break;
      case 19: // optional_tk_point -> tkPoint
{ CurrentSemanticValue.ob = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 20: // optional_tk_point -> tkSemiColon
{ CurrentSemanticValue.ob = null; }
        break;
      case 21: // optional_tk_point -> tkColon
{ CurrentSemanticValue.ob = null; }
        break;
      case 22: // optional_tk_point -> tkComma
{ CurrentSemanticValue.ob = null; }
        break;
      case 23: // optional_tk_point -> tkDotDot
{ CurrentSemanticValue.ob = null; }
        break;
      case 25: // program_header -> /* empty */
{ CurrentSemanticValue.stn = null; }
        break;
      case 26: // program_header -> tkProgram, identifier, program_heading_2
{ CurrentSemanticValue.stn = new program_name(ValueStack[ValueStack.Depth-2].id,CurrentLocationSpan); }
        break;
      case 27: // program_heading_2 -> tkSemiColon
{ CurrentSemanticValue.ob = null; }
        break;
      case 28: // program_heading_2 -> tkRoundOpen, program_param_list, tkRoundClose, tkSemiColon
{ CurrentSemanticValue.ob = null; }
        break;
      case 29: // program_param_list -> program_param
{ CurrentSemanticValue.ob = null; }
        break;
      case 30: // program_param_list -> program_param_list, tkComma, program_param
{ CurrentSemanticValue.ob = null; }
        break;
      case 31: // program_param -> identifier
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 32: // program_block -> program_decl_sect_list, compound_stmt
{ 
			CurrentSemanticValue.stn = new block(ValueStack[ValueStack.Depth-2].stn as declarations, ValueStack[ValueStack.Depth-1].stn as statement_list, CurrentLocationSpan);
        }
        break;
      case 33: // program_decl_sect_list -> decl_sect_list
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 34: // ident_or_keyword_pointseparator_list -> identifier_or_keyword
{ 
			CurrentSemanticValue.stn = new ident_list(ValueStack[ValueStack.Depth-1].id, CurrentLocationSpan);
		}
        break;
      case 35: // ident_or_keyword_pointseparator_list -> ident_or_keyword_pointseparator_list, 
               //                                         tkPoint, identifier_or_keyword
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-3].stn as ident_list).Add(ValueStack[ValueStack.Depth-1].id, CurrentLocationSpan);
		}
        break;
      case 36: // uses_clause -> /* empty */
{ 
			CurrentSemanticValue.stn = null; 
		}
        break;
      case 37: // uses_clause -> uses_clause, tkUses, used_units_list, tkSemiColon
{ 
   			if (parsertools.build_tree_for_formatter)
   			{
	        	if (ValueStack[ValueStack.Depth-4].stn == null)
                {
	        		CurrentSemanticValue.stn = new uses_closure(ValueStack[ValueStack.Depth-2].stn as uses_list,CurrentLocationSpan);
                }
	        	else {
                    (ValueStack[ValueStack.Depth-4].stn as uses_closure).AddUsesList(ValueStack[ValueStack.Depth-2].stn as uses_list,CurrentLocationSpan);
                    CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-4].stn;
                }
   			}
   			else 
   			{
	        	if (ValueStack[ValueStack.Depth-4].stn == null)
                {
                    CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-2].stn;
                    CurrentSemanticValue.stn.source_context = CurrentLocationSpan;
                }
	        	else 
                {
                    (ValueStack[ValueStack.Depth-4].stn as uses_list).AddUsesList(ValueStack[ValueStack.Depth-2].stn as uses_list,CurrentLocationSpan);
                    CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-4].stn;
                    CurrentSemanticValue.stn.source_context = CurrentLocationSpan;
                }
			}
		}
        break;
      case 38: // used_units_list -> used_unit_name
{ 
		  CurrentSemanticValue.stn = new uses_list(ValueStack[ValueStack.Depth-1].stn as unit_or_namespace,CurrentLocationSpan);
        }
        break;
      case 39: // used_units_list -> used_units_list, tkComma, used_unit_name
{ 
		  CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-3].stn as uses_list).Add(ValueStack[ValueStack.Depth-1].stn as unit_or_namespace, CurrentLocationSpan);
        }
        break;
      case 40: // used_unit_name -> ident_or_keyword_pointseparator_list
{ 
			CurrentSemanticValue.stn = new unit_or_namespace(ValueStack[ValueStack.Depth-1].stn as ident_list,CurrentLocationSpan); 
		}
        break;
      case 41: // used_unit_name -> ident_or_keyword_pointseparator_list, tkIn, tkStringLiteral
{ 
			CurrentSemanticValue.stn = new uses_unit_in(ValueStack[ValueStack.Depth-3].stn as ident_list, ValueStack[ValueStack.Depth-1].stn as string_const, CurrentLocationSpan);
        }
        break;
      case 42: // unit_file -> attribute_declarations, unit_header, interface_part, 
               //              implementation_part, initialization_part, tkPoint
{ 
			CurrentSemanticValue.stn = new unit_module(ValueStack[ValueStack.Depth-5].stn as unit_name, ValueStack[ValueStack.Depth-4].stn as interface_node, ValueStack[ValueStack.Depth-3].stn as implementation_node, (ValueStack[ValueStack.Depth-2].stn as initfinal_part).initialization_sect, (ValueStack[ValueStack.Depth-2].stn as initfinal_part).finalization_sect, ValueStack[ValueStack.Depth-6].stn as attribute_list, CurrentLocationSpan);                    
		}
        break;
      case 43: // unit_file -> attribute_declarations, unit_header, abc_interface_part, 
               //              initialization_part, tkPoint
{ 
			CurrentSemanticValue.stn = new unit_module(ValueStack[ValueStack.Depth-4].stn as unit_name, ValueStack[ValueStack.Depth-3].stn as interface_node, null, (ValueStack[ValueStack.Depth-2].stn as initfinal_part).initialization_sect, (ValueStack[ValueStack.Depth-2].stn as initfinal_part).finalization_sect, ValueStack[ValueStack.Depth-5].stn as attribute_list, CurrentLocationSpan);
        }
        break;
      case 44: // unit_header -> unit_key_word, unit_name, tkSemiColon, 
               //                optional_head_compiler_directives
{ 
			CurrentSemanticValue.stn = NewUnitHeading(new ident(ValueStack[ValueStack.Depth-4].ti.text, LocationStack[LocationStack.Depth-4]), ValueStack[ValueStack.Depth-3].id, CurrentLocationSpan); 
		}
        break;
      case 45: // unit_header -> tkNamespace, ident_or_keyword_pointseparator_list, tkSemiColon, 
               //                optional_head_compiler_directives
{
            CurrentSemanticValue.stn = NewNamespaceHeading(new ident(ValueStack[ValueStack.Depth-4].ti.text, LocationStack[LocationStack.Depth-4]), ValueStack[ValueStack.Depth-3].stn as ident_list, CurrentLocationSpan);
        }
        break;
      case 46: // unit_key_word -> tkUnit
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 47: // unit_key_word -> tkLibrary
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 48: // unit_name -> identifier
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 49: // interface_part -> tkInterface, uses_clause, interface_decl_sect_list
{ 
			CurrentSemanticValue.stn = new interface_node(ValueStack[ValueStack.Depth-1].stn as declarations, ValueStack[ValueStack.Depth-2].stn as uses_list, null, LexLocation.MergeAll(LocationStack[LocationStack.Depth-3],LocationStack[LocationStack.Depth-2],LocationStack[LocationStack.Depth-1])); 
        }
        break;
      case 50: // implementation_part -> tkImplementation, uses_clause, decl_sect_list
{ 
			CurrentSemanticValue.stn = new implementation_node(ValueStack[ValueStack.Depth-2].stn as uses_list, ValueStack[ValueStack.Depth-1].stn as declarations, null, LexLocation.MergeAll(LocationStack[LocationStack.Depth-3],LocationStack[LocationStack.Depth-2],LocationStack[LocationStack.Depth-1])); 
        }
        break;
      case 51: // abc_interface_part -> uses_clause, decl_sect_list
{ 
			CurrentSemanticValue.stn = new interface_node(ValueStack[ValueStack.Depth-1].stn as declarations, ValueStack[ValueStack.Depth-2].stn as uses_list, null, null); 
        }
        break;
      case 52: // initialization_part -> tkEnd
{ 
			CurrentSemanticValue.stn = new initfinal_part(); 
			CurrentSemanticValue.stn.source_context = CurrentLocationSpan;
		}
        break;
      case 53: // initialization_part -> tkInitialization, stmt_list, tkEnd
{ 
		  CurrentSemanticValue.stn = new initfinal_part(ValueStack[ValueStack.Depth-3].ti, ValueStack[ValueStack.Depth-2].stn as statement_list, ValueStack[ValueStack.Depth-1].ti, null, null, CurrentLocationSpan);
        }
        break;
      case 54: // initialization_part -> tkInitialization, stmt_list, tkFinalization, stmt_list, 
               //                        tkEnd
{ 
		  CurrentSemanticValue.stn = new initfinal_part(ValueStack[ValueStack.Depth-5].ti, ValueStack[ValueStack.Depth-4].stn as statement_list, ValueStack[ValueStack.Depth-3].ti, ValueStack[ValueStack.Depth-2].stn as statement_list, ValueStack[ValueStack.Depth-1].ti, CurrentLocationSpan);
        }
        break;
      case 55: // initialization_part -> tkBegin, stmt_list, tkEnd
{ 
		  CurrentSemanticValue.stn = new initfinal_part(ValueStack[ValueStack.Depth-3].ti, ValueStack[ValueStack.Depth-2].stn as statement_list, ValueStack[ValueStack.Depth-1].ti, null, null, CurrentLocationSpan);
        }
        break;
      case 56: // interface_decl_sect_list -> int_decl_sect_list1
{
			if ((ValueStack[ValueStack.Depth-1].stn as declarations).Count > 0) 
				CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; 
			else 
				CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn;
		}
        break;
      case 57: // int_decl_sect_list1 -> /* empty */
{ 
			CurrentSemanticValue.stn = new declarations();  
			if (GlobalDecls==null) 
				GlobalDecls = CurrentSemanticValue.stn as declarations;
		}
        break;
      case 58: // int_decl_sect_list1 -> int_decl_sect_list1, int_decl_sect
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-2].stn as declarations).Add(ValueStack[ValueStack.Depth-1].stn as declaration, CurrentLocationSpan);
        }
        break;
      case 59: // decl_sect_list -> decl_sect_list1
{
			if ((ValueStack[ValueStack.Depth-1].stn as declarations).Count > 0) 
				CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; 
			else 
				CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn;
		}
        break;
      case 60: // decl_sect_list1 -> /* empty */
{ 
			CurrentSemanticValue.stn = new declarations(); 
			if (GlobalDecls==null) 
				GlobalDecls = CurrentSemanticValue.stn as declarations;
		}
        break;
      case 61: // decl_sect_list1 -> decl_sect_list1, decl_sect
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-2].stn as declarations).Add(ValueStack[ValueStack.Depth-1].stn as declaration, CurrentLocationSpan);
        }
        break;
      case 62: // inclass_decl_sect_list -> inclass_decl_sect_list1
{
			if ((ValueStack[ValueStack.Depth-1].stn as declarations).Count > 0) 
				CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; 
			else 
				CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn;
		}
        break;
      case 63: // inclass_decl_sect_list1 -> /* empty */
{ 
        	CurrentSemanticValue.stn = new declarations(); 
        }
        break;
      case 64: // inclass_decl_sect_list1 -> inclass_decl_sect_list1, abc_decl_sect
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-2].stn as declarations).Add(ValueStack[ValueStack.Depth-1].stn as declaration, CurrentLocationSpan);
        }
        break;
      case 65: // int_decl_sect -> const_decl_sect
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 66: // int_decl_sect -> res_str_decl_sect
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 67: // int_decl_sect -> type_decl_sect
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 68: // int_decl_sect -> var_decl_sect
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 69: // int_decl_sect -> int_proc_header
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 70: // int_decl_sect -> int_func_header
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 71: // decl_sect -> label_decl_sect
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 72: // decl_sect -> const_decl_sect
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 73: // decl_sect -> res_str_decl_sect
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 74: // decl_sect -> type_decl_sect
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 75: // decl_sect -> var_decl_sect
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 76: // decl_sect -> proc_func_constr_destr_decl_with_attr
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 77: // proc_func_constr_destr_decl -> proc_func_decl
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 78: // proc_func_constr_destr_decl -> constr_destr_decl
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 79: // proc_func_constr_destr_decl_with_attr -> attribute_declarations, 
               //                                          proc_func_constr_destr_decl
{
		    (ValueStack[ValueStack.Depth-1].stn as procedure_definition).AssignAttrList(ValueStack[ValueStack.Depth-2].stn as attribute_list);
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn;
		}
        break;
      case 80: // abc_decl_sect -> label_decl_sect
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 81: // abc_decl_sect -> const_decl_sect
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 82: // abc_decl_sect -> res_str_decl_sect
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 83: // abc_decl_sect -> type_decl_sect
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 84: // abc_decl_sect -> var_decl_sect
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 85: // int_proc_header -> attribute_declarations, proc_header
{  
			CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td;
			(CurrentSemanticValue.td as procedure_header).attributes = ValueStack[ValueStack.Depth-2].stn as attribute_list;
        }
        break;
      case 86: // int_proc_header -> attribute_declarations, proc_header, tkForward, tkSemiColon
{  
			CurrentSemanticValue.td = NewProcedureHeader(ValueStack[ValueStack.Depth-4].stn as attribute_list, ValueStack[ValueStack.Depth-3].td as procedure_header, ValueStack[ValueStack.Depth-2].id as procedure_attribute, CurrentLocationSpan);
		}
        break;
      case 87: // int_func_header -> attribute_declarations, func_header
{  
			CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td;
			(CurrentSemanticValue.td as procedure_header).attributes = ValueStack[ValueStack.Depth-2].stn as attribute_list;
        }
        break;
      case 88: // int_func_header -> attribute_declarations, func_header, tkForward, tkSemiColon
{  
			CurrentSemanticValue.td = NewProcedureHeader(ValueStack[ValueStack.Depth-4].stn as attribute_list, ValueStack[ValueStack.Depth-3].td as procedure_header, ValueStack[ValueStack.Depth-2].id as procedure_attribute, CurrentLocationSpan);
		}
        break;
      case 89: // label_decl_sect -> tkLabel, label_list, tkSemiColon
{ 
			CurrentSemanticValue.stn = new label_definitions(ValueStack[ValueStack.Depth-2].stn as ident_list, CurrentLocationSpan); 
		}
        break;
      case 90: // label_list -> label_name
{ 
			CurrentSemanticValue.stn = new ident_list(ValueStack[ValueStack.Depth-1].id, CurrentLocationSpan);
		}
        break;
      case 91: // label_list -> label_list, tkComma, label_name
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-3].stn as ident_list).Add(ValueStack[ValueStack.Depth-1].id, CurrentLocationSpan);
		}
        break;
      case 92: // label_name -> tkInteger
{ 
			CurrentSemanticValue.id = new ident(ValueStack[ValueStack.Depth-1].ex.ToString(), CurrentLocationSpan);
		}
        break;
      case 93: // label_name -> tkFloat
{ 
			CurrentSemanticValue.id = new ident(ValueStack[ValueStack.Depth-1].ex.ToString(), CurrentLocationSpan);  
		}
        break;
      case 94: // label_name -> identifier
{ 
			CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; 
		}
        break;
      case 95: // const_decl_sect -> tkConst, const_decl
{ 
			CurrentSemanticValue.stn = new consts_definitions_list(ValueStack[ValueStack.Depth-1].stn as const_definition, CurrentLocationSpan);
		}
        break;
      case 96: // const_decl_sect -> const_decl_sect, const_decl
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-2].stn as consts_definitions_list).Add(ValueStack[ValueStack.Depth-1].stn as const_definition, CurrentLocationSpan);
		}
        break;
      case 97: // res_str_decl_sect -> tkResourceString, const_decl
{ 
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; 
		}
        break;
      case 98: // res_str_decl_sect -> res_str_decl_sect, const_decl
{ 
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-2].stn; 
		}
        break;
      case 99: // type_decl_sect -> tkType, type_decl
{ 
            CurrentSemanticValue.stn = new type_declarations(ValueStack[ValueStack.Depth-1].stn as type_declaration, CurrentLocationSpan);
		}
        break;
      case 100: // type_decl_sect -> type_decl_sect, type_decl
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-2].stn as type_declarations).Add(ValueStack[ValueStack.Depth-1].stn as type_declaration, CurrentLocationSpan);
		}
        break;
      case 101: // var_decl_with_assign_var_tuple -> var_decl
{ 
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; 
		}
        break;
      case 102: // var_decl_with_assign_var_tuple -> tkRoundOpen, identifier, tkComma, ident_list, 
                //                                   tkRoundClose, tkAssign, expr_l1, 
                //                                   tkSemiColon
{
			(ValueStack[ValueStack.Depth-5].stn as ident_list).Insert(0,ValueStack[ValueStack.Depth-7].id);
			ValueStack[ValueStack.Depth-5].stn.source_context = LexLocation.MergeAll(LocationStack[LocationStack.Depth-8],LocationStack[LocationStack.Depth-7],LocationStack[LocationStack.Depth-6],LocationStack[LocationStack.Depth-5],LocationStack[LocationStack.Depth-4]);
			CurrentSemanticValue.stn = new var_tuple_def_statement(ValueStack[ValueStack.Depth-5].stn as ident_list, ValueStack[ValueStack.Depth-2].ex, CurrentLocationSpan);
		}
        break;
      case 103: // var_decl_sect -> tkVar, var_decl_with_assign_var_tuple
{ 
			CurrentSemanticValue.stn = new variable_definitions(ValueStack[ValueStack.Depth-1].stn as var_def_statement, CurrentLocationSpan);
		}
        break;
      case 104: // var_decl_sect -> tkEvent, var_decl_with_assign_var_tuple
{ 
			CurrentSemanticValue.stn = new variable_definitions(ValueStack[ValueStack.Depth-1].stn as var_def_statement, CurrentLocationSpan);                        
			(ValueStack[ValueStack.Depth-1].stn as var_def_statement).is_event = true;
        }
        break;
      case 105: // var_decl_sect -> var_decl_sect, var_decl_with_assign_var_tuple
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-2].stn as variable_definitions).Add(ValueStack[ValueStack.Depth-1].stn as var_def_statement, CurrentLocationSpan);
		}
        break;
      case 106: // const_decl -> only_const_decl, tkSemiColon
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-2].stn; }
        break;
      case 107: // only_const_decl -> const_name, tkEqual, init_const_expr
{ 
			CurrentSemanticValue.stn = new simple_const_definition(ValueStack[ValueStack.Depth-3].id, ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan); 
		}
        break;
      case 108: // only_const_decl -> const_name, tkColon, type_ref, tkEqual, typed_const
{ 
			CurrentSemanticValue.stn = new typed_const_definition(ValueStack[ValueStack.Depth-5].id, ValueStack[ValueStack.Depth-1].ex, ValueStack[ValueStack.Depth-3].td, CurrentLocationSpan);
		}
        break;
      case 109: // init_const_expr -> const_expr
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 110: // init_const_expr -> array_const
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 111: // const_name -> identifier
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 112: // expr_l1_list -> expr_l1
{ 
			CurrentSemanticValue.stn = new expression_list(ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan); 
		}
        break;
      case 113: // expr_l1_list -> expr_l1_list, tkComma, expr_l1
{
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-3].stn as expression_list).Add(ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan); 
		}
        break;
      case 114: // const_expr -> const_simple_expr
{ 
			CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; 
		}
        break;
      case 115: // const_expr -> const_simple_expr, const_relop, const_simple_expr
{ 
			CurrentSemanticValue.ex = new bin_expr(ValueStack[ValueStack.Depth-3].ex, ValueStack[ValueStack.Depth-1].ex, ValueStack[ValueStack.Depth-2].op.type, CurrentLocationSpan); 
		}
        break;
      case 116: // const_expr -> question_constexpr
{ 
			CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; 
		}
        break;
      case 117: // question_constexpr -> const_expr, tkQuestion, const_expr, tkColon, const_expr
{ CurrentSemanticValue.ex = new question_colon_expression(ValueStack[ValueStack.Depth-5].ex, ValueStack[ValueStack.Depth-3].ex, ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan); }
        break;
      case 118: // const_relop -> tkEqual
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 119: // const_relop -> tkNotEqual
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 120: // const_relop -> tkLower
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 121: // const_relop -> tkGreater
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 122: // const_relop -> tkLowerEqual
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 123: // const_relop -> tkGreaterEqual
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 124: // const_relop -> tkIn
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 125: // const_simple_expr -> const_term
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 126: // const_simple_expr -> const_simple_expr, const_addop, const_term
{ CurrentSemanticValue.ex = new bin_expr(ValueStack[ValueStack.Depth-3].ex, ValueStack[ValueStack.Depth-1].ex, ValueStack[ValueStack.Depth-2].op.type, CurrentLocationSpan); }
        break;
      case 127: // const_addop -> tkPlus
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 128: // const_addop -> tkMinus
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 129: // const_addop -> tkOr
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 130: // const_addop -> tkXor
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 131: // as_is_constexpr -> const_term, typecast_op, simple_or_template_type_reference
{ 
			CurrentSemanticValue.ex = NewAsIsConstexpr(ValueStack[ValueStack.Depth-3].ex, (op_typecast)ValueStack[ValueStack.Depth-2].ob, ValueStack[ValueStack.Depth-1].td, CurrentLocationSpan);                                
		}
        break;
      case 132: // power_constexpr -> const_factor, tkStarStar, const_factor
{ CurrentSemanticValue.ex = new bin_expr(ValueStack[ValueStack.Depth-3].ex, ValueStack[ValueStack.Depth-1].ex, ValueStack[ValueStack.Depth-2].op.type, CurrentLocationSpan); }
        break;
      case 133: // const_term -> const_factor
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 134: // const_term -> as_is_constexpr
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 135: // const_term -> power_constexpr
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 136: // const_term -> const_term, const_mulop, const_factor
{ CurrentSemanticValue.ex = new bin_expr(ValueStack[ValueStack.Depth-3].ex, ValueStack[ValueStack.Depth-1].ex, ValueStack[ValueStack.Depth-2].op.type, CurrentLocationSpan); }
        break;
      case 137: // const_term -> const_term, const_mulop, power_constexpr
{ CurrentSemanticValue.ex = new bin_expr(ValueStack[ValueStack.Depth-3].ex,ValueStack[ValueStack.Depth-1].ex,(ValueStack[ValueStack.Depth-2].op).type, CurrentLocationSpan); }
        break;
      case 138: // const_mulop -> tkStar
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 139: // const_mulop -> tkSlash
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 140: // const_mulop -> tkDiv
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 141: // const_mulop -> tkMod
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 142: // const_mulop -> tkShl
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 143: // const_mulop -> tkShr
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 144: // const_mulop -> tkAnd
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 145: // const_factor -> const_variable
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 146: // const_factor -> const_set
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 147: // const_factor -> tkNil
{ 
			CurrentSemanticValue.ex = new nil_const();  
			CurrentSemanticValue.ex.source_context = CurrentLocationSpan;
		}
        break;
      case 148: // const_factor -> tkAddressOf, const_factor
{ 
			CurrentSemanticValue.ex = new get_address(ValueStack[ValueStack.Depth-1].ex as addressed_value, CurrentLocationSpan);  
		}
        break;
      case 149: // const_factor -> tkRoundOpen, const_expr, tkRoundClose
{ 
	 	    CurrentSemanticValue.ex = new bracket_expr(ValueStack[ValueStack.Depth-2].ex, CurrentLocationSpan); 
		}
        break;
      case 150: // const_factor -> tkNot, const_factor
{ 
			CurrentSemanticValue.ex = new un_expr(ValueStack[ValueStack.Depth-1].ex, ValueStack[ValueStack.Depth-2].op.type, CurrentLocationSpan); 
		}
        break;
      case 151: // const_factor -> sign, const_factor
{ 
		    // ������ ��������� ����� ��������
			if (ValueStack[ValueStack.Depth-2].op.type == Operators.Minus)
			{
			    var i64 = ValueStack[ValueStack.Depth-1].ex as int64_const;
				if (i64 != null && i64.val == (Int64)Int32.MaxValue + 1)
				{
					CurrentSemanticValue.ex = new int32_const(Int32.MinValue,CurrentLocationSpan);
					break;
				}
				var ui64 = ValueStack[ValueStack.Depth-1].ex as uint64_const;
				if (ui64 != null && ui64.val == (UInt64)Int64.MaxValue + 1)
				{
					CurrentSemanticValue.ex = new int64_const(Int64.MinValue,CurrentLocationSpan);
					break;
				}
				if (ui64 != null && ui64.val > (UInt64)Int64.MaxValue + 1)
				{
					parsertools.AddErrorFromResource("BAD_INT2",CurrentLocationSpan);
					break;
				}
			    // ����� ������� ���������� ��������� � �������������� �������
			}
			CurrentSemanticValue.ex = new un_expr(ValueStack[ValueStack.Depth-1].ex, ValueStack[ValueStack.Depth-2].op.type, CurrentLocationSpan); 
		}
        break;
      case 152: // const_factor -> new_expr
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 153: // const_set -> tkSquareOpen, const_elem_list, tkSquareClose
{ 
			CurrentSemanticValue.ex = new pascal_set_constant(ValueStack[ValueStack.Depth-2].stn as expression_list, CurrentLocationSpan); 
		}
        break;
      case 154: // sign -> tkPlus
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 155: // sign -> tkMinus
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 156: // const_variable -> identifier
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 157: // const_variable -> literal
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 158: // const_variable -> unsigned_number
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 159: // const_variable -> tkInherited, identifier
{ 
			CurrentSemanticValue.ex = new inherited_ident(ValueStack[ValueStack.Depth-1].id.name, CurrentLocationSpan);
		}
        break;
      case 160: // const_variable -> sizeof_expr
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 161: // const_variable -> typeof_expr
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 162: // const_variable -> const_variable, const_variable_2
{
			CurrentSemanticValue.ex = NewConstVariable(ValueStack[ValueStack.Depth-2].ex, ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan);
        }
        break;
      case 163: // const_variable -> const_variable, tkAmpersend, template_type_params
{
			CurrentSemanticValue.ex = new ident_with_templateparams(ValueStack[ValueStack.Depth-3].ex as addressed_value, ValueStack[ValueStack.Depth-1].stn as template_param_list, CurrentLocationSpan);
        }
        break;
      case 164: // const_variable -> const_variable, tkSquareOpen, format_const_expr, 
                //                   tkSquareClose
{ 
    		var fe = ValueStack[ValueStack.Depth-2].ex as format_expr;
            if (!parsertools.build_tree_for_formatter)
            {
                if (fe.expr == null)
                    fe.expr = new int32_const(int.MaxValue,LocationStack[LocationStack.Depth-2]);
                if (fe.format1 == null)
                    fe.format1 = new int32_const(int.MaxValue,LocationStack[LocationStack.Depth-2]);
            }
    		CurrentSemanticValue.ex = new slice_expr(ValueStack[ValueStack.Depth-4].ex as addressed_value,fe.expr,fe.format1,fe.format2,CurrentLocationSpan);
		}
        break;
      case 165: // const_variable_2 -> tkPoint, identifier_or_keyword
{ 
			CurrentSemanticValue.ex = new dot_node(null, ValueStack[ValueStack.Depth-1].id as addressed_value, CurrentLocationSpan); 
		}
        break;
      case 166: // const_variable_2 -> tkDeref
{ 
			CurrentSemanticValue.ex = new roof_dereference();  
			CurrentSemanticValue.ex.source_context = CurrentLocationSpan;
		}
        break;
      case 167: // const_variable_2 -> tkRoundOpen, optional_const_func_expr_list, tkRoundClose
{ 
			CurrentSemanticValue.ex = new method_call(ValueStack[ValueStack.Depth-2].stn as expression_list, CurrentLocationSpan);  
		}
        break;
      case 168: // const_variable_2 -> tkSquareOpen, const_elem_list, tkSquareClose
{ 
			CurrentSemanticValue.ex = new indexer(ValueStack[ValueStack.Depth-2].stn as expression_list, CurrentLocationSpan);  
		}
        break;
      case 169: // optional_const_func_expr_list -> expr_list
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 170: // optional_const_func_expr_list -> /* empty */
{ CurrentSemanticValue.stn = null; }
        break;
      case 171: // const_elem_list -> const_elem_list1
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 173: // const_elem_list1 -> const_elem
{ 
			CurrentSemanticValue.stn = new expression_list(ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan);
		}
        break;
      case 174: // const_elem_list1 -> const_elem_list1, tkComma, const_elem
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-3].stn as expression_list).Add(ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan);
		}
        break;
      case 175: // const_elem -> const_expr
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 176: // const_elem -> const_expr, tkDotDot, const_expr
{ 
			CurrentSemanticValue.ex = new diapason_expr(ValueStack[ValueStack.Depth-3].ex, ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan); 
		}
        break;
      case 177: // unsigned_number -> tkInteger
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 178: // unsigned_number -> tkHex
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 179: // unsigned_number -> tkFloat
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 180: // typed_const -> const_expr
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 181: // typed_const -> array_const
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 182: // typed_const -> record_const
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 183: // array_const -> tkRoundOpen, typed_const_list, tkRoundClose
{ 
			CurrentSemanticValue.ex = new array_const(ValueStack[ValueStack.Depth-2].stn as expression_list, CurrentLocationSpan); 
		}
        break;
      case 184: // array_const -> tkRoundOpen, record_const, tkRoundClose
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-2].ex; }
        break;
      case 185: // array_const -> tkRoundOpen, array_const, tkRoundClose
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-2].ex; }
        break;
      case 187: // typed_const_list -> typed_const_list1
{
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn;
		}
        break;
      case 188: // typed_const_list1 -> typed_const_plus
{ 
			CurrentSemanticValue.stn = new expression_list(ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan);
        }
        break;
      case 189: // typed_const_list1 -> typed_const_list1, tkComma, typed_const_plus
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-3].stn as expression_list).Add(ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan);
		}
        break;
      case 190: // record_const -> tkRoundOpen, const_field_list, tkRoundClose
{
			CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-2].ex;
			CurrentSemanticValue.ex.source_context = CurrentLocationSpan;
		}
        break;
      case 191: // const_field_list -> const_field_list_1
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 192: // const_field_list -> const_field_list_1, tkSemiColon
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-2].ex; }
        break;
      case 193: // const_field_list_1 -> const_field
{ 
			CurrentSemanticValue.ex = new record_const(ValueStack[ValueStack.Depth-1].stn as record_const_definition, CurrentLocationSpan);
		}
        break;
      case 194: // const_field_list_1 -> const_field_list_1, tkSemiColon, const_field
{ 
			CurrentSemanticValue.ex = (ValueStack[ValueStack.Depth-3].ex as record_const).Add(ValueStack[ValueStack.Depth-1].stn as record_const_definition, CurrentLocationSpan);
		}
        break;
      case 195: // const_field -> const_field_name, tkColon, typed_const
{ 
			CurrentSemanticValue.stn = new record_const_definition(ValueStack[ValueStack.Depth-3].id, ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan); 
		}
        break;
      case 196: // const_field_name -> identifier
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 197: // type_decl -> attribute_declarations, simple_type_decl
{  
			(ValueStack[ValueStack.Depth-1].stn as declaration).attributes = ValueStack[ValueStack.Depth-2].stn as attribute_list;
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn;
			CurrentSemanticValue.stn.source_context = LocationStack[LocationStack.Depth-1];
        }
        break;
      case 198: // attribute_declarations -> attribute_declaration
{ 
			CurrentSemanticValue.stn = new attribute_list(ValueStack[ValueStack.Depth-1].stn as simple_attribute_list, CurrentLocationSpan);
    }
        break;
      case 199: // attribute_declarations -> attribute_declarations, attribute_declaration
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-2].stn as attribute_list).Add(ValueStack[ValueStack.Depth-1].stn as simple_attribute_list, CurrentLocationSpan);
		}
        break;
      case 200: // attribute_declarations -> /* empty */
{ CurrentSemanticValue.stn = null; }
        break;
      case 201: // attribute_declaration -> tkSquareOpen, one_or_some_attribute, tkSquareClose
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-2].stn; }
        break;
      case 202: // one_or_some_attribute -> one_attribute
{ 
			CurrentSemanticValue.stn = new simple_attribute_list(ValueStack[ValueStack.Depth-1].stn as attribute, CurrentLocationSpan);
		}
        break;
      case 203: // one_or_some_attribute -> one_or_some_attribute, tkComma, one_attribute
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-3].stn as simple_attribute_list).Add(ValueStack[ValueStack.Depth-1].stn as attribute, CurrentLocationSpan);
		}
        break;
      case 204: // one_attribute -> attribute_variable
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 205: // one_attribute -> identifier, tkColon, attribute_variable
{  
			(ValueStack[ValueStack.Depth-1].stn as attribute).qualifier = ValueStack[ValueStack.Depth-3].id;
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn;
			CurrentSemanticValue.stn.source_context = CurrentLocationSpan;
        }
        break;
      case 206: // simple_type_decl -> type_decl_identifier, tkEqual, type_decl_type, tkSemiColon
{ 
			CurrentSemanticValue.stn = new type_declaration(ValueStack[ValueStack.Depth-4].id, ValueStack[ValueStack.Depth-2].td, CurrentLocationSpan); 
		}
        break;
      case 207: // simple_type_decl -> template_identifier_with_equal, type_decl_type, tkSemiColon
{ 
			CurrentSemanticValue.stn = new type_declaration(ValueStack[ValueStack.Depth-3].id, ValueStack[ValueStack.Depth-2].td, CurrentLocationSpan); 
		}
        break;
      case 208: // type_decl_identifier -> identifier
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 209: // type_decl_identifier -> identifier, template_arguments
{ 
			CurrentSemanticValue.id = new template_type_name(ValueStack[ValueStack.Depth-2].id.name, ValueStack[ValueStack.Depth-1].stn as ident_list, CurrentLocationSpan); 
        }
        break;
      case 210: // template_identifier_with_equal -> identifier, tkLower, ident_list, 
                //                                   tkGreaterEqual
{ 
			CurrentSemanticValue.id = new template_type_name(ValueStack[ValueStack.Depth-4].id.name, ValueStack[ValueStack.Depth-2].stn as ident_list, CurrentLocationSpan); 
        }
        break;
      case 211: // type_decl_type -> type_ref
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 212: // type_decl_type -> object_type
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 213: // simple_type_question -> simple_type, tkQuestion
{
            if (parsertools.build_tree_for_formatter)
   			{
                CurrentSemanticValue.td = ValueStack[ValueStack.Depth-2].td;
            }
            else
            {
                var l = new List<ident>();
                l.Add(new ident("System"));
                l.Add(new ident("Nullable"));
                CurrentSemanticValue.td = new template_type_reference(new named_type_reference(l), new template_param_list(ValueStack[ValueStack.Depth-2].td), CurrentLocationSpan);
            }
		}
        break;
      case 214: // type_ref -> simple_type
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 215: // type_ref -> simple_type_question
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 216: // type_ref -> string_type
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 217: // type_ref -> pointer_type
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 218: // type_ref -> structured_type
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 219: // type_ref -> procedural_type
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 220: // type_ref -> template_type
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 221: // template_type -> simple_type_identifier, template_type_params
{ 
			CurrentSemanticValue.td = new template_type_reference(ValueStack[ValueStack.Depth-2].td as named_type_reference, ValueStack[ValueStack.Depth-1].stn as template_param_list, CurrentLocationSpan); 
		}
        break;
      case 222: // template_type_params -> tkLower, template_param_list, tkGreater
{
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-2].stn;
			CurrentSemanticValue.stn.source_context = CurrentLocationSpan;
		}
        break;
      case 223: // template_type_empty_params -> tkNotEqual
{
            var ntr = new named_type_reference(new ident(""), CurrentLocationSpan);
            
			CurrentSemanticValue.stn = new template_param_list(ntr, CurrentLocationSpan);
            ntr.source_context = new SourceContext(CurrentSemanticValue.stn.source_context.end_position.line_num, CurrentSemanticValue.stn.source_context.end_position.column_num, CurrentSemanticValue.stn.source_context.begin_position.line_num, CurrentSemanticValue.stn.source_context.begin_position.column_num);
		}
        break;
      case 224: // template_type_empty_params -> tkLower, template_empty_param_list, tkGreater
{
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-2].stn;
			CurrentSemanticValue.stn.source_context = CurrentLocationSpan;
		}
        break;
      case 225: // template_param_list -> template_param
{ 
			CurrentSemanticValue.stn = new template_param_list(ValueStack[ValueStack.Depth-1].td, CurrentLocationSpan);
		}
        break;
      case 226: // template_param_list -> template_param_list, tkComma, template_param
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-3].stn as template_param_list).Add(ValueStack[ValueStack.Depth-1].td, CurrentLocationSpan);
		}
        break;
      case 227: // template_empty_param_list -> template_empty_param
{ 
			CurrentSemanticValue.stn = new template_param_list(ValueStack[ValueStack.Depth-1].td, CurrentLocationSpan);
		}
        break;
      case 228: // template_empty_param_list -> template_empty_param_list, tkComma, 
                //                              template_empty_param
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-3].stn as template_param_list).Add(ValueStack[ValueStack.Depth-1].td, CurrentLocationSpan);
		}
        break;
      case 229: // template_empty_param -> /* empty */
{ 
            CurrentSemanticValue.td = new named_type_reference(new ident(""), CurrentLocationSpan);
        }
        break;
      case 230: // template_param -> simple_type
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 231: // template_param -> simple_type, tkQuestion
{
            if (parsertools.build_tree_for_formatter)
   			{
                CurrentSemanticValue.td = ValueStack[ValueStack.Depth-2].td;
            }
            else
            {
                var l = new List<ident>();
                l.Add(new ident("System"));
                l.Add(new ident("Nullable"));
                CurrentSemanticValue.td = new template_type_reference(new named_type_reference(l), new template_param_list(ValueStack[ValueStack.Depth-2].td), CurrentLocationSpan);
            }
		}
        break;
      case 232: // template_param -> structured_type
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 233: // template_param -> procedural_type
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 234: // template_param -> template_type
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 235: // simple_type -> range_expr
{
	    	CurrentSemanticValue.td = parsertools.ConvertDotNodeOrIdentToNamedTypeReference(ValueStack[ValueStack.Depth-1].ex); 
	    }
        break;
      case 236: // simple_type -> range_expr, tkDotDot, range_expr
{ 
			CurrentSemanticValue.td = new diapason(ValueStack[ValueStack.Depth-3].ex, ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan); 
		}
        break;
      case 237: // simple_type -> tkRoundOpen, enumeration_id_list, tkRoundClose
{ 
			CurrentSemanticValue.td = new enum_type_definition(ValueStack[ValueStack.Depth-2].stn as enumerator_list, CurrentLocationSpan);  
		}
        break;
      case 238: // range_expr -> range_term
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 239: // range_expr -> range_expr, const_addop, range_term
{ 
			CurrentSemanticValue.ex = new bin_expr(ValueStack[ValueStack.Depth-3].ex, ValueStack[ValueStack.Depth-1].ex, ValueStack[ValueStack.Depth-2].op.type, CurrentLocationSpan); 
		}
        break;
      case 240: // range_term -> range_factor
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 241: // range_term -> range_term, const_mulop, range_factor
{ 
			CurrentSemanticValue.ex = new bin_expr(ValueStack[ValueStack.Depth-3].ex, ValueStack[ValueStack.Depth-1].ex, ValueStack[ValueStack.Depth-2].op.type, CurrentLocationSpan); 
		}
        break;
      case 242: // range_factor -> simple_type_identifier
{ 
			CurrentSemanticValue.ex = parsertools.ConvertNamedTypeReferenceToDotNodeOrIdent(ValueStack[ValueStack.Depth-1].td as named_type_reference);
        }
        break;
      case 243: // range_factor -> unsigned_number
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 244: // range_factor -> sign, range_factor
{ 
			CurrentSemanticValue.ex = new un_expr(ValueStack[ValueStack.Depth-1].ex, ValueStack[ValueStack.Depth-2].op.type, CurrentLocationSpan); 
		}
        break;
      case 245: // range_factor -> literal
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 246: // range_factor -> range_factor, tkRoundOpen, const_elem_list, tkRoundClose
{ 
			CurrentSemanticValue.ex = new method_call(ValueStack[ValueStack.Depth-4].ex as addressed_value, ValueStack[ValueStack.Depth-2].stn as expression_list, CurrentLocationSpan);
        }
        break;
      case 247: // simple_type_identifier -> identifier
{ 
			CurrentSemanticValue.td = new named_type_reference(ValueStack[ValueStack.Depth-1].id, CurrentLocationSpan);
		}
        break;
      case 248: // simple_type_identifier -> simple_type_identifier, tkPoint, 
                //                           identifier_or_keyword
{ 
			CurrentSemanticValue.td = (ValueStack[ValueStack.Depth-3].td as named_type_reference).Add(ValueStack[ValueStack.Depth-1].id, CurrentLocationSpan);
		}
        break;
      case 249: // enumeration_id_list -> enumeration_id, tkComma, enumeration_id
{ 
			CurrentSemanticValue.stn = new enumerator_list(ValueStack[ValueStack.Depth-3].stn as enumerator, CurrentLocationSpan);
			(CurrentSemanticValue.stn as enumerator_list).Add(ValueStack[ValueStack.Depth-1].stn as enumerator, CurrentLocationSpan);
        }
        break;
      case 250: // enumeration_id_list -> enumeration_id_list, tkComma, enumeration_id
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-3].stn as enumerator_list).Add(ValueStack[ValueStack.Depth-1].stn as enumerator, CurrentLocationSpan);
        }
        break;
      case 251: // enumeration_id -> type_ref
{ 
			CurrentSemanticValue.stn = new enumerator(ValueStack[ValueStack.Depth-1].td, null, CurrentLocationSpan); 
		}
        break;
      case 252: // enumeration_id -> type_ref, tkEqual, expr
{ 
			CurrentSemanticValue.stn = new enumerator(ValueStack[ValueStack.Depth-3].td, ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan); 
		}
        break;
      case 253: // pointer_type -> tkDeref, fptype
{ 
			CurrentSemanticValue.td = new ref_type(ValueStack[ValueStack.Depth-1].td,CurrentLocationSpan);
		}
        break;
      case 254: // structured_type -> unpacked_structured_type
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 255: // structured_type -> tkPacked, unpacked_structured_type
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 256: // unpacked_structured_type -> array_type
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 257: // unpacked_structured_type -> record_type
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 258: // unpacked_structured_type -> set_type
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 259: // unpacked_structured_type -> file_type
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 260: // unpacked_structured_type -> sequence_type
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 261: // sequence_type -> tkSequence, tkOf, type_ref
{
			CurrentSemanticValue.td = new sequence_type(ValueStack[ValueStack.Depth-1].td,CurrentLocationSpan);
		}
        break;
      case 262: // array_type -> tkArray, tkSquareOpen, simple_type_list, tkSquareClose, tkOf, 
                //               type_ref
{ 
			CurrentSemanticValue.td = new array_type(ValueStack[ValueStack.Depth-4].stn as indexers_types, ValueStack[ValueStack.Depth-1].td, CurrentLocationSpan); 
        }
        break;
      case 263: // array_type -> unsized_array_type
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 264: // unsized_array_type -> tkArray, tkOf, type_ref
{ 
			CurrentSemanticValue.td = new array_type(null, ValueStack[ValueStack.Depth-1].td, CurrentLocationSpan); 
        }
        break;
      case 265: // simple_type_list -> simple_type_or_
{ 
			CurrentSemanticValue.stn = new indexers_types(ValueStack[ValueStack.Depth-1].td, CurrentLocationSpan);
        }
        break;
      case 266: // simple_type_list -> simple_type_list, tkComma, simple_type_or_
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-3].stn as indexers_types).Add(ValueStack[ValueStack.Depth-1].td, CurrentLocationSpan);
        }
        break;
      case 267: // simple_type_or_ -> simple_type
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 268: // simple_type_or_ -> /* empty */
{ CurrentSemanticValue.td = null; }
        break;
      case 269: // set_type -> tkSet, tkOf, type_ref
{ 
			CurrentSemanticValue.td = new set_type_definition(ValueStack[ValueStack.Depth-1].td, CurrentLocationSpan); 
		}
        break;
      case 270: // file_type -> tkFile, tkOf, type_ref
{ 
			CurrentSemanticValue.td = new file_type(ValueStack[ValueStack.Depth-1].td, CurrentLocationSpan);
		}
        break;
      case 271: // file_type -> tkFile
{ 
			CurrentSemanticValue.td = new file_type();  
			CurrentSemanticValue.td.source_context = CurrentLocationSpan;
		}
        break;
      case 272: // string_type -> tkIdentifier, tkSquareOpen, const_expr, tkSquareClose
{ 
			CurrentSemanticValue.td = new string_num_definition(ValueStack[ValueStack.Depth-2].ex, ValueStack[ValueStack.Depth-4].id, CurrentLocationSpan);
		}
        break;
      case 273: // procedural_type -> procedural_type_kind
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 274: // procedural_type_kind -> proc_type_decl
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 275: // proc_type_decl -> tkProcedure, fp_list
{ 
			CurrentSemanticValue.td = new procedure_header(ValueStack[ValueStack.Depth-1].stn as formal_parameters,null,null,false,false,null,null,CurrentLocationSpan);
        }
        break;
      case 276: // proc_type_decl -> tkFunction, fp_list, tkColon, fptype
{ 
			CurrentSemanticValue.td = new function_header(ValueStack[ValueStack.Depth-3].stn as formal_parameters, null, null, null, ValueStack[ValueStack.Depth-1].td as type_definition, CurrentLocationSpan);
        }
        break;
      case 277: // proc_type_decl -> simple_type_identifier, tkArrow, template_param
{
    		CurrentSemanticValue.td = new modern_proc_type(ValueStack[ValueStack.Depth-3].td,null,ValueStack[ValueStack.Depth-1].td,CurrentLocationSpan);            
    	}
        break;
      case 278: // proc_type_decl -> template_type, tkArrow, template_param
{
    		CurrentSemanticValue.td = new modern_proc_type(ValueStack[ValueStack.Depth-3].td,null,ValueStack[ValueStack.Depth-1].td,CurrentLocationSpan);            
    	}
        break;
      case 279: // proc_type_decl -> tkRoundOpen, tkRoundClose, tkArrow, template_param
{
    		CurrentSemanticValue.td = new modern_proc_type(null,null,ValueStack[ValueStack.Depth-1].td,CurrentLocationSpan);
    	}
        break;
      case 280: // proc_type_decl -> tkRoundOpen, enumeration_id_list, tkRoundClose, tkArrow, 
                //                   template_param
{
    		CurrentSemanticValue.td = new modern_proc_type(null,ValueStack[ValueStack.Depth-4].stn as enumerator_list,ValueStack[ValueStack.Depth-1].td,CurrentLocationSpan);
    	}
        break;
      case 281: // proc_type_decl -> simple_type_identifier, tkArrow, tkRoundOpen, tkRoundClose
{
    		CurrentSemanticValue.td = new modern_proc_type(ValueStack[ValueStack.Depth-4].td,null,null,CurrentLocationSpan);
    	}
        break;
      case 282: // proc_type_decl -> template_type, tkArrow, tkRoundOpen, tkRoundClose
{
    		CurrentSemanticValue.td = new modern_proc_type(ValueStack[ValueStack.Depth-4].td,null,null,CurrentLocationSpan);
    	}
        break;
      case 283: // proc_type_decl -> tkRoundOpen, tkRoundClose, tkArrow, tkRoundOpen, tkRoundClose
{
    		CurrentSemanticValue.td = new modern_proc_type(null,null,null,CurrentLocationSpan);
    	}
        break;
      case 284: // proc_type_decl -> tkRoundOpen, enumeration_id_list, tkRoundClose, tkArrow, 
                //                   tkRoundOpen, tkRoundClose
{
    		CurrentSemanticValue.td = new modern_proc_type(null,ValueStack[ValueStack.Depth-5].stn as enumerator_list,null,CurrentLocationSpan);
    	}
        break;
      case 285: // object_type -> class_attributes, class_or_interface_keyword, 
                //                optional_base_classes, optional_where_section, 
                //                optional_component_list_seq_end
{ 
            var cd = NewObjectType((class_attribute)ValueStack[ValueStack.Depth-5].ob, ValueStack[ValueStack.Depth-4].ti, ValueStack[ValueStack.Depth-3].stn as named_type_reference_list, ValueStack[ValueStack.Depth-2].stn as where_definition_list, ValueStack[ValueStack.Depth-1].stn as class_body_list, CurrentLocationSpan); 
			CurrentSemanticValue.td = cd;
            var tt = cd.DescendantNodes().OfType<class_definition>().Where(cld => cld.keyword == class_keyword.Record);
            if (tt.Count()>0)
            {
                foreach (var ttt in tt)
                {
	                var sc = ttt.source_context;
	                parsertools.AddErrorFromResource("NESTED_RECORD_DEFINITIONS_ARE_FORBIDDEN", new LexLocation(sc.begin_position.line_num, sc.begin_position.column_num-1, sc.end_position.line_num, sc.end_position.column_num, sc.FileName));
                }
            }
		}
        break;
      case 286: // record_type -> tkRecord, optional_base_classes, optional_where_section, 
                //                member_list_section, tkEnd
{ 
			var nnrt = new class_definition(ValueStack[ValueStack.Depth-4].stn as named_type_reference_list, ValueStack[ValueStack.Depth-2].stn as class_body_list, class_keyword.Record, null, ValueStack[ValueStack.Depth-3].stn as where_definition_list, class_attribute.None, false, CurrentLocationSpan); 
			if (/*nnrt.body!=null && nnrt.body.class_def_blocks!=null && 
				nnrt.body.class_def_blocks.Count>0 &&*/ 
				nnrt.body.class_def_blocks[0].access_mod==null)
			{
                nnrt.body.class_def_blocks[0].access_mod = new access_modifer_node(access_modifer.public_modifer);
			}        
			CurrentSemanticValue.td = nnrt;
		}
        break;
      case 287: // class_attribute -> tkSealed
{ CurrentSemanticValue.ob = class_attribute.Sealed; }
        break;
      case 288: // class_attribute -> tkPartial
{ CurrentSemanticValue.ob = class_attribute.Partial; }
        break;
      case 289: // class_attribute -> tkAbstract
{ CurrentSemanticValue.ob = class_attribute.Abstract; }
        break;
      case 290: // class_attribute -> tkAuto
{ CurrentSemanticValue.ob = class_attribute.Auto; }
        break;
      case 291: // class_attribute -> tkStatic
{ CurrentSemanticValue.ob = class_attribute.Static; }
        break;
      case 292: // class_attributes -> /* empty */
{ 
			CurrentSemanticValue.ob = class_attribute.None; 
		}
        break;
      case 293: // class_attributes -> class_attributes1
{
			CurrentSemanticValue.ob = ValueStack[ValueStack.Depth-1].ob;
		}
        break;
      case 294: // class_attributes1 -> class_attribute
{
			CurrentSemanticValue.ob = ValueStack[ValueStack.Depth-1].ob;
		}
        break;
      case 295: // class_attributes1 -> class_attributes1, class_attribute
{
            if (((class_attribute)ValueStack[ValueStack.Depth-2].ob & (class_attribute)ValueStack[ValueStack.Depth-1].ob) == (class_attribute)ValueStack[ValueStack.Depth-1].ob)
                parsertools.AddErrorFromResource("ATTRIBUTE_REDECLARED",LocationStack[LocationStack.Depth-1]);
			CurrentSemanticValue.ob  = ((class_attribute)ValueStack[ValueStack.Depth-2].ob) | ((class_attribute)ValueStack[ValueStack.Depth-1].ob);
			//$$ = $1;
		}
        break;
      case 296: // class_or_interface_keyword -> tkClass
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 297: // class_or_interface_keyword -> tkInterface
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 298: // class_or_interface_keyword -> tkTemplate
{ 
			CurrentSemanticValue.ti = NewClassOrInterfaceKeyword(ValueStack[ValueStack.Depth-1].ti);
		}
        break;
      case 299: // class_or_interface_keyword -> tkTemplate, tkClass
{ 
			CurrentSemanticValue.ti = NewClassOrInterfaceKeyword(ValueStack[ValueStack.Depth-2].ti, "c", CurrentLocationSpan);
		}
        break;
      case 300: // class_or_interface_keyword -> tkTemplate, tkRecord
{ 
			CurrentSemanticValue.ti = NewClassOrInterfaceKeyword(ValueStack[ValueStack.Depth-2].ti, "r", CurrentLocationSpan);
		}
        break;
      case 301: // class_or_interface_keyword -> tkTemplate, tkInterface
{ 
			CurrentSemanticValue.ti = NewClassOrInterfaceKeyword(ValueStack[ValueStack.Depth-2].ti, "i", CurrentLocationSpan);
		}
        break;
      case 302: // optional_component_list_seq_end -> /* empty */
{ CurrentSemanticValue.stn = null; }
        break;
      case 303: // optional_component_list_seq_end -> member_list_section, tkEnd
{
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-2].stn;
			CurrentSemanticValue.stn.source_context = CurrentLocationSpan;
		}
        break;
      case 305: // optional_base_classes -> tkRoundOpen, base_classes_names_list, tkRoundClose
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-2].stn; }
        break;
      case 306: // base_classes_names_list -> base_class_name
{ 
			CurrentSemanticValue.stn = new named_type_reference_list(ValueStack[ValueStack.Depth-1].stn as named_type_reference, CurrentLocationSpan);
		}
        break;
      case 307: // base_classes_names_list -> base_classes_names_list, tkComma, base_class_name
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-3].stn as named_type_reference_list).Add(ValueStack[ValueStack.Depth-1].stn as named_type_reference, CurrentLocationSpan);
		}
        break;
      case 308: // base_class_name -> simple_type_identifier
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 309: // base_class_name -> template_type
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 310: // template_arguments -> tkLower, ident_list, tkGreater
{
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-2].stn;
			CurrentSemanticValue.stn.source_context = CurrentLocationSpan;
		}
        break;
      case 311: // optional_where_section -> /* empty */
{ CurrentSemanticValue.stn = null; }
        break;
      case 312: // optional_where_section -> where_part_list
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 313: // where_part_list -> where_part
{ 
			CurrentSemanticValue.stn = new where_definition_list(ValueStack[ValueStack.Depth-1].stn as where_definition, CurrentLocationSpan);
		}
        break;
      case 314: // where_part_list -> where_part_list, where_part
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-2].stn as where_definition_list).Add(ValueStack[ValueStack.Depth-1].stn as where_definition, CurrentLocationSpan);
		}
        break;
      case 315: // where_part -> tkWhere, ident_list, tkColon, type_ref_and_secific_list, 
                //               tkSemiColon
{ 
			CurrentSemanticValue.stn = new where_definition(ValueStack[ValueStack.Depth-4].stn as ident_list, ValueStack[ValueStack.Depth-2].stn as where_type_specificator_list, CurrentLocationSpan); 
		}
        break;
      case 316: // type_ref_and_secific_list -> type_ref_or_secific
{ 
			CurrentSemanticValue.stn = new where_type_specificator_list(ValueStack[ValueStack.Depth-1].td, CurrentLocationSpan);
		}
        break;
      case 317: // type_ref_and_secific_list -> type_ref_and_secific_list, tkComma, 
                //                              type_ref_or_secific
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-3].stn as where_type_specificator_list).Add(ValueStack[ValueStack.Depth-1].td, CurrentLocationSpan);
		}
        break;
      case 318: // type_ref_or_secific -> type_ref
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 319: // type_ref_or_secific -> tkClass
{ 
			CurrentSemanticValue.td = new declaration_specificator(DeclarationSpecificator.WhereDefClass, ValueStack[ValueStack.Depth-1].ti.text, CurrentLocationSpan); 
		}
        break;
      case 320: // type_ref_or_secific -> tkRecord
{ 
			CurrentSemanticValue.td = new declaration_specificator(DeclarationSpecificator.WhereDefValueType, ValueStack[ValueStack.Depth-1].ti.text, CurrentLocationSpan); 
		}
        break;
      case 321: // type_ref_or_secific -> tkConstructor
{ 
			CurrentSemanticValue.td = new declaration_specificator(DeclarationSpecificator.WhereDefConstructor, ValueStack[ValueStack.Depth-1].ti.text, CurrentLocationSpan); 
		}
        break;
      case 322: // member_list_section -> member_list
{ 
			CurrentSemanticValue.stn = new class_body_list(ValueStack[ValueStack.Depth-1].stn as class_members, CurrentLocationSpan);
        }
        break;
      case 323: // member_list_section -> member_list_section, ot_visibility_specifier, 
                //                        member_list
{ 
		    (ValueStack[ValueStack.Depth-1].stn as class_members).access_mod = ValueStack[ValueStack.Depth-2].stn as access_modifer_node;
			(ValueStack[ValueStack.Depth-3].stn as class_body_list).Add(ValueStack[ValueStack.Depth-1].stn as class_members,CurrentLocationSpan);
			
			if ((ValueStack[ValueStack.Depth-3].stn as class_body_list).class_def_blocks[0].Count == 0)
                (ValueStack[ValueStack.Depth-3].stn as class_body_list).class_def_blocks.RemoveAt(0);
			
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-3].stn;
        }
        break;
      case 324: // ot_visibility_specifier -> tkInternal
{ CurrentSemanticValue.stn = new access_modifer_node(access_modifer.internal_modifer, CurrentLocationSpan); }
        break;
      case 325: // ot_visibility_specifier -> tkPublic
{ CurrentSemanticValue.stn = new access_modifer_node(access_modifer.public_modifer, CurrentLocationSpan); }
        break;
      case 326: // ot_visibility_specifier -> tkProtected
{ CurrentSemanticValue.stn = new access_modifer_node(access_modifer.protected_modifer, CurrentLocationSpan); }
        break;
      case 327: // ot_visibility_specifier -> tkPrivate
{ CurrentSemanticValue.stn = new access_modifer_node(access_modifer.private_modifer, CurrentLocationSpan); }
        break;
      case 328: // member_list -> /* empty */
{ CurrentSemanticValue.stn = new class_members(); }
        break;
      case 329: // member_list -> field_or_const_definition_list, optional_semicolon
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-2].stn; }
        break;
      case 330: // member_list -> method_decl_list
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 331: // member_list -> field_or_const_definition_list, tkSemiColon, method_decl_list
{  
			(ValueStack[ValueStack.Depth-3].stn as class_members).members.AddRange((ValueStack[ValueStack.Depth-1].stn as class_members).members);
			(ValueStack[ValueStack.Depth-3].stn as class_members).source_context = CurrentLocationSpan;
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-3].stn;
        }
        break;
      case 332: // ident_list -> identifier
{ 
			CurrentSemanticValue.stn = new ident_list(ValueStack[ValueStack.Depth-1].id, CurrentLocationSpan);
		}
        break;
      case 333: // ident_list -> ident_list, tkComma, identifier
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-3].stn as ident_list).Add(ValueStack[ValueStack.Depth-1].id, CurrentLocationSpan);
		}
        break;
      case 334: // optional_semicolon -> /* empty */
{ CurrentSemanticValue.ob = null; }
        break;
      case 335: // optional_semicolon -> tkSemiColon
{ CurrentSemanticValue.ob = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 336: // field_or_const_definition_list -> field_or_const_definition
{ 
			CurrentSemanticValue.stn = new class_members(ValueStack[ValueStack.Depth-1].stn as declaration, CurrentLocationSpan);
        }
        break;
      case 337: // field_or_const_definition_list -> field_or_const_definition_list, tkSemiColon, 
                //                                   field_or_const_definition
{   
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-3].stn as class_members).Add(ValueStack[ValueStack.Depth-1].stn as declaration, CurrentLocationSpan);
        }
        break;
      case 338: // field_or_const_definition -> attribute_declarations, 
                //                              simple_field_or_const_definition
{  
		    (ValueStack[ValueStack.Depth-1].stn as declaration).attributes = ValueStack[ValueStack.Depth-2].stn as attribute_list;
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn;
        }
        break;
      case 339: // method_decl_list -> method_or_property_decl
{ 
			CurrentSemanticValue.stn = new class_members(ValueStack[ValueStack.Depth-1].stn as declaration, CurrentLocationSpan);
        }
        break;
      case 340: // method_decl_list -> method_decl_list, method_or_property_decl
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-2].stn as class_members).Add(ValueStack[ValueStack.Depth-1].stn as declaration, CurrentLocationSpan);
        }
        break;
      case 341: // method_or_property_decl -> method_decl_withattr
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 342: // method_or_property_decl -> property_definition
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 343: // simple_field_or_const_definition -> tkConst, only_const_decl
{ 
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn;
			CurrentSemanticValue.stn.source_context = CurrentLocationSpan;
		}
        break;
      case 344: // simple_field_or_const_definition -> field_definition
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 345: // simple_field_or_const_definition -> class_or_static, field_definition
{ 
			(ValueStack[ValueStack.Depth-1].stn as var_def_statement).var_attr = definition_attribute.Static;
			(ValueStack[ValueStack.Depth-1].stn as var_def_statement).source_context = CurrentLocationSpan;
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn;
        }
        break;
      case 346: // class_or_static -> tkStatic
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 347: // class_or_static -> tkClass
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 348: // field_definition -> var_decl_part
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 349: // field_definition -> tkEvent, ident_list, tkColon, type_ref
{ 
			CurrentSemanticValue.stn = new var_def_statement(ValueStack[ValueStack.Depth-3].stn as ident_list, ValueStack[ValueStack.Depth-1].td, null, definition_attribute.None, true, CurrentLocationSpan); 
        }
        break;
      case 350: // method_decl_withattr -> attribute_declarations, method_header
{  
			(ValueStack[ValueStack.Depth-1].td as declaration).attributes = ValueStack[ValueStack.Depth-2].stn as attribute_list;
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].td;
        }
        break;
      case 351: // method_decl_withattr -> attribute_declarations, method_decl
{  
			(ValueStack[ValueStack.Depth-1].stn as declaration).attributes = ValueStack[ValueStack.Depth-2].stn as attribute_list;
            if (ValueStack[ValueStack.Depth-1].stn is procedure_definition && (ValueStack[ValueStack.Depth-1].stn as procedure_definition).proc_header != null)
                (ValueStack[ValueStack.Depth-1].stn as procedure_definition).proc_header.attributes = ValueStack[ValueStack.Depth-2].stn as attribute_list;
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn;
     }
        break;
      case 352: // method_decl -> inclass_proc_func_decl
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 353: // method_decl -> inclass_constr_destr_decl
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 354: // method_header -> class_or_static, method_procfunc_header
{ 
			(ValueStack[ValueStack.Depth-1].td as procedure_header).class_keyword = true;
			CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td;
		}
        break;
      case 355: // method_header -> method_procfunc_header
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 356: // method_header -> constr_destr_header
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 357: // method_procfunc_header -> proc_func_header
{ 
			CurrentSemanticValue.td = NewProcfuncHeading(ValueStack[ValueStack.Depth-1].td as procedure_header);
		}
        break;
      case 358: // proc_func_header -> proc_header
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 359: // proc_func_header -> func_header
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 360: // constr_destr_header -> tkConstructor, optional_proc_name, fp_list, 
                //                        optional_method_modificators
{ 
			CurrentSemanticValue.td = new constructor(null,ValueStack[ValueStack.Depth-2].stn as formal_parameters,ValueStack[ValueStack.Depth-1].stn as procedure_attributes_list,ValueStack[ValueStack.Depth-3].stn as method_name,false,false,null,null,CurrentLocationSpan);
        }
        break;
      case 361: // constr_destr_header -> class_or_static, tkConstructor, optional_proc_name, 
                //                        fp_list, optional_method_modificators
{ 
			CurrentSemanticValue.td = new constructor(null,ValueStack[ValueStack.Depth-2].stn as formal_parameters,ValueStack[ValueStack.Depth-1].stn as procedure_attributes_list,ValueStack[ValueStack.Depth-3].stn as method_name,false,true,null,null,CurrentLocationSpan);
        }
        break;
      case 362: // constr_destr_header -> tkDestructor, optional_proc_name, fp_list, 
                //                        optional_method_modificators
{ 
			CurrentSemanticValue.td = new destructor(null,ValueStack[ValueStack.Depth-2].stn as formal_parameters,ValueStack[ValueStack.Depth-1].stn as procedure_attributes_list,ValueStack[ValueStack.Depth-3].stn as method_name, false,false,null,null,CurrentLocationSpan);
        }
        break;
      case 363: // optional_proc_name -> proc_name
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 364: // optional_proc_name -> /* empty */
{ CurrentSemanticValue.stn = null; }
        break;
      case 365: // qualified_identifier -> identifier
{ CurrentSemanticValue.stn = new method_name(null,null,ValueStack[ValueStack.Depth-1].id,null,CurrentLocationSpan); }
        break;
      case 366: // qualified_identifier -> visibility_specifier
{ CurrentSemanticValue.stn = new method_name(null,null,ValueStack[ValueStack.Depth-1].id,null,CurrentLocationSpan); }
        break;
      case 367: // qualified_identifier -> qualified_identifier, tkPoint, identifier
{
			CurrentSemanticValue.stn = NewQualifiedIdentifier(ValueStack[ValueStack.Depth-3].stn as method_name, ValueStack[ValueStack.Depth-1].id, CurrentLocationSpan);
        }
        break;
      case 368: // qualified_identifier -> qualified_identifier, tkPoint, visibility_specifier
{
			CurrentSemanticValue.stn = NewQualifiedIdentifier(ValueStack[ValueStack.Depth-3].stn as method_name, ValueStack[ValueStack.Depth-1].id, CurrentLocationSpan);
        }
        break;
      case 369: // property_definition -> attribute_declarations, simple_property_definition
{  
			CurrentSemanticValue.stn = NewPropertyDefinition(ValueStack[ValueStack.Depth-2].stn as attribute_list, ValueStack[ValueStack.Depth-1].stn as declaration, LocationStack[LocationStack.Depth-1]);
        }
        break;
      case 370: // simple_property_definition -> tkProperty, qualified_identifier, 
                //                               property_interface, property_specifiers, 
                //                               tkSemiColon, array_defaultproperty
{ 
			CurrentSemanticValue.stn = NewSimplePropertyDefinition(ValueStack[ValueStack.Depth-5].stn as method_name, ValueStack[ValueStack.Depth-4].stn as property_interface, ValueStack[ValueStack.Depth-3].stn as property_accessors, proc_attribute.attr_none, ValueStack[ValueStack.Depth-1].stn as property_array_default, CurrentLocationSpan);
        }
        break;
      case 371: // simple_property_definition -> tkProperty, qualified_identifier, 
                //                               property_interface, property_specifiers, 
                //                               tkSemiColon, property_modificator, tkSemiColon, 
                //                               array_defaultproperty
{ 
            proc_attribute pa = proc_attribute.attr_none;
            if (ValueStack[ValueStack.Depth-3].id.name.ToLower() == "virtual")
               	pa = proc_attribute.attr_virtual;
 			else if (ValueStack[ValueStack.Depth-3].id.name.ToLower() == "override") 
 			    pa = proc_attribute.attr_override;
            else if (ValueStack[ValueStack.Depth-3].id.name.ToLower() == "abstract") 
 			    pa = proc_attribute.attr_abstract;
			CurrentSemanticValue.stn = NewSimplePropertyDefinition(ValueStack[ValueStack.Depth-7].stn as method_name, ValueStack[ValueStack.Depth-6].stn as property_interface, ValueStack[ValueStack.Depth-5].stn as property_accessors, pa, ValueStack[ValueStack.Depth-1].stn as property_array_default, CurrentLocationSpan);
        }
        break;
      case 372: // simple_property_definition -> class_or_static, tkProperty, qualified_identifier, 
                //                               property_interface, property_specifiers, 
                //                               tkSemiColon, array_defaultproperty
{ 
			CurrentSemanticValue.stn = NewSimplePropertyDefinition(ValueStack[ValueStack.Depth-5].stn as method_name, ValueStack[ValueStack.Depth-4].stn as property_interface, ValueStack[ValueStack.Depth-3].stn as property_accessors, proc_attribute.attr_none, ValueStack[ValueStack.Depth-1].stn as property_array_default, CurrentLocationSpan);
        	(CurrentSemanticValue.stn as simple_property).attr = definition_attribute.Static;
        }
        break;
      case 373: // simple_property_definition -> class_or_static, tkProperty, qualified_identifier, 
                //                               property_interface, property_specifiers, 
                //                               tkSemiColon, property_modificator, tkSemiColon, 
                //                               array_defaultproperty
{ 
			parsertools.AddErrorFromResource("STATIC_PROPERTIES_CANNOT_HAVE_ATTRBUTE_{0}",LocationStack[LocationStack.Depth-3],ValueStack[ValueStack.Depth-3].id.name);        	
        }
        break;
      case 374: // simple_property_definition -> tkAuto, tkProperty, qualified_identifier, 
                //                               property_interface, tkSemiColon
{
			CurrentSemanticValue.stn = NewSimplePropertyDefinition(ValueStack[ValueStack.Depth-3].stn as method_name, ValueStack[ValueStack.Depth-2].stn as property_interface, null, proc_attribute.attr_none, null, CurrentLocationSpan);
			(CurrentSemanticValue.stn as simple_property).is_auto = true;
		}
        break;
      case 375: // simple_property_definition -> class_or_static, tkAuto, tkProperty, 
                //                               qualified_identifier, property_interface, 
                //                               tkSemiColon
{
			CurrentSemanticValue.stn = NewSimplePropertyDefinition(ValueStack[ValueStack.Depth-3].stn as method_name, ValueStack[ValueStack.Depth-2].stn as property_interface, null, proc_attribute.attr_none, null, CurrentLocationSpan);
			(CurrentSemanticValue.stn as simple_property).is_auto = true;
			(CurrentSemanticValue.stn as simple_property).attr = definition_attribute.Static;
		}
        break;
      case 376: // array_defaultproperty -> /* empty */
{ CurrentSemanticValue.stn = null; }
        break;
      case 377: // array_defaultproperty -> tkDefault, tkSemiColon
{ 
			CurrentSemanticValue.stn = new property_array_default();  
			CurrentSemanticValue.stn.source_context = CurrentLocationSpan;
		}
        break;
      case 378: // property_interface -> property_parameter_list, tkColon, fptype
{ 
			CurrentSemanticValue.stn = new property_interface(ValueStack[ValueStack.Depth-3].stn as property_parameter_list, ValueStack[ValueStack.Depth-1].td, null, CurrentLocationSpan);
        }
        break;
      case 379: // property_parameter_list -> /* empty */
{ CurrentSemanticValue.stn = null; }
        break;
      case 380: // property_parameter_list -> tkSquareOpen, parameter_decl_list, tkSquareClose
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-2].stn; }
        break;
      case 381: // parameter_decl_list -> parameter_decl
{ 
			CurrentSemanticValue.stn = new property_parameter_list(ValueStack[ValueStack.Depth-1].stn as property_parameter, CurrentLocationSpan);
		}
        break;
      case 382: // parameter_decl_list -> parameter_decl_list, tkSemiColon, parameter_decl
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-3].stn as property_parameter_list).Add(ValueStack[ValueStack.Depth-1].stn as property_parameter, CurrentLocationSpan);
		}
        break;
      case 383: // parameter_decl -> ident_list, tkColon, fptype
{ 
			CurrentSemanticValue.stn = new property_parameter(ValueStack[ValueStack.Depth-3].stn as ident_list, ValueStack[ValueStack.Depth-1].td, CurrentLocationSpan); 
		}
        break;
      case 384: // optional_read_expr -> expr_with_func_decl_lambda
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 385: // optional_read_expr -> /* empty */
{ CurrentSemanticValue.ex = null; }
        break;
      case 387: // property_specifiers -> tkRead, optional_read_expr, write_property_specifiers
{ 
        	if (ValueStack[ValueStack.Depth-2].ex == null || ValueStack[ValueStack.Depth-2].ex is ident) // ����������� ��������
        	{
        		CurrentSemanticValue.stn = NewPropertySpecifiersRead(ValueStack[ValueStack.Depth-3].id, ValueStack[ValueStack.Depth-2].ex as ident, null, null, ValueStack[ValueStack.Depth-1].stn as property_accessors, CurrentLocationSpan);
        	}
        	else // ����������� ��������
        	{
				var id = NewId("#GetGen", LocationStack[LocationStack.Depth-2]);
                procedure_definition pr = null;
                if (!parsertools.build_tree_for_formatter)
                    pr = CreateAndAddToClassReadFunc(ValueStack[ValueStack.Depth-2].ex, id, LocationStack[LocationStack.Depth-2]);
				CurrentSemanticValue.stn = NewPropertySpecifiersRead(ValueStack[ValueStack.Depth-3].id, id, pr, ValueStack[ValueStack.Depth-2].ex, ValueStack[ValueStack.Depth-1].stn as property_accessors, CurrentLocationSpan); // $2 ��������� ��� �������������� 
			}
        }
        break;
      case 388: // property_specifiers -> tkWrite, unlabelled_stmt, read_property_specifiers
{ 
        	if (ValueStack[ValueStack.Depth-2].stn is empty_statement)
        	{
        	
        		CurrentSemanticValue.stn = NewPropertySpecifiersWrite(ValueStack[ValueStack.Depth-3].id, null, null, null, ValueStack[ValueStack.Depth-1].stn as property_accessors, CurrentLocationSpan);
        	}
        	else if (ValueStack[ValueStack.Depth-2].stn is procedure_call && (ValueStack[ValueStack.Depth-2].stn as procedure_call).is_ident) // ����������� ��������
        	{
        	
        		CurrentSemanticValue.stn = NewPropertySpecifiersWrite(ValueStack[ValueStack.Depth-3].id, (ValueStack[ValueStack.Depth-2].stn as procedure_call).func_name as ident, null, null, ValueStack[ValueStack.Depth-1].stn as property_accessors, CurrentLocationSpan);  // ������ �������� - � ���������������
        	}
        	else // ����������� ��������
        	{
				var id = NewId("#SetGen", LocationStack[LocationStack.Depth-2]);
                procedure_definition pr = null;
                if (!parsertools.build_tree_for_formatter)
                    pr = CreateAndAddToClassWriteProc(ValueStack[ValueStack.Depth-2].stn as statement,id,LocationStack[LocationStack.Depth-2]);
                if (parsertools.build_tree_for_formatter)
					CurrentSemanticValue.stn = NewPropertySpecifiersWrite(ValueStack[ValueStack.Depth-3].id, id, pr, ValueStack[ValueStack.Depth-2].stn as statement, ValueStack[ValueStack.Depth-1].stn as property_accessors, CurrentLocationSpan); // $2 ��������� ��� ��������������
				else CurrentSemanticValue.stn = NewPropertySpecifiersWrite(ValueStack[ValueStack.Depth-3].id, id, pr, null, ValueStack[ValueStack.Depth-1].stn as property_accessors, CurrentLocationSpan); 	
			}
        }
        break;
      case 390: // write_property_specifiers -> tkWrite, unlabelled_stmt
{ 
        	if (ValueStack[ValueStack.Depth-1].stn is empty_statement)
        	{
        	
        		CurrentSemanticValue.stn = NewPropertySpecifiersWrite(ValueStack[ValueStack.Depth-2].id, null, null, null, null, CurrentLocationSpan);
        	}
        	else if (ValueStack[ValueStack.Depth-1].stn is procedure_call && (ValueStack[ValueStack.Depth-1].stn as procedure_call).is_ident)
        	{
        		CurrentSemanticValue.stn = NewPropertySpecifiersWrite(ValueStack[ValueStack.Depth-2].id, (ValueStack[ValueStack.Depth-1].stn as procedure_call).func_name as ident, null, null, null, CurrentLocationSpan); // ������ �������� - � ���������������
        	}
        	else 
        	{
				var id = NewId("#SetGen", LocationStack[LocationStack.Depth-1]);
                procedure_definition pr = null;
                if (!parsertools.build_tree_for_formatter)
                    pr = CreateAndAddToClassWriteProc(ValueStack[ValueStack.Depth-1].stn as statement,id,LocationStack[LocationStack.Depth-1]);
                if (parsertools.build_tree_for_formatter)
					CurrentSemanticValue.stn = NewPropertySpecifiersWrite(ValueStack[ValueStack.Depth-2].id, id, pr, ValueStack[ValueStack.Depth-1].stn as statement, null, CurrentLocationSpan);
				else CurrentSemanticValue.stn = NewPropertySpecifiersWrite(ValueStack[ValueStack.Depth-2].id, id, pr, null, null, CurrentLocationSpan);	
			}
       }
        break;
      case 392: // read_property_specifiers -> tkRead, optional_read_expr
{ 
        	if (ValueStack[ValueStack.Depth-1].ex == null || ValueStack[ValueStack.Depth-1].ex is ident)
        	{
        		CurrentSemanticValue.stn = NewPropertySpecifiersRead(ValueStack[ValueStack.Depth-2].id, ValueStack[ValueStack.Depth-1].ex as ident, null, null, null, CurrentLocationSpan);
        	}
        	else 
        	{
				var id = NewId("#GetGen", LocationStack[LocationStack.Depth-1]);
                procedure_definition pr = null;
                if (!parsertools.build_tree_for_formatter)
                    pr = CreateAndAddToClassReadFunc(ValueStack[ValueStack.Depth-1].ex,id,LocationStack[LocationStack.Depth-1]);
				CurrentSemanticValue.stn = NewPropertySpecifiersRead(ValueStack[ValueStack.Depth-2].id, id, pr, ValueStack[ValueStack.Depth-1].ex, null, CurrentLocationSpan);
			}
       }
        break;
      case 393: // var_decl -> var_decl_part, tkSemiColon
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-2].stn; }
        break;
      case 396: // var_decl_part -> ident_list, tkColon, type_ref
{ 
			CurrentSemanticValue.stn = new var_def_statement(ValueStack[ValueStack.Depth-3].stn as ident_list, ValueStack[ValueStack.Depth-1].td, null, definition_attribute.None, false, CurrentLocationSpan);
		}
        break;
      case 397: // var_decl_part -> ident_list, tkAssign, expr
{ 
			CurrentSemanticValue.stn = new var_def_statement(ValueStack[ValueStack.Depth-3].stn as ident_list, null, ValueStack[ValueStack.Depth-1].ex, definition_attribute.None, false, CurrentLocationSpan);		
		}
        break;
      case 398: // var_decl_part -> ident_list, tkColon, type_ref, tkAssignOrEqual, 
                //                  typed_var_init_expression
{ 
			CurrentSemanticValue.stn = new var_def_statement(ValueStack[ValueStack.Depth-5].stn as ident_list, ValueStack[ValueStack.Depth-3].td, ValueStack[ValueStack.Depth-1].ex, definition_attribute.None, false, CurrentLocationSpan); 
		}
        break;
      case 399: // typed_var_init_expression -> typed_const_plus
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 400: // typed_var_init_expression -> expl_func_decl_lambda
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 401: // typed_var_init_expression -> identifier, tkArrow, lambda_function_body
{  
			var idList = new ident_list(ValueStack[ValueStack.Depth-3].id, LocationStack[LocationStack.Depth-3]); 
			var formalPars = new formal_parameters(new typed_parameters(idList, new lambda_inferred_type(new PascalABCCompiler.TreeRealization.lambda_any_type_node(), LocationStack[LocationStack.Depth-3]), parametr_kind.none, null, LocationStack[LocationStack.Depth-3]), LocationStack[LocationStack.Depth-3]);
			CurrentSemanticValue.ex = new function_lambda_definition(lambdaHelper.CreateLambdaName(), formalPars, new lambda_inferred_type(new PascalABCCompiler.TreeRealization.lambda_any_type_node(), LocationStack[LocationStack.Depth-3]), ValueStack[ValueStack.Depth-1].stn as statement_list, CurrentLocationSpan);
		}
        break;
      case 402: // typed_var_init_expression -> tkRoundOpen, tkRoundClose, lambda_type_ref, 
                //                              tkArrow, lambda_function_body
{
			CurrentSemanticValue.ex = new function_lambda_definition(lambdaHelper.CreateLambdaName(), null, ValueStack[ValueStack.Depth-3].td, ValueStack[ValueStack.Depth-1].stn as statement_list, CurrentLocationSpan);
		}
        break;
      case 403: // typed_var_init_expression -> tkRoundOpen, typed_const_list, tkRoundClose, 
                //                              tkArrow, lambda_function_body
{  
		    var el = ValueStack[ValueStack.Depth-4].stn as expression_list;
		    var cnt = el.Count;
		    
			var idList = new ident_list();
			idList.source_context = LocationStack[LocationStack.Depth-4];
			
			for (int j = 0; j < cnt; j++)
			{
				if (!(el.expressions[j] is ident))
					parsertools.AddErrorFromResource("ONE_TKIDENTIFIER",el.expressions[j].source_context);
				idList.idents.Add(el.expressions[j] as ident);
			}	
				
			var any = new lambda_inferred_type(new PascalABCCompiler.TreeRealization.lambda_any_type_node(), LocationStack[LocationStack.Depth-4]);	
				
			var formalPars = new formal_parameters(new typed_parameters(idList, any, parametr_kind.none, null, LocationStack[LocationStack.Depth-4]), LocationStack[LocationStack.Depth-4]);
			CurrentSemanticValue.ex = new function_lambda_definition(lambdaHelper.CreateLambdaName(), formalPars, any, ValueStack[ValueStack.Depth-1].stn as statement_list, CurrentLocationSpan);
		}
        break;
      case 404: // typed_const_plus -> typed_const
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 405: // typed_const_plus -> default_expr
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 406: // constr_destr_decl -> constr_destr_header, block
{ 
			CurrentSemanticValue.stn = new procedure_definition(ValueStack[ValueStack.Depth-2].td as procedure_header, ValueStack[ValueStack.Depth-1].stn as block, CurrentLocationSpan);
        }
        break;
      case 407: // constr_destr_decl -> tkConstructor, optional_proc_name, fp_list, tkAssign, 
                //                      unlabelled_stmt, tkSemiColon
{ 
   			if (ValueStack[ValueStack.Depth-2].stn is empty_statement)
				parsertools.AddErrorFromResource("EMPTY_STATEMENT_IN_SHORT_PROC_DEFINITION",LocationStack[LocationStack.Depth-1]);
            var tmp = new constructor(null,ValueStack[ValueStack.Depth-4].stn as formal_parameters,new procedure_attributes_list(new List<procedure_attribute>(),CurrentLocationSpan),ValueStack[ValueStack.Depth-5].stn as method_name,false,false,null,null,LexLocation.MergeAll(LocationStack[LocationStack.Depth-6],LocationStack[LocationStack.Depth-5],LocationStack[LocationStack.Depth-4]));
            CurrentSemanticValue.stn = new procedure_definition(tmp as procedure_header, new block(null,new statement_list(ValueStack[ValueStack.Depth-2].stn as statement,LocationStack[LocationStack.Depth-2]),LocationStack[LocationStack.Depth-2]), LocationStack[LocationStack.Depth-6].Merge(LocationStack[LocationStack.Depth-2]));
            if (parsertools.build_tree_for_formatter)
				CurrentSemanticValue.stn = new short_func_definition(CurrentSemanticValue.stn as procedure_definition);
        }
        break;
      case 408: // constr_destr_decl -> class_or_static, tkConstructor, optional_proc_name, 
                //                      fp_list, tkAssign, unlabelled_stmt, tkSemiColon
{ 
   			if (ValueStack[ValueStack.Depth-2].stn is empty_statement)
				parsertools.AddErrorFromResource("EMPTY_STATEMENT_IN_SHORT_PROC_DEFINITION",LocationStack[LocationStack.Depth-1]);
            var tmp = new constructor(null,ValueStack[ValueStack.Depth-4].stn as formal_parameters,new procedure_attributes_list(new List<procedure_attribute>(),CurrentLocationSpan),ValueStack[ValueStack.Depth-5].stn as method_name,false,true,null,null,LexLocation.MergeAll(LocationStack[LocationStack.Depth-7],LocationStack[LocationStack.Depth-6],LocationStack[LocationStack.Depth-5],LocationStack[LocationStack.Depth-4]));
            CurrentSemanticValue.stn = new procedure_definition(tmp as procedure_header, new block(null,new statement_list(ValueStack[ValueStack.Depth-2].stn as statement,LocationStack[LocationStack.Depth-2]),LocationStack[LocationStack.Depth-2]), LocationStack[LocationStack.Depth-7].Merge(LocationStack[LocationStack.Depth-2]));
            if (parsertools.build_tree_for_formatter)
				CurrentSemanticValue.stn = new short_func_definition(CurrentSemanticValue.stn as procedure_definition);
        }
        break;
      case 409: // inclass_constr_destr_decl -> constr_destr_header, inclass_block
{ 
			CurrentSemanticValue.stn = new procedure_definition(ValueStack[ValueStack.Depth-2].td as procedure_header, ValueStack[ValueStack.Depth-1].stn as block, CurrentLocationSpan);
        }
        break;
      case 410: // inclass_constr_destr_decl -> tkConstructor, optional_proc_name, fp_list, 
                //                              tkAssign, unlabelled_stmt, tkSemiColon
{ 
   			if (ValueStack[ValueStack.Depth-2].stn is empty_statement)
				parsertools.AddErrorFromResource("EMPTY_STATEMENT_IN_SHORT_PROC_DEFINITION",LocationStack[LocationStack.Depth-1]);
            var tmp = new constructor(null,ValueStack[ValueStack.Depth-4].stn as formal_parameters,new procedure_attributes_list(new List<procedure_attribute>(),CurrentLocationSpan),ValueStack[ValueStack.Depth-5].stn as method_name,false,false,null,null,LexLocation.MergeAll(LocationStack[LocationStack.Depth-6],LocationStack[LocationStack.Depth-5],LocationStack[LocationStack.Depth-4],LocationStack[LocationStack.Depth-3]));
            CurrentSemanticValue.stn = new procedure_definition(tmp as procedure_header, new block(null,new statement_list(ValueStack[ValueStack.Depth-2].stn as statement,LocationStack[LocationStack.Depth-2]),LocationStack[LocationStack.Depth-2]), CurrentLocationSpan);
            if (parsertools.build_tree_for_formatter)
				CurrentSemanticValue.stn = new short_func_definition(CurrentSemanticValue.stn as procedure_definition);
        }
        break;
      case 411: // inclass_constr_destr_decl -> class_or_static, tkConstructor, optional_proc_name, 
                //                              fp_list, tkAssign, unlabelled_stmt, tkSemiColon
{ 
   			if (ValueStack[ValueStack.Depth-2].stn is empty_statement)
				parsertools.AddErrorFromResource("EMPTY_STATEMENT_IN_SHORT_PROC_DEFINITION",LocationStack[LocationStack.Depth-1]);
            var tmp = new constructor(null,ValueStack[ValueStack.Depth-4].stn as formal_parameters,new procedure_attributes_list(new List<procedure_attribute>(),CurrentLocationSpan),ValueStack[ValueStack.Depth-5].stn as method_name,false,true,null,null,LexLocation.MergeAll(LocationStack[LocationStack.Depth-7],LocationStack[LocationStack.Depth-6],LocationStack[LocationStack.Depth-5],LocationStack[LocationStack.Depth-4]));
            CurrentSemanticValue.stn = new procedure_definition(tmp as procedure_header, new block(null,new statement_list(ValueStack[ValueStack.Depth-2].stn as statement,LocationStack[LocationStack.Depth-2]),LocationStack[LocationStack.Depth-2]), CurrentLocationSpan);
            if (parsertools.build_tree_for_formatter)
				CurrentSemanticValue.stn = new short_func_definition(CurrentSemanticValue.stn as procedure_definition);
        }
        break;
      case 412: // proc_func_decl -> proc_func_decl_noclass
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 413: // proc_func_decl -> class_or_static, proc_func_decl_noclass
{ 
			(ValueStack[ValueStack.Depth-1].stn as procedure_definition).proc_header.class_keyword = true;
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn;
		}
        break;
      case 414: // proc_func_decl_noclass -> proc_func_header, proc_func_external_block
{
            CurrentSemanticValue.stn = new procedure_definition(ValueStack[ValueStack.Depth-2].td as procedure_header, ValueStack[ValueStack.Depth-1].stn as proc_block, CurrentLocationSpan);
        }
        break;
      case 415: // proc_func_decl_noclass -> tkFunction, func_name, fp_list, tkColon, fptype, 
                //                           optional_method_modificators1, tkAssign, expr_l1, 
                //                           tkSemiColon
{
			CurrentSemanticValue.stn = SyntaxTreeBuilder.BuildShortFuncDefinition(ValueStack[ValueStack.Depth-7].stn as formal_parameters, ValueStack[ValueStack.Depth-4].stn as procedure_attributes_list, ValueStack[ValueStack.Depth-8].stn as method_name, ValueStack[ValueStack.Depth-5].td as type_definition, ValueStack[ValueStack.Depth-2].ex, LocationStack[LocationStack.Depth-9].Merge(LocationStack[LocationStack.Depth-4]));
		}
        break;
      case 416: // proc_func_decl_noclass -> tkFunction, func_name, fp_list, 
                //                           optional_method_modificators1, tkAssign, expr_l1, 
                //                           tkSemiColon
{
			if (ValueStack[ValueStack.Depth-2].ex is dot_question_node)
				parsertools.AddErrorFromResource("DOT_QUECTION_IN_SHORT_FUN",LocationStack[LocationStack.Depth-2]);
	
			CurrentSemanticValue.stn = SyntaxTreeBuilder.BuildShortFuncDefinition(ValueStack[ValueStack.Depth-5].stn as formal_parameters, ValueStack[ValueStack.Depth-4].stn as procedure_attributes_list, ValueStack[ValueStack.Depth-6].stn as method_name, null, ValueStack[ValueStack.Depth-2].ex, LocationStack[LocationStack.Depth-7].Merge(LocationStack[LocationStack.Depth-4]));
		}
        break;
      case 417: // proc_func_decl_noclass -> tkFunction, func_name, fp_list, tkColon, fptype, 
                //                           optional_method_modificators1, tkAssign, 
                //                           func_decl_lambda, tkSemiColon
{
			CurrentSemanticValue.stn = SyntaxTreeBuilder.BuildShortFuncDefinition(ValueStack[ValueStack.Depth-7].stn as formal_parameters, ValueStack[ValueStack.Depth-4].stn as procedure_attributes_list, ValueStack[ValueStack.Depth-8].stn as method_name, ValueStack[ValueStack.Depth-5].td as type_definition, ValueStack[ValueStack.Depth-2].ex, LocationStack[LocationStack.Depth-9].Merge(LocationStack[LocationStack.Depth-4]));
		}
        break;
      case 418: // proc_func_decl_noclass -> tkFunction, func_name, fp_list, 
                //                           optional_method_modificators1, tkAssign, 
                //                           func_decl_lambda, tkSemiColon
{
			CurrentSemanticValue.stn = SyntaxTreeBuilder.BuildShortFuncDefinition(ValueStack[ValueStack.Depth-5].stn as formal_parameters, ValueStack[ValueStack.Depth-4].stn as procedure_attributes_list, ValueStack[ValueStack.Depth-6].stn as method_name, null, ValueStack[ValueStack.Depth-2].ex, LocationStack[LocationStack.Depth-7].Merge(LocationStack[LocationStack.Depth-4]));
		}
        break;
      case 419: // proc_func_decl_noclass -> tkProcedure, proc_name, fp_list, 
                //                           optional_method_modificators1, tkAssign, 
                //                           unlabelled_stmt, tkSemiColon
{
			if (ValueStack[ValueStack.Depth-2].stn is empty_statement)
				parsertools.AddErrorFromResource("EMPTY_STATEMENT_IN_SHORT_PROC_DEFINITION",LocationStack[LocationStack.Depth-2]);
			CurrentSemanticValue.stn = SyntaxTreeBuilder.BuildShortProcDefinition(ValueStack[ValueStack.Depth-5].stn as formal_parameters, ValueStack[ValueStack.Depth-4].stn as procedure_attributes_list, ValueStack[ValueStack.Depth-6].stn as method_name, ValueStack[ValueStack.Depth-2].stn as statement, LocationStack[LocationStack.Depth-7].Merge(LocationStack[LocationStack.Depth-4]));
		}
        break;
      case 420: // proc_func_decl_noclass -> proc_func_header, tkForward, tkSemiColon
{
			CurrentSemanticValue.stn = new procedure_definition(ValueStack[ValueStack.Depth-3].td as procedure_header, null, CurrentLocationSpan);
            (CurrentSemanticValue.stn as procedure_definition).proc_header.proc_attributes.Add((procedure_attribute)ValueStack[ValueStack.Depth-2].id, ValueStack[ValueStack.Depth-2].id.source_context);
		}
        break;
      case 421: // inclass_proc_func_decl -> inclass_proc_func_decl_noclass
{ 
            CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; 
        }
        break;
      case 422: // inclass_proc_func_decl -> class_or_static, inclass_proc_func_decl_noclass
{ 
		    if ((ValueStack[ValueStack.Depth-1].stn as procedure_definition).proc_header != null)
				(ValueStack[ValueStack.Depth-1].stn as procedure_definition).proc_header.class_keyword = true;
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn;
		}
        break;
      case 423: // inclass_proc_func_decl_noclass -> proc_func_header, inclass_block
{
            CurrentSemanticValue.stn = new procedure_definition(ValueStack[ValueStack.Depth-2].td as procedure_header, ValueStack[ValueStack.Depth-1].stn as proc_block, CurrentLocationSpan);
		}
        break;
      case 424: // inclass_proc_func_decl_noclass -> tkFunction, func_name, fp_list, tkColon, 
                //                                   fptype, optional_method_modificators1, 
                //                                   tkAssign, expr_l1_func_decl_lambda, 
                //                                   tkSemiColon
{
			CurrentSemanticValue.stn = SyntaxTreeBuilder.BuildShortFuncDefinition(ValueStack[ValueStack.Depth-7].stn as formal_parameters, ValueStack[ValueStack.Depth-4].stn as procedure_attributes_list, ValueStack[ValueStack.Depth-8].stn as method_name, ValueStack[ValueStack.Depth-5].td as type_definition, ValueStack[ValueStack.Depth-2].ex, LocationStack[LocationStack.Depth-9].Merge(LocationStack[LocationStack.Depth-4]));
			if (parsertools.build_tree_for_formatter)
				CurrentSemanticValue.stn = new short_func_definition(CurrentSemanticValue.stn as procedure_definition);
		}
        break;
      case 425: // inclass_proc_func_decl_noclass -> tkFunction, func_name, fp_list, 
                //                                   optional_method_modificators1, tkAssign, 
                //                                   expr_l1_func_decl_lambda, tkSemiColon
{
			CurrentSemanticValue.stn = SyntaxTreeBuilder.BuildShortFuncDefinition(ValueStack[ValueStack.Depth-5].stn as formal_parameters, ValueStack[ValueStack.Depth-4].stn as procedure_attributes_list, ValueStack[ValueStack.Depth-6].stn as method_name, null, ValueStack[ValueStack.Depth-2].ex, LocationStack[LocationStack.Depth-7].Merge(LocationStack[LocationStack.Depth-4]));
			if (parsertools.build_tree_for_formatter)
				CurrentSemanticValue.stn = new short_func_definition(CurrentSemanticValue.stn as procedure_definition);
		}
        break;
      case 426: // inclass_proc_func_decl_noclass -> tkProcedure, proc_name, fp_list, 
                //                                   optional_method_modificators1, tkAssign, 
                //                                   unlabelled_stmt, tkSemiColon
{
			CurrentSemanticValue.stn = SyntaxTreeBuilder.BuildShortProcDefinition(ValueStack[ValueStack.Depth-5].stn as formal_parameters, ValueStack[ValueStack.Depth-4].stn as procedure_attributes_list, ValueStack[ValueStack.Depth-6].stn as method_name, ValueStack[ValueStack.Depth-2].stn as statement, LocationStack[LocationStack.Depth-7].Merge(LocationStack[LocationStack.Depth-4]));
			if (parsertools.build_tree_for_formatter)
				CurrentSemanticValue.stn = new short_func_definition(CurrentSemanticValue.stn as procedure_definition);
		}
        break;
      case 427: // proc_func_external_block -> block
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 428: // proc_func_external_block -> external_block
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 429: // proc_name -> func_name
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 430: // func_name -> func_meth_name_ident
{ 
			CurrentSemanticValue.stn = new method_name(null,null, ValueStack[ValueStack.Depth-1].id, null, CurrentLocationSpan); 
		}
        break;
      case 431: // func_name -> func_class_name_ident_list, tkPoint, func_meth_name_ident
{ 
        	var ln = ValueStack[ValueStack.Depth-3].ob as List<ident>;
        	var cnt = ln.Count;
        	if (cnt == 1)
				CurrentSemanticValue.stn = new method_name(null, ln[cnt-1], ValueStack[ValueStack.Depth-1].id, null, CurrentLocationSpan);
			else 	
				CurrentSemanticValue.stn = new method_name(ln, ln[cnt-1], ValueStack[ValueStack.Depth-1].id, null, CurrentLocationSpan);
		}
        break;
      case 432: // func_class_name_ident -> func_name_with_template_args
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 433: // func_class_name_ident_list -> func_class_name_ident
{ 
			CurrentSemanticValue.ob = new List<ident>(); 
			(CurrentSemanticValue.ob as List<ident>).Add(ValueStack[ValueStack.Depth-1].id);
		}
        break;
      case 434: // func_class_name_ident_list -> func_class_name_ident_list, tkPoint, 
                //                               func_class_name_ident
{ 
			(ValueStack[ValueStack.Depth-3].ob as List<ident>).Add(ValueStack[ValueStack.Depth-1].id);
			CurrentSemanticValue.ob = ValueStack[ValueStack.Depth-3].ob; 
		}
        break;
      case 435: // func_meth_name_ident -> func_name_with_template_args
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 436: // func_meth_name_ident -> operator_name_ident
{ CurrentSemanticValue.id = (ident)ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 437: // func_meth_name_ident -> operator_name_ident, template_arguments
{ CurrentSemanticValue.id = new template_operator_name(null, ValueStack[ValueStack.Depth-1].stn as ident_list, ValueStack[ValueStack.Depth-2].ex as operator_name_ident, CurrentLocationSpan); }
        break;
      case 438: // func_name_with_template_args -> func_name_ident
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 439: // func_name_with_template_args -> func_name_ident, template_arguments
{ 
			CurrentSemanticValue.id = new template_type_name(ValueStack[ValueStack.Depth-2].id.name, ValueStack[ValueStack.Depth-1].stn as ident_list, CurrentLocationSpan); 
        }
        break;
      case 440: // func_name_ident -> identifier
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 441: // proc_header -> tkProcedure, proc_name, fp_list, optional_method_modificators, 
                //                optional_where_section
{ 
        	CurrentSemanticValue.td = new procedure_header(ValueStack[ValueStack.Depth-3].stn as formal_parameters, ValueStack[ValueStack.Depth-2].stn as procedure_attributes_list, ValueStack[ValueStack.Depth-4].stn as method_name, ValueStack[ValueStack.Depth-1].stn as where_definition_list, CurrentLocationSpan); 
        }
        break;
      case 442: // func_header -> tkFunction, func_name, fp_list, optional_method_modificators, 
                //                optional_where_section
{
			CurrentSemanticValue.td = new function_header(ValueStack[ValueStack.Depth-3].stn as formal_parameters, ValueStack[ValueStack.Depth-2].stn as procedure_attributes_list, ValueStack[ValueStack.Depth-4].stn as method_name, ValueStack[ValueStack.Depth-1].stn as where_definition_list, null, CurrentLocationSpan); 
		}
        break;
      case 443: // func_header -> tkFunction, func_name, fp_list, tkColon, fptype, 
                //                optional_method_modificators, optional_where_section
{ 
			CurrentSemanticValue.td = new function_header(ValueStack[ValueStack.Depth-5].stn as formal_parameters, ValueStack[ValueStack.Depth-2].stn as procedure_attributes_list, ValueStack[ValueStack.Depth-6].stn as method_name, ValueStack[ValueStack.Depth-1].stn as where_definition_list, ValueStack[ValueStack.Depth-3].td as type_definition, CurrentLocationSpan); 
        }
        break;
      case 444: // external_block -> tkExternal, external_directive_ident, tkName, 
                //                   external_directive_ident, tkSemiColon
{ 
			CurrentSemanticValue.stn = new external_directive(ValueStack[ValueStack.Depth-4].ex, ValueStack[ValueStack.Depth-2].ex, CurrentLocationSpan); 
		}
        break;
      case 445: // external_block -> tkExternal, external_directive_ident, tkSemiColon
{ 
			CurrentSemanticValue.stn = new external_directive(ValueStack[ValueStack.Depth-2].ex, null, CurrentLocationSpan); 
		}
        break;
      case 446: // external_block -> tkExternal, tkSemiColon
{ 
			CurrentSemanticValue.stn = new external_directive(null, null, CurrentLocationSpan); 
		}
        break;
      case 447: // external_directive_ident -> identifier
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 448: // external_directive_ident -> literal
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 449: // block -> decl_sect_list, compound_stmt, tkSemiColon
{ 
			CurrentSemanticValue.stn = new block(ValueStack[ValueStack.Depth-3].stn as declarations, ValueStack[ValueStack.Depth-2].stn as statement_list, CurrentLocationSpan); 
		}
        break;
      case 450: // inclass_block -> inclass_decl_sect_list, compound_stmt, tkSemiColon
{ 
			CurrentSemanticValue.stn = new block(ValueStack[ValueStack.Depth-3].stn as declarations, ValueStack[ValueStack.Depth-2].stn as statement_list, CurrentLocationSpan); 
		}
        break;
      case 451: // inclass_block -> external_block
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 452: // fp_list -> /* empty */
{ CurrentSemanticValue.stn = null; }
        break;
      case 453: // fp_list -> tkRoundOpen, tkRoundClose
{ 
			CurrentSemanticValue.stn = null;
		}
        break;
      case 454: // fp_list -> tkRoundOpen, fp_sect_list, tkRoundClose
{ 
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-2].stn;
			if (CurrentSemanticValue.stn != null)
				CurrentSemanticValue.stn.source_context = CurrentLocationSpan;
		}
        break;
      case 455: // fp_sect_list -> fp_sect
{ 
			CurrentSemanticValue.stn = new formal_parameters(ValueStack[ValueStack.Depth-1].stn as typed_parameters, CurrentLocationSpan);
        }
        break;
      case 456: // fp_sect_list -> fp_sect_list, tkSemiColon, fp_sect
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-3].stn as formal_parameters).Add(ValueStack[ValueStack.Depth-1].stn as typed_parameters, CurrentLocationSpan);   
        }
        break;
      case 457: // fp_sect -> attribute_declarations, simple_fp_sect
{  
			(ValueStack[ValueStack.Depth-1].stn as declaration).attributes = ValueStack[ValueStack.Depth-2].stn as  attribute_list;
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn;
        }
        break;
      case 458: // simple_fp_sect -> param_name_list, tkColon, fptype
{ 
			CurrentSemanticValue.stn = new typed_parameters(ValueStack[ValueStack.Depth-3].stn as ident_list, ValueStack[ValueStack.Depth-1].td, parametr_kind.none, null, CurrentLocationSpan); 
		}
        break;
      case 459: // simple_fp_sect -> tkVar, param_name_list, tkColon, fptype
{ 
			CurrentSemanticValue.stn = new typed_parameters(ValueStack[ValueStack.Depth-3].stn as ident_list, ValueStack[ValueStack.Depth-1].td, parametr_kind.var_parametr, null, CurrentLocationSpan);  
		}
        break;
      case 460: // simple_fp_sect -> tkConst, param_name_list, tkColon, fptype
{ 
			CurrentSemanticValue.stn = new typed_parameters(ValueStack[ValueStack.Depth-3].stn as ident_list, ValueStack[ValueStack.Depth-1].td, parametr_kind.const_parametr, null, CurrentLocationSpan);  
		}
        break;
      case 461: // simple_fp_sect -> tkParams, param_name_list, tkColon, fptype
{ 
			CurrentSemanticValue.stn = new typed_parameters(ValueStack[ValueStack.Depth-3].stn as ident_list, ValueStack[ValueStack.Depth-1].td,parametr_kind.params_parametr,null, CurrentLocationSpan);  
		}
        break;
      case 462: // simple_fp_sect -> param_name_list, tkColon, fptype, tkAssign, expr
{ 
			CurrentSemanticValue.stn = new typed_parameters(ValueStack[ValueStack.Depth-5].stn as ident_list, ValueStack[ValueStack.Depth-3].td, parametr_kind.none, ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan); 
		}
        break;
      case 463: // simple_fp_sect -> tkVar, param_name_list, tkColon, fptype, tkAssign, expr
{ 
			CurrentSemanticValue.stn = new typed_parameters(ValueStack[ValueStack.Depth-5].stn as ident_list, ValueStack[ValueStack.Depth-3].td, parametr_kind.var_parametr, ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan);  
		}
        break;
      case 464: // simple_fp_sect -> tkConst, param_name_list, tkColon, fptype, tkAssign, expr
{ 
			CurrentSemanticValue.stn = new typed_parameters(ValueStack[ValueStack.Depth-5].stn as ident_list, ValueStack[ValueStack.Depth-3].td, parametr_kind.const_parametr, ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan);  
		}
        break;
      case 465: // param_name_list -> param_name
{ 
			CurrentSemanticValue.stn = new ident_list(ValueStack[ValueStack.Depth-1].id, CurrentLocationSpan); 
		}
        break;
      case 466: // param_name_list -> param_name_list, tkComma, param_name
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-3].stn as ident_list).Add(ValueStack[ValueStack.Depth-1].id, CurrentLocationSpan);  
		}
        break;
      case 467: // param_name -> identifier
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 468: // fptype -> type_ref
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 469: // fptype_noproctype -> simple_type
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 470: // fptype_noproctype -> string_type
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 471: // fptype_noproctype -> pointer_type
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 472: // fptype_noproctype -> structured_type
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 473: // fptype_noproctype -> template_type
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 474: // stmt -> unlabelled_stmt
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 475: // stmt -> label_name, tkColon, stmt
{ 
			CurrentSemanticValue.stn = new labeled_statement(ValueStack[ValueStack.Depth-3].id, ValueStack[ValueStack.Depth-1].stn as statement, CurrentLocationSpan);  
		}
        break;
      case 476: // unlabelled_stmt -> /* empty */
{ 
			CurrentSemanticValue.stn = new empty_statement(); 
			CurrentSemanticValue.stn.source_context = null;
		}
        break;
      case 477: // unlabelled_stmt -> assignment
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 478: // unlabelled_stmt -> proc_call
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 479: // unlabelled_stmt -> goto_stmt
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 480: // unlabelled_stmt -> compound_stmt
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 481: // unlabelled_stmt -> if_stmt
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 482: // unlabelled_stmt -> case_stmt
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 483: // unlabelled_stmt -> repeat_stmt
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 484: // unlabelled_stmt -> while_stmt
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 485: // unlabelled_stmt -> for_stmt
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 486: // unlabelled_stmt -> with_stmt
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 487: // unlabelled_stmt -> inherited_message
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 488: // unlabelled_stmt -> try_stmt
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 489: // unlabelled_stmt -> raise_stmt
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 490: // unlabelled_stmt -> foreach_stmt
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 491: // unlabelled_stmt -> var_stmt
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 492: // unlabelled_stmt -> expr_as_stmt
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 493: // unlabelled_stmt -> lock_stmt
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 494: // unlabelled_stmt -> yield_stmt
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 495: // unlabelled_stmt -> yield_sequence_stmt
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 496: // unlabelled_stmt -> loop_stmt
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 497: // unlabelled_stmt -> match_with
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 498: // loop_stmt -> tkLoop, expr_l1, tkDo, unlabelled_stmt
{
			CurrentSemanticValue.stn = new loop_stmt(ValueStack[ValueStack.Depth-3].ex,ValueStack[ValueStack.Depth-1].stn as statement,CurrentLocationSpan);
		}
        break;
      case 499: // yield_stmt -> tkYield, expr_l1
{
			CurrentSemanticValue.stn = new yield_node(ValueStack[ValueStack.Depth-1].ex,CurrentLocationSpan);
		}
        break;
      case 500: // yield_sequence_stmt -> tkYield, tkSequence, expr_l1
{
			CurrentSemanticValue.stn = new yield_sequence_node(ValueStack[ValueStack.Depth-1].ex,CurrentLocationSpan);
		}
        break;
      case 501: // var_stmt -> tkVar, var_decl_part
{ 
			CurrentSemanticValue.stn = new var_statement(ValueStack[ValueStack.Depth-1].stn as var_def_statement, CurrentLocationSpan);
		}
        break;
      case 502: // var_stmt -> tkRoundOpen, tkVar, identifier, tkComma, var_ident_list, 
                //             tkRoundClose, tkAssign, expr
{
			(ValueStack[ValueStack.Depth-4].ob as ident_list).Insert(0,ValueStack[ValueStack.Depth-6].id);
			(ValueStack[ValueStack.Depth-4].ob as syntax_tree_node).source_context = LexLocation.MergeAll(LocationStack[LocationStack.Depth-8],LocationStack[LocationStack.Depth-7],LocationStack[LocationStack.Depth-6],LocationStack[LocationStack.Depth-5],LocationStack[LocationStack.Depth-4],LocationStack[LocationStack.Depth-3]);
			CurrentSemanticValue.stn = new assign_var_tuple(ValueStack[ValueStack.Depth-4].ob as ident_list, ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan);
		}
        break;
      case 503: // var_stmt -> tkVar, tkRoundOpen, identifier, tkComma, ident_list, tkRoundClose, 
                //             tkAssign, expr
{
			(ValueStack[ValueStack.Depth-4].stn as ident_list).Insert(0,ValueStack[ValueStack.Depth-6].id);
			ValueStack[ValueStack.Depth-4].stn.source_context = LexLocation.MergeAll(LocationStack[LocationStack.Depth-8],LocationStack[LocationStack.Depth-7],LocationStack[LocationStack.Depth-6],LocationStack[LocationStack.Depth-5],LocationStack[LocationStack.Depth-4],LocationStack[LocationStack.Depth-3]);
			CurrentSemanticValue.stn = new assign_var_tuple(ValueStack[ValueStack.Depth-4].stn as ident_list, ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan);
	    }
        break;
      case 504: // assignment -> var_reference, assign_operator, expr_with_func_decl_lambda
{      
			CurrentSemanticValue.stn = new assign(ValueStack[ValueStack.Depth-3].ex as addressed_value, ValueStack[ValueStack.Depth-1].ex, ValueStack[ValueStack.Depth-2].op.type, CurrentLocationSpan);
        }
        break;
      case 505: // assignment -> tkRoundOpen, variable, tkComma, variable_list, tkRoundClose, 
                //               assign_operator, expr
{
			if (ValueStack[ValueStack.Depth-2].op.type != Operators.Assignment)
			    parsertools.AddErrorFromResource("ONLY_BASE_ASSIGNMENT_FOR_TUPLE",LocationStack[LocationStack.Depth-2]);
			(ValueStack[ValueStack.Depth-4].ob as addressed_value_list).Insert(0,ValueStack[ValueStack.Depth-6].ex as addressed_value);
			(ValueStack[ValueStack.Depth-4].ob as syntax_tree_node).source_context = LexLocation.MergeAll(LocationStack[LocationStack.Depth-7],LocationStack[LocationStack.Depth-6],LocationStack[LocationStack.Depth-5],LocationStack[LocationStack.Depth-4],LocationStack[LocationStack.Depth-3]);
			CurrentSemanticValue.stn = new assign_tuple(ValueStack[ValueStack.Depth-4].ob as addressed_value_list, ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan);
		}
        break;
      case 506: // variable_list -> variable
{
		CurrentSemanticValue.ob = new addressed_value_list(ValueStack[ValueStack.Depth-1].ex as addressed_value,LocationStack[LocationStack.Depth-1]);
	}
        break;
      case 507: // variable_list -> variable_list, tkComma, variable
{
		(ValueStack[ValueStack.Depth-3].ob as addressed_value_list).Add(ValueStack[ValueStack.Depth-1].ex as addressed_value);
		(ValueStack[ValueStack.Depth-3].ob as syntax_tree_node).source_context = LexLocation.MergeAll(LocationStack[LocationStack.Depth-3],LocationStack[LocationStack.Depth-2],LocationStack[LocationStack.Depth-1]);
		CurrentSemanticValue.ob = ValueStack[ValueStack.Depth-3].ob;
	}
        break;
      case 508: // var_ident_list -> tkVar, identifier
{
		CurrentSemanticValue.ob = new ident_list(ValueStack[ValueStack.Depth-1].id,CurrentLocationSpan);
	}
        break;
      case 509: // var_ident_list -> var_ident_list, tkComma, tkVar, identifier
{
		(ValueStack[ValueStack.Depth-4].ob as ident_list).Add(ValueStack[ValueStack.Depth-1].id);
		(ValueStack[ValueStack.Depth-4].ob as ident_list).source_context = LexLocation.MergeAll(LocationStack[LocationStack.Depth-4],LocationStack[LocationStack.Depth-3],LocationStack[LocationStack.Depth-2],LocationStack[LocationStack.Depth-1]);
		CurrentSemanticValue.ob = ValueStack[ValueStack.Depth-4].ob;
	}
        break;
      case 510: // proc_call -> var_reference
{ 
			CurrentSemanticValue.stn = new procedure_call(ValueStack[ValueStack.Depth-1].ex as addressed_value, ValueStack[ValueStack.Depth-1].ex is ident, CurrentLocationSpan); 
		}
        break;
      case 511: // goto_stmt -> tkGoto, label_name
{ 
			CurrentSemanticValue.stn = new goto_statement(ValueStack[ValueStack.Depth-1].id, CurrentLocationSpan); 
		}
        break;
      case 512: // compound_stmt -> tkBegin, stmt_list, tkEnd
{
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-2].stn;
			(CurrentSemanticValue.stn as statement_list).left_logical_bracket = ValueStack[ValueStack.Depth-3].ti;
			(CurrentSemanticValue.stn as statement_list).right_logical_bracket = ValueStack[ValueStack.Depth-1].ti;
			CurrentSemanticValue.stn.source_context = CurrentLocationSpan;
        }
        break;
      case 513: // stmt_list -> stmt
{ 
			CurrentSemanticValue.stn = new statement_list(ValueStack[ValueStack.Depth-1].stn as statement, LocationStack[LocationStack.Depth-1]);
        }
        break;
      case 514: // stmt_list -> stmt_list, tkSemiColon, stmt
{  
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-3].stn as statement_list).Add(ValueStack[ValueStack.Depth-1].stn as statement, CurrentLocationSpan);
        }
        break;
      case 515: // if_stmt -> tkIf, expr_l1, tkThen, unlabelled_stmt
{ 
			CurrentSemanticValue.stn = new if_node(ValueStack[ValueStack.Depth-3].ex, ValueStack[ValueStack.Depth-1].stn as statement, null, CurrentLocationSpan); 
        }
        break;
      case 516: // if_stmt -> tkIf, expr_l1, tkThen, unlabelled_stmt, tkElse, unlabelled_stmt
{
			CurrentSemanticValue.stn = new if_node(ValueStack[ValueStack.Depth-5].ex, ValueStack[ValueStack.Depth-3].stn as statement, ValueStack[ValueStack.Depth-1].stn as statement, CurrentLocationSpan); 
        }
        break;
      case 517: // match_with -> tkMatch, expr_l1, tkWith, pattern_cases, else_case, tkEnd
{ 
            CurrentSemanticValue.stn = new match_with(ValueStack[ValueStack.Depth-5].ex, ValueStack[ValueStack.Depth-3].stn as pattern_cases, ValueStack[ValueStack.Depth-2].stn as statement, CurrentLocationSpan);
        }
        break;
      case 518: // match_with -> tkMatch, expr_l1, tkWith, pattern_cases, tkSemiColon, else_case, 
                //               tkEnd
{ 
            CurrentSemanticValue.stn = new match_with(ValueStack[ValueStack.Depth-6].ex, ValueStack[ValueStack.Depth-4].stn as pattern_cases, ValueStack[ValueStack.Depth-2].stn as statement, CurrentLocationSpan);
        }
        break;
      case 519: // pattern_cases -> pattern_case
{
            CurrentSemanticValue.stn = new pattern_cases(ValueStack[ValueStack.Depth-1].stn as pattern_case);
        }
        break;
      case 520: // pattern_cases -> pattern_cases, tkSemiColon, pattern_case
{
            CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-3].stn as pattern_cases).Add(ValueStack[ValueStack.Depth-1].stn as pattern_case);
        }
        break;
      case 521: // pattern_case -> pattern_optional_var, tkWhen, expr_l1, tkColon, unlabelled_stmt
{
            CurrentSemanticValue.stn = new pattern_case(ValueStack[ValueStack.Depth-5].stn as pattern_node, ValueStack[ValueStack.Depth-1].stn as statement, ValueStack[ValueStack.Depth-3].ex, CurrentLocationSpan);
        }
        break;
      case 522: // pattern_case -> pattern_optional_var, tkColon, unlabelled_stmt
{
            CurrentSemanticValue.stn = new pattern_case(ValueStack[ValueStack.Depth-3].stn as pattern_node, ValueStack[ValueStack.Depth-1].stn as statement, null, CurrentLocationSpan);
        }
        break;
      case 523: // pattern_case -> const_pattern, tkWhen, expr_l1, tkColon, unlabelled_stmt
{
			CurrentSemanticValue.stn = new pattern_case(ValueStack[ValueStack.Depth-5].stn as pattern_node, ValueStack[ValueStack.Depth-1].stn as statement, ValueStack[ValueStack.Depth-3].ex, CurrentLocationSpan);
		}
        break;
      case 524: // pattern_case -> const_pattern, tkColon, unlabelled_stmt
{
			CurrentSemanticValue.stn = new pattern_case(ValueStack[ValueStack.Depth-3].stn as pattern_node, ValueStack[ValueStack.Depth-1].stn as statement, null, CurrentLocationSpan);
		}
        break;
      case 525: // pattern_case -> collection_pattern, tkColon, unlabelled_stmt
{
			CurrentSemanticValue.stn = new pattern_case(ValueStack[ValueStack.Depth-3].stn as pattern_node, ValueStack[ValueStack.Depth-1].stn as statement, null, CurrentLocationSpan);
		}
        break;
      case 526: // pattern_case -> tuple_pattern, tkColon, unlabelled_stmt
{
			CurrentSemanticValue.stn = new pattern_case(ValueStack[ValueStack.Depth-3].stn as pattern_node, ValueStack[ValueStack.Depth-1].stn as statement, null, CurrentLocationSpan);
		}
        break;
      case 527: // case_stmt -> tkCase, expr_l1, tkOf, case_list, else_case, tkEnd
{ 
			CurrentSemanticValue.stn = new case_node(ValueStack[ValueStack.Depth-5].ex, ValueStack[ValueStack.Depth-3].stn as case_variants, ValueStack[ValueStack.Depth-2].stn as statement, CurrentLocationSpan); 
		}
        break;
      case 528: // case_stmt -> tkCase, expr_l1, tkOf, case_list, tkSemiColon, else_case, tkEnd
{ 
			CurrentSemanticValue.stn = new case_node(ValueStack[ValueStack.Depth-6].ex, ValueStack[ValueStack.Depth-4].stn as case_variants, ValueStack[ValueStack.Depth-2].stn as statement, CurrentLocationSpan); 
		}
        break;
      case 529: // case_stmt -> tkCase, expr_l1, tkOf, else_case, tkEnd
{ 
			CurrentSemanticValue.stn = new case_node(ValueStack[ValueStack.Depth-4].ex, NewCaseItem(new empty_statement(), null), ValueStack[ValueStack.Depth-2].stn as statement, CurrentLocationSpan); 
		}
        break;
      case 530: // case_list -> case_item
{
			if (ValueStack[ValueStack.Depth-1].stn is empty_statement) 
				CurrentSemanticValue.stn = NewCaseItem(ValueStack[ValueStack.Depth-1].stn, null);
			else CurrentSemanticValue.stn = NewCaseItem(ValueStack[ValueStack.Depth-1].stn, CurrentLocationSpan);
		}
        break;
      case 531: // case_list -> case_list, tkSemiColon, case_item
{ 
			CurrentSemanticValue.stn = AddCaseItem(ValueStack[ValueStack.Depth-3].stn as case_variants, ValueStack[ValueStack.Depth-1].stn, CurrentLocationSpan);
		}
        break;
      case 532: // case_item -> case_label_list, tkColon, unlabelled_stmt
{ 
			CurrentSemanticValue.stn = new case_variant(ValueStack[ValueStack.Depth-3].stn as expression_list, ValueStack[ValueStack.Depth-1].stn as statement, CurrentLocationSpan); 
		}
        break;
      case 533: // case_label_list -> case_label
{ 
			CurrentSemanticValue.stn = new expression_list(ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan);
		}
        break;
      case 534: // case_label_list -> case_label_list, tkComma, case_label
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-3].stn as expression_list).Add(ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan);
		}
        break;
      case 535: // case_label -> const_elem
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 536: // else_case -> /* empty */
{ CurrentSemanticValue.stn = null;}
        break;
      case 537: // else_case -> tkElse, stmt_list
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 538: // repeat_stmt -> tkRepeat, stmt_list, tkUntil, expr
{ 
		    CurrentSemanticValue.stn = new repeat_node(ValueStack[ValueStack.Depth-3].stn as statement_list, ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan); 
			(ValueStack[ValueStack.Depth-3].stn as statement_list).left_logical_bracket = ValueStack[ValueStack.Depth-4].ti;
			(ValueStack[ValueStack.Depth-3].stn as statement_list).right_logical_bracket = ValueStack[ValueStack.Depth-2].ti;
			ValueStack[ValueStack.Depth-3].stn.source_context = LocationStack[LocationStack.Depth-4].Merge(LocationStack[LocationStack.Depth-2]);
        }
        break;
      case 539: // while_stmt -> tkWhile, expr_l1, optional_tk_do, unlabelled_stmt
{ 
			CurrentSemanticValue.stn = NewWhileStmt(ValueStack[ValueStack.Depth-4].ti, ValueStack[ValueStack.Depth-3].ex, ValueStack[ValueStack.Depth-2].ti, ValueStack[ValueStack.Depth-1].stn as statement, CurrentLocationSpan);    
        }
        break;
      case 540: // optional_tk_do -> tkDo
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 541: // optional_tk_do -> /* empty */
{ CurrentSemanticValue.ti = null; }
        break;
      case 542: // lock_stmt -> tkLock, expr_l1, tkDo, unlabelled_stmt
{ 
			CurrentSemanticValue.stn = new lock_stmt(ValueStack[ValueStack.Depth-3].ex, ValueStack[ValueStack.Depth-1].stn as statement, CurrentLocationSpan); 
        }
        break;
      case 543: // foreach_stmt -> tkForeach, identifier, foreach_stmt_ident_dype_opt, tkIn, 
                //                 expr_l1, tkDo, unlabelled_stmt
{ 
			CurrentSemanticValue.stn = new foreach_stmt(ValueStack[ValueStack.Depth-6].id, ValueStack[ValueStack.Depth-5].td, ValueStack[ValueStack.Depth-3].ex, ValueStack[ValueStack.Depth-1].stn as statement, CurrentLocationSpan);
            if (ValueStack[ValueStack.Depth-5].td == null)
                parsertools.AddWarningFromResource("USING_UNLOCAL_FOREACH_VARIABLE", ValueStack[ValueStack.Depth-6].id.source_context);
        }
        break;
      case 544: // foreach_stmt -> tkForeach, tkVar, identifier, tkColon, type_ref, tkIn, expr_l1, 
                //                 tkDo, unlabelled_stmt
{ 
			CurrentSemanticValue.stn = new foreach_stmt(ValueStack[ValueStack.Depth-7].id, ValueStack[ValueStack.Depth-5].td, ValueStack[ValueStack.Depth-3].ex, ValueStack[ValueStack.Depth-1].stn as statement, CurrentLocationSpan); 
        }
        break;
      case 545: // foreach_stmt -> tkForeach, tkVar, identifier, tkIn, expr_l1, tkDo, 
                //                 unlabelled_stmt
{ 
			CurrentSemanticValue.stn = new foreach_stmt(ValueStack[ValueStack.Depth-5].id, new no_type_foreach(), ValueStack[ValueStack.Depth-3].ex, (statement)ValueStack[ValueStack.Depth-1].stn, CurrentLocationSpan); 
        }
        break;
      case 546: // foreach_stmt_ident_dype_opt -> tkColon, type_ref
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 548: // for_stmt -> tkFor, optional_var, identifier, for_stmt_decl_or_assign, expr_l1, 
                //             for_cycle_type, expr_l1, optional_tk_do, unlabelled_stmt
{ 
			CurrentSemanticValue.stn = NewForStmt((bool)ValueStack[ValueStack.Depth-8].ob, ValueStack[ValueStack.Depth-7].id, ValueStack[ValueStack.Depth-6].td, ValueStack[ValueStack.Depth-5].ex, (for_cycle_type)ValueStack[ValueStack.Depth-4].ob, ValueStack[ValueStack.Depth-3].ex, ValueStack[ValueStack.Depth-2].ti, ValueStack[ValueStack.Depth-1].stn as statement, CurrentLocationSpan);
        }
        break;
      case 549: // optional_var -> tkVar
{ CurrentSemanticValue.ob = true; }
        break;
      case 550: // optional_var -> /* empty */
{ CurrentSemanticValue.ob = false; }
        break;
      case 552: // for_stmt_decl_or_assign -> tkColon, simple_type_identifier, tkAssign
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-2].td; }
        break;
      case 553: // for_cycle_type -> tkTo
{ CurrentSemanticValue.ob = for_cycle_type.to; }
        break;
      case 554: // for_cycle_type -> tkDownto
{ CurrentSemanticValue.ob = for_cycle_type.downto; }
        break;
      case 555: // with_stmt -> tkWith, expr_list, tkDo, unlabelled_stmt
{ 
			CurrentSemanticValue.stn = new with_statement(ValueStack[ValueStack.Depth-1].stn as statement, ValueStack[ValueStack.Depth-3].stn as expression_list, CurrentLocationSpan); 
		}
        break;
      case 556: // inherited_message -> tkInherited
{ 
			CurrentSemanticValue.stn = new inherited_message();  
			CurrentSemanticValue.stn.source_context = CurrentLocationSpan;
		}
        break;
      case 557: // try_stmt -> tkTry, stmt_list, try_handler
{ 
			CurrentSemanticValue.stn = new try_stmt(ValueStack[ValueStack.Depth-2].stn as statement_list, ValueStack[ValueStack.Depth-1].stn as try_handler, CurrentLocationSpan); 
			(ValueStack[ValueStack.Depth-2].stn as statement_list).left_logical_bracket = ValueStack[ValueStack.Depth-3].ti;
			ValueStack[ValueStack.Depth-2].stn.source_context = LocationStack[LocationStack.Depth-3].Merge(LocationStack[LocationStack.Depth-2]);
        }
        break;
      case 558: // try_handler -> tkFinally, stmt_list, tkEnd
{ 
			CurrentSemanticValue.stn = new try_handler_finally(ValueStack[ValueStack.Depth-2].stn as statement_list, CurrentLocationSpan);
			(ValueStack[ValueStack.Depth-2].stn as statement_list).left_logical_bracket = ValueStack[ValueStack.Depth-3].ti;
			(ValueStack[ValueStack.Depth-2].stn as statement_list).right_logical_bracket = ValueStack[ValueStack.Depth-1].ti;
		}
        break;
      case 559: // try_handler -> tkExcept, exception_block, tkEnd
{ 
			CurrentSemanticValue.stn = new try_handler_except((exception_block)ValueStack[ValueStack.Depth-2].stn, CurrentLocationSpan);  
			if ((ValueStack[ValueStack.Depth-2].stn as exception_block).stmt_list != null)
			{
				(ValueStack[ValueStack.Depth-2].stn as exception_block).stmt_list.source_context = CurrentLocationSpan;
				(ValueStack[ValueStack.Depth-2].stn as exception_block).source_context = CurrentLocationSpan;
			}
		}
        break;
      case 560: // exception_block -> exception_handler_list, exception_block_else_branch
{ 
			CurrentSemanticValue.stn = new exception_block(null, (exception_handler_list)ValueStack[ValueStack.Depth-2].stn, (statement_list)ValueStack[ValueStack.Depth-1].stn, CurrentLocationSpan); 
		}
        break;
      case 561: // exception_block -> exception_handler_list, tkSemiColon, 
                //                    exception_block_else_branch
{ 
			CurrentSemanticValue.stn = new exception_block(null, (exception_handler_list)ValueStack[ValueStack.Depth-3].stn, (statement_list)ValueStack[ValueStack.Depth-1].stn, CurrentLocationSpan); 
		}
        break;
      case 562: // exception_block -> stmt_list
{ 
			CurrentSemanticValue.stn = new exception_block(ValueStack[ValueStack.Depth-1].stn as statement_list, null, null, LocationStack[LocationStack.Depth-1]);
		}
        break;
      case 563: // exception_handler_list -> exception_handler
{ 
			CurrentSemanticValue.stn = new exception_handler_list(ValueStack[ValueStack.Depth-1].stn as exception_handler, CurrentLocationSpan); 
		}
        break;
      case 564: // exception_handler_list -> exception_handler_list, tkSemiColon, 
                //                           exception_handler
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-3].stn as exception_handler_list).Add(ValueStack[ValueStack.Depth-1].stn as exception_handler, CurrentLocationSpan); 
		}
        break;
      case 565: // exception_block_else_branch -> /* empty */
{ CurrentSemanticValue.stn = null; }
        break;
      case 566: // exception_block_else_branch -> tkElse, stmt_list
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 567: // exception_handler -> tkOn, exception_identifier, tkDo, unlabelled_stmt
{ 
			CurrentSemanticValue.stn = new exception_handler((ValueStack[ValueStack.Depth-3].stn as exception_ident).variable, (ValueStack[ValueStack.Depth-3].stn as exception_ident).type_name, ValueStack[ValueStack.Depth-1].stn as statement, CurrentLocationSpan);
		}
        break;
      case 568: // exception_identifier -> exception_class_type_identifier
{ 
			CurrentSemanticValue.stn = new exception_ident(null, (named_type_reference)ValueStack[ValueStack.Depth-1].td, CurrentLocationSpan); 
		}
        break;
      case 569: // exception_identifier -> exception_variable, tkColon, 
                //                         exception_class_type_identifier
{ 
			CurrentSemanticValue.stn = new exception_ident(ValueStack[ValueStack.Depth-3].id, (named_type_reference)ValueStack[ValueStack.Depth-1].td, CurrentLocationSpan); 
		}
        break;
      case 570: // exception_class_type_identifier -> simple_type_identifier
{ CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td; }
        break;
      case 571: // exception_variable -> identifier
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 572: // raise_stmt -> tkRaise
{ 
			CurrentSemanticValue.stn = new raise_stmt(); 
			CurrentSemanticValue.stn.source_context = CurrentLocationSpan;
		}
        break;
      case 573: // raise_stmt -> tkRaise, expr
{ 
			CurrentSemanticValue.stn = new raise_stmt(ValueStack[ValueStack.Depth-1].ex, null, CurrentLocationSpan);  
		}
        break;
      case 574: // expr_list -> expr_with_func_decl_lambda
{ 
			CurrentSemanticValue.stn = new expression_list(ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan); 
		}
        break;
      case 575: // expr_list -> expr_list, tkComma, expr_with_func_decl_lambda
{
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-3].stn as expression_list).Add(ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan); 
		}
        break;
      case 576: // expr_as_stmt -> allowable_expr_as_stmt
{ 
			CurrentSemanticValue.stn = new expression_as_statement(ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan);  
		}
        break;
      case 577: // allowable_expr_as_stmt -> new_expr
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 578: // expr_with_func_decl_lambda -> expr
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 579: // expr_with_func_decl_lambda -> func_decl_lambda
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 580: // expr -> expr_l1
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 581: // expr -> format_expr
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 582: // expr_l1 -> expr_dq
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 583: // expr_l1 -> question_expr
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 584: // expr_l1_func_decl_lambda -> expr_l1
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 585: // expr_l1_func_decl_lambda -> func_decl_lambda
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 586: // expr_dq -> relop_expr
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 587: // expr_dq -> expr_dq, tkDoubleQuestion, relop_expr
{ CurrentSemanticValue.ex = new double_question_node(ValueStack[ValueStack.Depth-3].ex as expression, ValueStack[ValueStack.Depth-1].ex as expression, CurrentLocationSpan);}
        break;
      case 588: // sizeof_expr -> tkSizeOf, tkRoundOpen, simple_or_template_type_reference, 
                //                tkRoundClose
{ 
			CurrentSemanticValue.ex = new sizeof_operator((named_type_reference)ValueStack[ValueStack.Depth-2].td, null, CurrentLocationSpan);  
		}
        break;
      case 589: // typeof_expr -> tkTypeOf, tkRoundOpen, simple_or_template_type_reference, 
                //                tkRoundClose
{ 
			CurrentSemanticValue.ex = new typeof_operator((named_type_reference)ValueStack[ValueStack.Depth-2].td, CurrentLocationSpan);  
		}
        break;
      case 590: // typeof_expr -> tkTypeOf, tkRoundOpen, empty_template_type_reference, 
                //                tkRoundClose
{ 
			CurrentSemanticValue.ex = new typeof_operator((named_type_reference)ValueStack[ValueStack.Depth-2].td, CurrentLocationSpan);  
		}
        break;
      case 591: // question_expr -> expr_l1, tkQuestion, expr_l1, tkColon, expr_l1
{ 
            if (ValueStack[ValueStack.Depth-3].ex is nil_const && ValueStack[ValueStack.Depth-1].ex is nil_const)
            	parsertools.AddErrorFromResource("TWO_NILS_IN_QUESTION_EXPR",LocationStack[LocationStack.Depth-3]);
			CurrentSemanticValue.ex = new question_colon_expression(ValueStack[ValueStack.Depth-5].ex, ValueStack[ValueStack.Depth-3].ex, ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan);  
		}
        break;
      case 592: // empty_template_type_reference -> simple_type_identifier, 
                //                                  template_type_empty_params
{
            CurrentSemanticValue.td = new template_type_reference((named_type_reference)ValueStack[ValueStack.Depth-2].td, (template_param_list)ValueStack[ValueStack.Depth-1].stn, CurrentLocationSpan); 
        }
        break;
      case 593: // empty_template_type_reference -> simple_type_identifier, tkAmpersend, 
                //                                  template_type_empty_params
{
            CurrentSemanticValue.td = new template_type_reference((named_type_reference)ValueStack[ValueStack.Depth-3].td, (template_param_list)ValueStack[ValueStack.Depth-1].stn, CurrentLocationSpan);
        }
        break;
      case 594: // simple_or_template_type_reference -> simple_type_identifier
{ 
			CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td;
		}
        break;
      case 595: // simple_or_template_type_reference -> simple_type_identifier, 
                //                                      template_type_params
{ 
			CurrentSemanticValue.td = new template_type_reference((named_type_reference)ValueStack[ValueStack.Depth-2].td, (template_param_list)ValueStack[ValueStack.Depth-1].stn, CurrentLocationSpan); 
        }
        break;
      case 596: // simple_or_template_type_reference -> simple_type_identifier, tkAmpersend, 
                //                                      template_type_params
{ 
			CurrentSemanticValue.td = new template_type_reference((named_type_reference)ValueStack[ValueStack.Depth-3].td, (template_param_list)ValueStack[ValueStack.Depth-1].stn, CurrentLocationSpan); 
        }
        break;
      case 597: // optional_array_initializer -> tkRoundOpen, typed_const_list, tkRoundClose
{ 
			CurrentSemanticValue.stn = new array_const((expression_list)ValueStack[ValueStack.Depth-2].stn, CurrentLocationSpan); 
		}
        break;
      case 599: // new_expr -> tkNew, simple_or_template_type_reference, 
                //             optional_expr_list_with_bracket
{
			CurrentSemanticValue.ex = new new_expr(ValueStack[ValueStack.Depth-2].td, ValueStack[ValueStack.Depth-1].stn as expression_list, false, null, CurrentLocationSpan);
        }
        break;
      case 600: // new_expr -> tkNew, simple_or_template_type_reference, tkSquareOpen, 
                //             optional_expr_list, tkSquareClose, optional_array_initializer
{
        	var el = ValueStack[ValueStack.Depth-3].stn as expression_list;
        	if (el == null)
        	{
        		var cnt = 0;
        		var ac = ValueStack[ValueStack.Depth-1].stn as array_const;
        		if (ac != null && ac.elements != null)
	        	    cnt = ac.elements.Count;
	        	else parsertools.AddErrorFromResource("WITHOUT_INIT_AND_SIZE",LocationStack[LocationStack.Depth-2]);
        		el = new expression_list(new int32_const(cnt),LocationStack[LocationStack.Depth-6]);
        	}	
			CurrentSemanticValue.ex = new new_expr(ValueStack[ValueStack.Depth-5].td, el, true, ValueStack[ValueStack.Depth-1].stn as array_const, CurrentLocationSpan);
        }
        break;
      case 601: // new_expr -> tkNew, tkClass, tkRoundOpen, list_fields_in_unnamed_object, 
                //             tkRoundClose
{
        // sugared node	
        	var l = ValueStack[ValueStack.Depth-2].ob as name_assign_expr_list;
        	var exprs = l.name_expr.Select(x=>x.expr).ToList();
        	var typename = "AnonymousType#"+Guid();
        	var type = new named_type_reference(typename,LocationStack[LocationStack.Depth-5]);
        	
			// node new_expr - for code generation of new node
			var ne = new new_expr(type, new expression_list(exprs), CurrentLocationSpan);
			// node unnamed_type_object - for formatting and code generation (new node and Anonymous class)
			CurrentSemanticValue.ex = new unnamed_type_object(l, true, ne, CurrentLocationSpan);
        }
        break;
      case 602: // field_in_unnamed_object -> identifier, tkAssign, relop_expr
{
			CurrentSemanticValue.ob = new name_assign_expr(ValueStack[ValueStack.Depth-3].id,ValueStack[ValueStack.Depth-1].ex,CurrentLocationSpan);
		}
        break;
      case 603: // field_in_unnamed_object -> relop_expr
{
			ident name = null;
			var id = ValueStack[ValueStack.Depth-1].ex as ident;
			dot_node dot;
			if (id != null)
				name = id;
			else 
            {
            	dot = ValueStack[ValueStack.Depth-1].ex as dot_node;
            	if (dot != null)
            	{
            		name = dot.right as ident;
            	}            	
            } 
			if (name == null)
				parsertools.errors.Add(new bad_anon_type(parsertools.CurrentFileName, LocationStack[LocationStack.Depth-1], null));	
			CurrentSemanticValue.ob = new name_assign_expr(name,ValueStack[ValueStack.Depth-1].ex,CurrentLocationSpan);
		}
        break;
      case 604: // list_fields_in_unnamed_object -> field_in_unnamed_object
{
			var l = new name_assign_expr_list();
			CurrentSemanticValue.ob = l.Add(ValueStack[ValueStack.Depth-1].ob as name_assign_expr);
		}
        break;
      case 605: // list_fields_in_unnamed_object -> list_fields_in_unnamed_object, tkComma, 
                //                                  field_in_unnamed_object
{
			var nel = ValueStack[ValueStack.Depth-3].ob as name_assign_expr_list;
			var ss = nel.name_expr.Select(ne=>ne.name.name).FirstOrDefault(x=>string.Compare(x,(ValueStack[ValueStack.Depth-1].ob as name_assign_expr).name.name,true)==0);
            if (ss != null)
            	parsertools.errors.Add(new anon_type_duplicate_name(parsertools.CurrentFileName, LocationStack[LocationStack.Depth-1], null));
			nel.Add(ValueStack[ValueStack.Depth-1].ob as name_assign_expr);
			CurrentSemanticValue.ob = ValueStack[ValueStack.Depth-3].ob;
		}
        break;
      case 606: // optional_expr_list_with_bracket -> /* empty */
{ CurrentSemanticValue.stn = null; }
        break;
      case 607: // optional_expr_list_with_bracket -> tkRoundOpen, optional_expr_list, 
                //                                    tkRoundClose
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-2].stn; }
        break;
      case 608: // relop_expr -> simple_expr
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 609: // relop_expr -> relop_expr, relop, simple_expr
{ 
			CurrentSemanticValue.ex = new bin_expr(ValueStack[ValueStack.Depth-3].ex, ValueStack[ValueStack.Depth-1].ex, ValueStack[ValueStack.Depth-2].op.type, CurrentLocationSpan); 
		}
        break;
      case 610: // relop_expr -> is_type_expr, tkRoundOpen, pattern_out_param_list, tkRoundClose
{
            var isTypeCheck = ValueStack[ValueStack.Depth-4].ex as typecast_node;
            var deconstructorPattern = new deconstructor_pattern(ValueStack[ValueStack.Depth-2].ob as List<pattern_parameter>, isTypeCheck.type_def, null, CurrentLocationSpan); 
            CurrentSemanticValue.ex = new is_pattern_expr(isTypeCheck.expr, deconstructorPattern, CurrentLocationSpan);
        }
        break;
      case 611: // relop_expr -> term, tkIs, collection_pattern
{
            CurrentSemanticValue.ex = new is_pattern_expr(ValueStack[ValueStack.Depth-3].ex, ValueStack[ValueStack.Depth-1].stn as pattern_node, CurrentLocationSpan);
        }
        break;
      case 612: // relop_expr -> term, tkIs, tuple_pattern
{
            CurrentSemanticValue.ex = new is_pattern_expr(ValueStack[ValueStack.Depth-3].ex, ValueStack[ValueStack.Depth-1].stn as pattern_node, CurrentLocationSpan);
        }
        break;
      case 613: // pattern -> simple_or_template_type_reference, tkRoundOpen, 
                //            pattern_out_param_list, tkRoundClose
{ 
            CurrentSemanticValue.stn = new deconstructor_pattern(ValueStack[ValueStack.Depth-2].ob as List<pattern_parameter>, ValueStack[ValueStack.Depth-4].td, null, CurrentLocationSpan); 
        }
        break;
      case 614: // pattern_optional_var -> simple_or_template_type_reference, tkRoundOpen, 
                //                         pattern_out_param_list_optional_var, tkRoundClose
{ 
            CurrentSemanticValue.stn = new deconstructor_pattern(ValueStack[ValueStack.Depth-2].ob as List<pattern_parameter>, ValueStack[ValueStack.Depth-4].td, null, CurrentLocationSpan); 
        }
        break;
      case 615: // collection_pattern -> tkSquareOpen, collection_pattern_expr_list, tkSquareClose
{
			CurrentSemanticValue.stn = new collection_pattern(ValueStack[ValueStack.Depth-2].ob as List<pattern_parameter>, CurrentLocationSpan);
		}
        break;
      case 616: // collection_pattern_expr_list -> collection_pattern_list_item
{
			CurrentSemanticValue.ob = new List<pattern_parameter>();
            (CurrentSemanticValue.ob as List<pattern_parameter>).Add(ValueStack[ValueStack.Depth-1].stn as pattern_parameter);
		}
        break;
      case 617: // collection_pattern_expr_list -> collection_pattern_expr_list, tkComma, 
                //                                 collection_pattern_list_item
{
			var list = ValueStack[ValueStack.Depth-3].ob as List<pattern_parameter>;
            list.Add(ValueStack[ValueStack.Depth-1].stn as pattern_parameter);
            CurrentSemanticValue.ob = list;
		}
        break;
      case 618: // collection_pattern_list_item -> literal_or_number
{
			CurrentSemanticValue.stn = new const_pattern_parameter(ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan);
		}
        break;
      case 619: // collection_pattern_list_item -> collection_pattern_var_item
{
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn;
		}
        break;
      case 620: // collection_pattern_list_item -> tkUnderscore
{
			CurrentSemanticValue.stn = new collection_pattern_wild_card();
		}
        break;
      case 621: // collection_pattern_list_item -> pattern_optional_var
{
            CurrentSemanticValue.stn = new recursive_deconstructor_parameter(ValueStack[ValueStack.Depth-1].stn as pattern_node, CurrentLocationSpan);
        }
        break;
      case 622: // collection_pattern_list_item -> collection_pattern
{
			CurrentSemanticValue.stn = new recursive_collection_parameter(ValueStack[ValueStack.Depth-1].stn as pattern_node, CurrentLocationSpan);
		}
        break;
      case 623: // collection_pattern_list_item -> tuple_pattern
{
			CurrentSemanticValue.stn = new recursive_tuple_parameter(ValueStack[ValueStack.Depth-1].stn as pattern_node, CurrentLocationSpan);
		}
        break;
      case 624: // collection_pattern_list_item -> tkDotDot
{
			CurrentSemanticValue.stn = new collection_pattern_gap_parameter();
		}
        break;
      case 625: // collection_pattern_var_item -> tkVar, identifier
{
            CurrentSemanticValue.stn = new collection_pattern_var_parameter(ValueStack[ValueStack.Depth-1].id, null, CurrentLocationSpan);
        }
        break;
      case 626: // const_pattern -> const_pattern_expr_list
{
			CurrentSemanticValue.stn = new const_pattern(ValueStack[ValueStack.Depth-1].stn as expression_list, CurrentLocationSpan); 
		}
        break;
      case 627: // const_pattern_expr_list -> const_pattern_expression
{ 
			CurrentSemanticValue.stn = new expression_list(ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan); 
		}
        break;
      case 628: // const_pattern_expr_list -> const_pattern_expr_list, tkComma, 
                //                            const_pattern_expression
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-3].stn as expression_list).Add(ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan);
		}
        break;
      case 629: // const_pattern_expression -> literal_or_number
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 630: // tuple_pattern -> tkRoundOpen, tuple_pattern_item_list, tkRoundClose
{
			if ((ValueStack[ValueStack.Depth-2].ob as List<pattern_parameter>).Count>6) 
				parsertools.AddErrorFromResource("TUPLE_ELEMENTS_COUNT_MUST_BE_LESSEQUAL_7",CurrentLocationSpan);
			CurrentSemanticValue.stn = new tuple_pattern(ValueStack[ValueStack.Depth-2].ob as List<pattern_parameter>, CurrentLocationSpan);
		}
        break;
      case 631: // tuple_pattern_item -> tkUnderscore
{ 
			CurrentSemanticValue.stn = new tuple_pattern_wild_card(); 
		}
        break;
      case 632: // tuple_pattern_item -> literal_or_number
{ 
			CurrentSemanticValue.stn = new const_pattern_parameter(ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan);
		}
        break;
      case 633: // tuple_pattern_item -> tkVar, identifier
{
            CurrentSemanticValue.stn = new tuple_pattern_var_parameter(ValueStack[ValueStack.Depth-1].id, null, CurrentLocationSpan);
        }
        break;
      case 634: // tuple_pattern_item -> pattern_optional_var
{
            CurrentSemanticValue.stn = new recursive_deconstructor_parameter(ValueStack[ValueStack.Depth-1].stn as pattern_node, CurrentLocationSpan);
        }
        break;
      case 635: // tuple_pattern_item -> collection_pattern
{
			CurrentSemanticValue.stn = new recursive_collection_parameter(ValueStack[ValueStack.Depth-1].stn as pattern_node, CurrentLocationSpan);
		}
        break;
      case 636: // tuple_pattern_item -> tuple_pattern
{
			CurrentSemanticValue.stn = new recursive_tuple_parameter(ValueStack[ValueStack.Depth-1].stn as pattern_node, CurrentLocationSpan);
		}
        break;
      case 637: // tuple_pattern_item_list -> tuple_pattern_item
{ 
			CurrentSemanticValue.ob = new List<pattern_parameter>();
            (CurrentSemanticValue.ob as List<pattern_parameter>).Add(ValueStack[ValueStack.Depth-1].stn as pattern_parameter);
		}
        break;
      case 638: // tuple_pattern_item_list -> tuple_pattern_item_list, tkComma, tuple_pattern_item
{
			var list = ValueStack[ValueStack.Depth-3].ob as List<pattern_parameter>;
            list.Add(ValueStack[ValueStack.Depth-1].stn as pattern_parameter);
            CurrentSemanticValue.ob = list;
		}
        break;
      case 639: // pattern_out_param_list_optional_var -> pattern_out_param_optional_var
{
            CurrentSemanticValue.ob = new List<pattern_parameter>();
            (CurrentSemanticValue.ob as List<pattern_parameter>).Add(ValueStack[ValueStack.Depth-1].stn as pattern_parameter);
        }
        break;
      case 640: // pattern_out_param_list_optional_var -> pattern_out_param_list_optional_var, 
                //                                        tkSemiColon, 
                //                                        pattern_out_param_optional_var
{
            var list = ValueStack[ValueStack.Depth-3].ob as List<pattern_parameter>;
            list.Add(ValueStack[ValueStack.Depth-1].stn as pattern_parameter);
            CurrentSemanticValue.ob = list;
        }
        break;
      case 641: // pattern_out_param_list_optional_var -> pattern_out_param_list_optional_var, 
                //                                        tkComma, 
                //                                        pattern_out_param_optional_var
{
            var list = ValueStack[ValueStack.Depth-3].ob as List<pattern_parameter>;
            list.Add(ValueStack[ValueStack.Depth-1].stn as pattern_parameter);
            CurrentSemanticValue.ob = list;
        }
        break;
      case 642: // pattern_out_param_list -> pattern_out_param
{
            CurrentSemanticValue.ob = new List<pattern_parameter>();
            (CurrentSemanticValue.ob as List<pattern_parameter>).Add(ValueStack[ValueStack.Depth-1].stn as pattern_parameter);
        }
        break;
      case 643: // pattern_out_param_list -> pattern_out_param_list, tkSemiColon, 
                //                           pattern_out_param
{
            var list = ValueStack[ValueStack.Depth-3].ob as List<pattern_parameter>;
            list.Add(ValueStack[ValueStack.Depth-1].stn as pattern_parameter);
            CurrentSemanticValue.ob = list;
        }
        break;
      case 644: // pattern_out_param_list -> pattern_out_param_list, tkComma, pattern_out_param
{
            var list = ValueStack[ValueStack.Depth-3].ob as List<pattern_parameter>;
            list.Add(ValueStack[ValueStack.Depth-1].stn as pattern_parameter);
            CurrentSemanticValue.ob = list;
        }
        break;
      case 645: // pattern_out_param -> tkUnderscore
{
			CurrentSemanticValue.stn = new wild_card_deconstructor_parameter();
		}
        break;
      case 646: // pattern_out_param -> literal_or_number
{
			CurrentSemanticValue.stn = new const_pattern_parameter(ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan);
		}
        break;
      case 647: // pattern_out_param -> tkVar, identifier, tkColon, type_ref
{
            CurrentSemanticValue.stn = new var_deconstructor_parameter(ValueStack[ValueStack.Depth-3].id, ValueStack[ValueStack.Depth-1].td, true, CurrentLocationSpan);
        }
        break;
      case 648: // pattern_out_param -> tkVar, identifier
{
            CurrentSemanticValue.stn = new var_deconstructor_parameter(ValueStack[ValueStack.Depth-1].id, null, true, CurrentLocationSpan);
        }
        break;
      case 649: // pattern_out_param -> pattern
{
            CurrentSemanticValue.stn = new recursive_deconstructor_parameter(ValueStack[ValueStack.Depth-1].stn as pattern_node, CurrentLocationSpan);
        }
        break;
      case 650: // pattern_out_param -> collection_pattern
{
			CurrentSemanticValue.stn = new recursive_collection_parameter(ValueStack[ValueStack.Depth-1].stn as pattern_node, CurrentLocationSpan);
		}
        break;
      case 651: // pattern_out_param -> tuple_pattern
{
			CurrentSemanticValue.stn = new recursive_tuple_parameter(ValueStack[ValueStack.Depth-1].stn as pattern_node, CurrentLocationSpan);
		}
        break;
      case 652: // pattern_out_param_optional_var -> tkUnderscore
{
			CurrentSemanticValue.stn = new wild_card_deconstructor_parameter();
		}
        break;
      case 653: // pattern_out_param_optional_var -> literal_or_number
{
			CurrentSemanticValue.stn = new const_pattern_parameter(ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan);
		}
        break;
      case 654: // pattern_out_param_optional_var -> identifier, tkColon, type_ref
{
            CurrentSemanticValue.stn = new var_deconstructor_parameter(ValueStack[ValueStack.Depth-3].id, ValueStack[ValueStack.Depth-1].td, false, CurrentLocationSpan);
        }
        break;
      case 655: // pattern_out_param_optional_var -> identifier
{
            CurrentSemanticValue.stn = new var_deconstructor_parameter(ValueStack[ValueStack.Depth-1].id, null, false, CurrentLocationSpan);
        }
        break;
      case 656: // pattern_out_param_optional_var -> tkVar, identifier, tkColon, type_ref
{
            CurrentSemanticValue.stn = new var_deconstructor_parameter(ValueStack[ValueStack.Depth-3].id, ValueStack[ValueStack.Depth-1].td, true, CurrentLocationSpan);
        }
        break;
      case 657: // pattern_out_param_optional_var -> tkVar, identifier
{
            CurrentSemanticValue.stn = new var_deconstructor_parameter(ValueStack[ValueStack.Depth-1].id, null, true, CurrentLocationSpan);
        }
        break;
      case 658: // pattern_out_param_optional_var -> pattern_optional_var
{
            CurrentSemanticValue.stn = new recursive_deconstructor_parameter(ValueStack[ValueStack.Depth-1].stn as pattern_node, CurrentLocationSpan);
        }
        break;
      case 659: // pattern_out_param_optional_var -> collection_pattern
{
			CurrentSemanticValue.stn = new recursive_collection_parameter(ValueStack[ValueStack.Depth-1].stn as pattern_node, CurrentLocationSpan);
		}
        break;
      case 660: // pattern_out_param_optional_var -> tuple_pattern
{
			CurrentSemanticValue.stn = new recursive_tuple_parameter(ValueStack[ValueStack.Depth-1].stn as pattern_node, CurrentLocationSpan);
		}
        break;
      case 661: // simple_expr_or_nothing -> simple_expr
{
		CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex;
	}
        break;
      case 662: // simple_expr_or_nothing -> /* empty */
{
		CurrentSemanticValue.ex = null;
	}
        break;
      case 663: // const_expr_or_nothing -> const_expr
{
		CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex;
	}
        break;
      case 664: // const_expr_or_nothing -> /* empty */
{
		CurrentSemanticValue.ex = null;
	}
        break;
      case 665: // format_expr -> simple_expr, tkColon, simple_expr_or_nothing
{ 
			CurrentSemanticValue.ex = new format_expr(ValueStack[ValueStack.Depth-3].ex, ValueStack[ValueStack.Depth-1].ex, null, CurrentLocationSpan); 
		}
        break;
      case 666: // format_expr -> tkColon, simple_expr_or_nothing
{ 
			CurrentSemanticValue.ex = new format_expr(null, ValueStack[ValueStack.Depth-1].ex, null, CurrentLocationSpan); 
		}
        break;
      case 667: // format_expr -> simple_expr, tkColon, simple_expr_or_nothing, tkColon, 
                //                simple_expr
{ 
			CurrentSemanticValue.ex = new format_expr(ValueStack[ValueStack.Depth-5].ex, ValueStack[ValueStack.Depth-3].ex, ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan); 
		}
        break;
      case 668: // format_expr -> tkColon, simple_expr_or_nothing, tkColon, simple_expr
{ 
			CurrentSemanticValue.ex = new format_expr(null, ValueStack[ValueStack.Depth-3].ex, ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan); 
		}
        break;
      case 669: // format_const_expr -> const_expr, tkColon, const_expr_or_nothing
{ 
			CurrentSemanticValue.ex = new format_expr(ValueStack[ValueStack.Depth-3].ex, ValueStack[ValueStack.Depth-1].ex, null, CurrentLocationSpan); 
		}
        break;
      case 670: // format_const_expr -> tkColon, const_expr_or_nothing
{ 
			CurrentSemanticValue.ex = new format_expr(null, ValueStack[ValueStack.Depth-1].ex, null, CurrentLocationSpan); 
		}
        break;
      case 671: // format_const_expr -> const_expr, tkColon, const_expr_or_nothing, tkColon, 
                //                      const_expr
{ 
			CurrentSemanticValue.ex = new format_expr(ValueStack[ValueStack.Depth-5].ex, ValueStack[ValueStack.Depth-3].ex, ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan); 
		}
        break;
      case 672: // format_const_expr -> tkColon, const_expr_or_nothing, tkColon, const_expr
{ 
			CurrentSemanticValue.ex = new format_expr(null, ValueStack[ValueStack.Depth-3].ex, ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan); 
		}
        break;
      case 673: // relop -> tkEqual
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 674: // relop -> tkNotEqual
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 675: // relop -> tkLower
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 676: // relop -> tkGreater
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 677: // relop -> tkLowerEqual
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 678: // relop -> tkGreaterEqual
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 679: // relop -> tkIn
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 680: // simple_expr -> term
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 681: // simple_expr -> simple_expr, addop, term
{ 
			CurrentSemanticValue.ex = new bin_expr(ValueStack[ValueStack.Depth-3].ex, ValueStack[ValueStack.Depth-1].ex, ValueStack[ValueStack.Depth-2].op.type, CurrentLocationSpan); 
		}
        break;
      case 682: // addop -> tkPlus
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 683: // addop -> tkMinus
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 684: // addop -> tkOr
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 685: // addop -> tkXor
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 686: // addop -> tkCSharpStyleOr
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 687: // typecast_op -> tkAs
{ 
			CurrentSemanticValue.ob = op_typecast.as_op; 
		}
        break;
      case 688: // typecast_op -> tkIs
{ 
			CurrentSemanticValue.ob = op_typecast.is_op; 
		}
        break;
      case 689: // as_is_expr -> is_type_expr
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 690: // as_is_expr -> as_expr
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 691: // as_expr -> term, tkAs, simple_or_template_type_reference
{
            CurrentSemanticValue.ex = NewAsIsExpr(ValueStack[ValueStack.Depth-3].ex, op_typecast.as_op, ValueStack[ValueStack.Depth-1].td, CurrentLocationSpan);
        }
        break;
      case 692: // is_type_expr -> term, tkIs, simple_or_template_type_reference
{
            CurrentSemanticValue.ex = NewAsIsExpr(ValueStack[ValueStack.Depth-3].ex, op_typecast.is_op, ValueStack[ValueStack.Depth-1].td, CurrentLocationSpan);
        }
        break;
      case 693: // simple_term -> factor
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 694: // power_expr -> simple_term, tkStarStar, factor
{ CurrentSemanticValue.ex = new bin_expr(ValueStack[ValueStack.Depth-3].ex,ValueStack[ValueStack.Depth-1].ex,(ValueStack[ValueStack.Depth-2].op).type, CurrentLocationSpan); }
        break;
      case 695: // term -> factor
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 696: // term -> new_expr
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 697: // term -> power_expr
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 698: // term -> term, mulop, factor
{ CurrentSemanticValue.ex = new bin_expr(ValueStack[ValueStack.Depth-3].ex,ValueStack[ValueStack.Depth-1].ex,(ValueStack[ValueStack.Depth-2].op).type, CurrentLocationSpan); }
        break;
      case 699: // term -> term, mulop, power_expr
{ CurrentSemanticValue.ex = new bin_expr(ValueStack[ValueStack.Depth-3].ex,ValueStack[ValueStack.Depth-1].ex,(ValueStack[ValueStack.Depth-2].op).type, CurrentLocationSpan); }
        break;
      case 700: // term -> as_is_expr
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 701: // mulop -> tkStar
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 702: // mulop -> tkSlash
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 703: // mulop -> tkDiv
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 704: // mulop -> tkMod
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 705: // mulop -> tkShl
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 706: // mulop -> tkShr
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 707: // mulop -> tkAnd
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 708: // default_expr -> tkDefault, tkRoundOpen, simple_or_template_type_reference, 
                //                 tkRoundClose
{ 
			CurrentSemanticValue.ex = new default_operator(ValueStack[ValueStack.Depth-2].td as named_type_reference, CurrentLocationSpan);  
		}
        break;
      case 709: // tuple -> tkRoundOpen, expr_l1, tkComma, expr_l1_list, lambda_type_ref, 
                //          optional_full_lambda_fp_list, tkRoundClose
{
			/*if ($5 != null) 
				parsertools.AddErrorFromResource("BAD_TUPLE",@5);
			if ($6 != null) 
				parsertools.AddErrorFromResource("BAD_TUPLE",@6);*/

			if ((ValueStack[ValueStack.Depth-4].stn as expression_list).Count>6) 
				parsertools.AddErrorFromResource("TUPLE_ELEMENTS_COUNT_MUST_BE_LESSEQUAL_7",CurrentLocationSpan);
            (ValueStack[ValueStack.Depth-4].stn as expression_list).Insert(0,ValueStack[ValueStack.Depth-6].ex);
			CurrentSemanticValue.ex = new tuple_node(ValueStack[ValueStack.Depth-4].stn as expression_list,CurrentLocationSpan);
		}
        break;
      case 710: // factor -> tkNil
{ 
			CurrentSemanticValue.ex = new nil_const();  
			CurrentSemanticValue.ex.source_context = CurrentLocationSpan;
		}
        break;
      case 711: // factor -> literal_or_number
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 712: // factor -> default_expr
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 713: // factor -> tkSquareOpen, elem_list, tkSquareClose
{ 
			CurrentSemanticValue.ex = new pascal_set_constant(ValueStack[ValueStack.Depth-2].stn as expression_list, CurrentLocationSpan);  
		}
        break;
      case 714: // factor -> tkNot, factor
{ 
			CurrentSemanticValue.ex = new un_expr(ValueStack[ValueStack.Depth-1].ex, ValueStack[ValueStack.Depth-2].op.type, CurrentLocationSpan); 
		}
        break;
      case 715: // factor -> sign, factor
{
			if (ValueStack[ValueStack.Depth-2].op.type == Operators.Minus)
			{
			    var i64 = ValueStack[ValueStack.Depth-1].ex as int64_const;
				if (i64 != null && i64.val == (Int64)Int32.MaxValue + 1)
				{
					CurrentSemanticValue.ex = new int32_const(Int32.MinValue,CurrentLocationSpan);
					break;
				}
				var ui64 = ValueStack[ValueStack.Depth-1].ex as uint64_const;
				if (ui64 != null && ui64.val == (UInt64)Int64.MaxValue + 1)
				{
					CurrentSemanticValue.ex = new int64_const(Int64.MinValue,CurrentLocationSpan);
					break;
				}
				if (ui64 != null && ui64.val > (UInt64)Int64.MaxValue + 1)
				{
					parsertools.AddErrorFromResource("BAD_INT2",CurrentLocationSpan);
					break;
				}
			    // ����� ������� ���������� ��������� � �������������� �������
			}
		
			CurrentSemanticValue.ex = new un_expr(ValueStack[ValueStack.Depth-1].ex, ValueStack[ValueStack.Depth-2].op.type, CurrentLocationSpan); 
		}
        break;
      case 716: // factor -> var_reference
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 717: // factor -> tuple
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 718: // literal_or_number -> literal
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 719: // literal_or_number -> unsigned_number
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 720: // var_question_point -> variable, tkQuestionPoint, variable
{
		CurrentSemanticValue.ex = new dot_question_node(ValueStack[ValueStack.Depth-3].ex as addressed_value,ValueStack[ValueStack.Depth-1].ex as addressed_value,CurrentLocationSpan);
	}
        break;
      case 721: // var_question_point -> variable, tkQuestionPoint, var_question_point
{
		CurrentSemanticValue.ex = new dot_question_node(ValueStack[ValueStack.Depth-3].ex as addressed_value,ValueStack[ValueStack.Depth-1].ex as addressed_value,CurrentLocationSpan);
	}
        break;
      case 722: // var_reference -> var_address, variable
{
			CurrentSemanticValue.ex = NewVarReference(ValueStack[ValueStack.Depth-2].stn as get_address, ValueStack[ValueStack.Depth-1].ex as addressed_value, CurrentLocationSpan);
		}
        break;
      case 723: // var_reference -> variable
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 724: // var_reference -> var_question_point
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 725: // var_address -> tkAddressOf
{ 
			CurrentSemanticValue.stn = NewVarAddress(CurrentLocationSpan);
		}
        break;
      case 726: // var_address -> var_address, tkAddressOf
{ 
			CurrentSemanticValue.stn = NewVarAddress(ValueStack[ValueStack.Depth-2].stn as get_address, CurrentLocationSpan);
		}
        break;
      case 727: // attribute_variable -> simple_type_identifier, optional_expr_list_with_bracket
{ 
			CurrentSemanticValue.stn = new attribute(null, ValueStack[ValueStack.Depth-2].td as named_type_reference, ValueStack[ValueStack.Depth-1].stn as expression_list, CurrentLocationSpan);
		}
        break;
      case 728: // attribute_variable -> template_type, optional_expr_list_with_bracket
{
            CurrentSemanticValue.stn = new attribute(null, ValueStack[ValueStack.Depth-2].td as named_type_reference, ValueStack[ValueStack.Depth-1].stn as expression_list, CurrentLocationSpan);
        }
        break;
      case 729: // dotted_identifier -> identifier
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 730: // dotted_identifier -> dotted_identifier, tkPoint, identifier_or_keyword
{
			CurrentSemanticValue.ex = new dot_node(ValueStack[ValueStack.Depth-3].ex as addressed_value, ValueStack[ValueStack.Depth-1].id as addressed_value, CurrentLocationSpan);
		}
        break;
      case 731: // variable_as_type -> dotted_identifier
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex;}
        break;
      case 732: // variable_as_type -> dotted_identifier, template_type_params
{ CurrentSemanticValue.ex = new ident_with_templateparams(ValueStack[ValueStack.Depth-2].ex as addressed_value, ValueStack[ValueStack.Depth-1].stn as template_param_list, CurrentLocationSpan);   }
        break;
      case 733: // variable_or_literal_or_number -> variable
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 734: // variable_or_literal_or_number -> literal_or_number
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 735: // variable -> identifier
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 736: // variable -> operator_name_ident
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 737: // variable -> tkInherited, identifier
{ 
			CurrentSemanticValue.ex = new inherited_ident(ValueStack[ValueStack.Depth-1].id.name, CurrentLocationSpan);
		}
        break;
      case 738: // variable -> tkRoundOpen, expr, tkRoundClose
{
		    if (!parsertools.build_tree_for_formatter) 
            {
                ValueStack[ValueStack.Depth-2].ex.source_context = CurrentLocationSpan;
                CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-2].ex;
            } 
			else CurrentSemanticValue.ex = new bracket_expr(ValueStack[ValueStack.Depth-2].ex, CurrentLocationSpan);
        }
        break;
      case 739: // variable -> sizeof_expr
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 740: // variable -> typeof_expr
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 741: // variable -> literal_or_number, tkPoint, identifier_or_keyword
{ 
			CurrentSemanticValue.ex = new dot_node(ValueStack[ValueStack.Depth-3].ex as addressed_value, ValueStack[ValueStack.Depth-1].id as addressed_value, CurrentLocationSpan); 
		}
        break;
      case 742: // variable -> variable_or_literal_or_number, tkSquareOpen, expr_list, 
                //             tkSquareClose
{
        	var el = ValueStack[ValueStack.Depth-2].stn as expression_list; // SSM 10/03/16
        	if (el.Count==1 && el.expressions[0] is format_expr) 
        	{
        		var fe = el.expressions[0] as format_expr;
                if (!parsertools.build_tree_for_formatter)
                {
                    if (fe.expr == null)
                        fe.expr = new int32_const(int.MaxValue,LocationStack[LocationStack.Depth-2]);
                    if (fe.format1 == null)
                        fe.format1 = new int32_const(int.MaxValue,LocationStack[LocationStack.Depth-2]);
                }
        		CurrentSemanticValue.ex = new slice_expr(ValueStack[ValueStack.Depth-4].ex as addressed_value,fe.expr,fe.format1,fe.format2,CurrentLocationSpan);
			}   
			else CurrentSemanticValue.ex = new indexer(ValueStack[ValueStack.Depth-4].ex as addressed_value,el, CurrentLocationSpan);
        }
        break;
      case 743: // variable -> variable, tkQuestionSquareOpen, format_expr, tkSquareClose
{
        	var fe = ValueStack[ValueStack.Depth-2].ex as format_expr; // SSM 9/01/17
            if (!parsertools.build_tree_for_formatter)
            {
                if (fe.expr == null)
                    fe.expr = new int32_const(int.MaxValue,LocationStack[LocationStack.Depth-2]);
                if (fe.format1 == null)
                    fe.format1 = new int32_const(int.MaxValue,LocationStack[LocationStack.Depth-2]);
            }
      		CurrentSemanticValue.ex = new slice_expr_question(ValueStack[ValueStack.Depth-4].ex as addressed_value,fe.expr,fe.format1,fe.format2,CurrentLocationSpan);
        }
        break;
      case 744: // variable -> variable, tkRoundOpen, optional_expr_list, tkRoundClose
{
			CurrentSemanticValue.ex = new method_call(ValueStack[ValueStack.Depth-4].ex as addressed_value,ValueStack[ValueStack.Depth-2].stn as expression_list, CurrentLocationSpan);
        }
        break;
      case 745: // variable -> variable, tkPoint, identifier_keyword_operatorname
{
			CurrentSemanticValue.ex = new dot_node(ValueStack[ValueStack.Depth-3].ex as addressed_value, ValueStack[ValueStack.Depth-1].id as addressed_value, CurrentLocationSpan);
        }
        break;
      case 746: // variable -> tuple, tkPoint, identifier_keyword_operatorname
{
			CurrentSemanticValue.ex = new dot_node(ValueStack[ValueStack.Depth-3].ex as addressed_value, ValueStack[ValueStack.Depth-1].id as addressed_value, CurrentLocationSpan);
        }
        break;
      case 747: // variable -> variable, tkDeref
{
			CurrentSemanticValue.ex = new roof_dereference(ValueStack[ValueStack.Depth-2].ex as addressed_value,CurrentLocationSpan);
        }
        break;
      case 748: // variable -> variable, tkAmpersend, template_type_params
{
			CurrentSemanticValue.ex = new ident_with_templateparams(ValueStack[ValueStack.Depth-3].ex as addressed_value, ValueStack[ValueStack.Depth-1].stn as template_param_list, CurrentLocationSpan);
        }
        break;
      case 749: // optional_expr_list -> expr_list
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 750: // optional_expr_list -> /* empty */
{ CurrentSemanticValue.stn = null; }
        break;
      case 751: // elem_list -> elem_list1
{ CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; }
        break;
      case 752: // elem_list -> /* empty */
{ CurrentSemanticValue.stn = null; }
        break;
      case 753: // elem_list1 -> elem
{ 
			CurrentSemanticValue.stn = new expression_list(ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan); 
		}
        break;
      case 754: // elem_list1 -> elem_list1, tkComma, elem
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-3].stn as expression_list).Add(ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan);
		}
        break;
      case 755: // elem -> expr
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 756: // elem -> expr, tkDotDot, expr
{ CurrentSemanticValue.ex = new diapason_expr(ValueStack[ValueStack.Depth-3].ex, ValueStack[ValueStack.Depth-1].ex, CurrentLocationSpan); }
        break;
      case 757: // one_literal -> tkStringLiteral
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].stn as literal; }
        break;
      case 758: // one_literal -> tkAsciiChar
{ CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].stn as literal; }
        break;
      case 759: // literal -> literal_list
{ 
			CurrentSemanticValue.ex = NewLiteral(ValueStack[ValueStack.Depth-1].stn as literal_const_line);
        }
        break;
      case 760: // literal -> tkFormatStringLiteral
{
            if (parsertools.build_tree_for_formatter)
   			{
                CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].stn as string_const;
            }
            else
            {
                CurrentSemanticValue.ex = NewFormatString(ValueStack[ValueStack.Depth-1].stn as string_const);
            }
        }
        break;
      case 761: // literal_list -> one_literal
{ 
			CurrentSemanticValue.stn = new literal_const_line(ValueStack[ValueStack.Depth-1].ex as literal, CurrentLocationSpan);
        }
        break;
      case 762: // literal_list -> literal_list, one_literal
{ 
        	var line = ValueStack[ValueStack.Depth-2].stn as literal_const_line;
            if (line.literals.Last() is string_const && ValueStack[ValueStack.Depth-1].ex is string_const)
            	parsertools.AddErrorFromResource("TWO_STRING_LITERALS_IN_SUCCESSION",LocationStack[LocationStack.Depth-1]);
			CurrentSemanticValue.stn = line.Add(ValueStack[ValueStack.Depth-1].ex as literal, CurrentLocationSpan);
        }
        break;
      case 763: // operator_name_ident -> tkOperator, overload_operator
{ 
			CurrentSemanticValue.ex = new operator_name_ident((ValueStack[ValueStack.Depth-1].op as op_type_node).text, (ValueStack[ValueStack.Depth-1].op as op_type_node).type, CurrentLocationSpan);
		}
        break;
      case 764: // optional_method_modificators -> tkSemiColon
{ 
			CurrentSemanticValue.stn = new procedure_attributes_list(new List<procedure_attribute>(),CurrentLocationSpan); 
		}
        break;
      case 765: // optional_method_modificators -> tkSemiColon, meth_modificators, tkSemiColon
{ 
			//parsertools.AddModifier((procedure_attributes_list)$2, proc_attribute.attr_overload); 
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-2].stn; 
		}
        break;
      case 766: // optional_method_modificators1 -> /* empty */
{ 
			CurrentSemanticValue.stn = new procedure_attributes_list(new List<procedure_attribute>(),CurrentLocationSpan); 
		}
        break;
      case 767: // optional_method_modificators1 -> tkSemiColon, meth_modificators
{ 
			//parsertools.AddModifier((procedure_attributes_list)$2, proc_attribute.attr_overload); 
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; 
		}
        break;
      case 768: // meth_modificators -> meth_modificator
{ 
			CurrentSemanticValue.stn = new procedure_attributes_list(ValueStack[ValueStack.Depth-1].id as procedure_attribute, CurrentLocationSpan); 
		}
        break;
      case 769: // meth_modificators -> meth_modificators, tkSemiColon, meth_modificator
{ 
			CurrentSemanticValue.stn = (ValueStack[ValueStack.Depth-3].stn as procedure_attributes_list).Add(ValueStack[ValueStack.Depth-1].id as procedure_attribute, CurrentLocationSpan);  
		}
        break;
      case 770: // identifier -> tkIdentifier
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 771: // identifier -> property_specifier_directives
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 772: // identifier -> non_reserved
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 773: // identifier_or_keyword -> identifier
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 774: // identifier_or_keyword -> keyword
{ CurrentSemanticValue.id = new ident(ValueStack[ValueStack.Depth-1].ti.text, CurrentLocationSpan); }
        break;
      case 775: // identifier_or_keyword -> reserved_keyword
{ CurrentSemanticValue.id = new ident(ValueStack[ValueStack.Depth-1].ti.text, CurrentLocationSpan); }
        break;
      case 776: // identifier_keyword_operatorname -> identifier
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 777: // identifier_keyword_operatorname -> keyword
{ CurrentSemanticValue.id = new ident(ValueStack[ValueStack.Depth-1].ti.text, CurrentLocationSpan); }
        break;
      case 778: // identifier_keyword_operatorname -> operator_name_ident
{ CurrentSemanticValue.id = (ident)ValueStack[ValueStack.Depth-1].ex; }
        break;
      case 779: // meth_modificator -> tkAbstract
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 780: // meth_modificator -> tkOverload
{ 
            CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id;
            parsertools.AddWarningFromResource("OVERLOAD_IS_NOT_USED", ValueStack[ValueStack.Depth-1].id.source_context);
        }
        break;
      case 781: // meth_modificator -> tkReintroduce
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 782: // meth_modificator -> tkOverride
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 783: // meth_modificator -> tkExtensionMethod
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 784: // meth_modificator -> tkVirtual
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 785: // property_modificator -> tkVirtual
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 786: // property_modificator -> tkOverride
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 787: // property_modificator -> tkAbstract
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 788: // property_specifier_directives -> tkRead
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 789: // property_specifier_directives -> tkWrite
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 790: // non_reserved -> tkName
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 791: // non_reserved -> tkNew
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 792: // visibility_specifier -> tkInternal
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 793: // visibility_specifier -> tkPublic
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 794: // visibility_specifier -> tkProtected
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 795: // visibility_specifier -> tkPrivate
{ CurrentSemanticValue.id = ValueStack[ValueStack.Depth-1].id; }
        break;
      case 796: // keyword -> visibility_specifier
{ 
			CurrentSemanticValue.ti = new token_info(ValueStack[ValueStack.Depth-1].id.name, CurrentLocationSpan);  
		}
        break;
      case 797: // keyword -> tkSealed
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 798: // keyword -> tkTemplate
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 799: // keyword -> tkOr
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 800: // keyword -> tkTypeOf
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 801: // keyword -> tkSizeOf
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 802: // keyword -> tkDefault
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 803: // keyword -> tkWhere
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 804: // keyword -> tkXor
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 805: // keyword -> tkAnd
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 806: // keyword -> tkDiv
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 807: // keyword -> tkMod
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 808: // keyword -> tkShl
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 809: // keyword -> tkShr
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 810: // keyword -> tkNot
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 811: // keyword -> tkAs
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 812: // keyword -> tkIn
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 813: // keyword -> tkIs
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 814: // keyword -> tkArray
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 815: // keyword -> tkSequence
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 816: // keyword -> tkBegin
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 817: // keyword -> tkCase
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 818: // keyword -> tkClass
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 819: // keyword -> tkConst
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 820: // keyword -> tkConstructor
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 821: // keyword -> tkDestructor
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 822: // keyword -> tkDownto
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 823: // keyword -> tkDo
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 824: // keyword -> tkElse
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 825: // keyword -> tkExcept
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 826: // keyword -> tkFile
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 827: // keyword -> tkAuto
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 828: // keyword -> tkFinalization
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 829: // keyword -> tkFinally
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 830: // keyword -> tkFor
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 831: // keyword -> tkForeach
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 832: // keyword -> tkFunction
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 833: // keyword -> tkIf
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 834: // keyword -> tkImplementation
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 835: // keyword -> tkInherited
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 836: // keyword -> tkInitialization
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 837: // keyword -> tkInterface
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 838: // keyword -> tkProcedure
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 839: // keyword -> tkProperty
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 840: // keyword -> tkRaise
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 841: // keyword -> tkRecord
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 842: // keyword -> tkRepeat
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 843: // keyword -> tkSet
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 844: // keyword -> tkTry
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 845: // keyword -> tkType
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 846: // keyword -> tkStatic
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 847: // keyword -> tkThen
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 848: // keyword -> tkTo
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 849: // keyword -> tkUntil
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 850: // keyword -> tkUses
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 851: // keyword -> tkVar
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 852: // keyword -> tkWhile
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 853: // keyword -> tkWith
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 854: // keyword -> tkNil
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 855: // keyword -> tkGoto
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 856: // keyword -> tkOf
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 857: // keyword -> tkLabel
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 858: // keyword -> tkProgram
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 859: // keyword -> tkUnit
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 860: // keyword -> tkLibrary
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 861: // keyword -> tkNamespace
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 862: // keyword -> tkExternal
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 863: // keyword -> tkParams
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 864: // keyword -> tkEvent
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 865: // keyword -> tkYield
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 866: // keyword -> tkMatch
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 867: // keyword -> tkWhen
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 868: // reserved_keyword -> tkOperator
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 869: // reserved_keyword -> tkEnd
{ CurrentSemanticValue.ti = ValueStack[ValueStack.Depth-1].ti; }
        break;
      case 870: // overload_operator -> tkMinus
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 871: // overload_operator -> tkPlus
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 872: // overload_operator -> tkSlash
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 873: // overload_operator -> tkStar
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 874: // overload_operator -> tkEqual
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 875: // overload_operator -> tkGreater
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 876: // overload_operator -> tkGreaterEqual
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 877: // overload_operator -> tkLower
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 878: // overload_operator -> tkLowerEqual
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 879: // overload_operator -> tkNotEqual
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 880: // overload_operator -> tkOr
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 881: // overload_operator -> tkXor
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 882: // overload_operator -> tkAnd
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 883: // overload_operator -> tkDiv
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 884: // overload_operator -> tkMod
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 885: // overload_operator -> tkShl
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 886: // overload_operator -> tkShr
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 887: // overload_operator -> tkNot
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 888: // overload_operator -> tkIn
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 889: // overload_operator -> tkImplicit
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 890: // overload_operator -> tkExplicit
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 891: // overload_operator -> assign_operator
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 892: // overload_operator -> tkStarStar
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 893: // assign_operator -> tkAssign
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 894: // assign_operator -> tkPlusEqual
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 895: // assign_operator -> tkMinusEqual
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 896: // assign_operator -> tkMultEqual
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 897: // assign_operator -> tkDivEqual
{ CurrentSemanticValue.op = ValueStack[ValueStack.Depth-1].op; }
        break;
      case 898: // func_decl_lambda -> identifier, tkArrow, lambda_function_body
{
			var idList = new ident_list(ValueStack[ValueStack.Depth-3].id, LocationStack[LocationStack.Depth-3]); 
			var formalPars = new formal_parameters(new typed_parameters(idList, new lambda_inferred_type(new PascalABCCompiler.TreeRealization.lambda_any_type_node(), LocationStack[LocationStack.Depth-3]), parametr_kind.none, null, LocationStack[LocationStack.Depth-3]), LocationStack[LocationStack.Depth-3]);
			CurrentSemanticValue.ex = new function_lambda_definition(lambdaHelper.CreateLambdaName(), formalPars, new lambda_inferred_type(new PascalABCCompiler.TreeRealization.lambda_any_type_node(), LocationStack[LocationStack.Depth-3]), ValueStack[ValueStack.Depth-1].stn as statement_list, CurrentLocationSpan);
		}
        break;
      case 899: // func_decl_lambda -> tkRoundOpen, tkRoundClose, lambda_type_ref_noproctype, 
                //                     tkArrow, lambda_function_body
{
			CurrentSemanticValue.ex = new function_lambda_definition(lambdaHelper.CreateLambdaName(), null, ValueStack[ValueStack.Depth-3].td, ValueStack[ValueStack.Depth-1].stn as statement_list, CurrentLocationSpan);
		}
        break;
      case 900: // func_decl_lambda -> tkRoundOpen, identifier, tkColon, fptype, tkRoundClose, 
                //                     lambda_type_ref_noproctype, tkArrow, lambda_function_body
{
			var idList = new ident_list(ValueStack[ValueStack.Depth-7].id, LocationStack[LocationStack.Depth-7]); 
            var loc = LexLocation.MergeAll(LocationStack[LocationStack.Depth-7],LocationStack[LocationStack.Depth-6],LocationStack[LocationStack.Depth-5]);
			var formalPars = new formal_parameters(new typed_parameters(idList, ValueStack[ValueStack.Depth-5].td, parametr_kind.none, null, loc), loc);
			CurrentSemanticValue.ex = new function_lambda_definition(lambdaHelper.CreateLambdaName(), formalPars, ValueStack[ValueStack.Depth-3].td, ValueStack[ValueStack.Depth-1].stn as statement_list, CurrentLocationSpan);
		}
        break;
      case 901: // func_decl_lambda -> tkRoundOpen, identifier, tkSemiColon, full_lambda_fp_list, 
                //                     tkRoundClose, lambda_type_ref_noproctype, tkArrow, 
                //                     lambda_function_body
{
			var idList = new ident_list(ValueStack[ValueStack.Depth-7].id, LocationStack[LocationStack.Depth-7]);
			var formalPars = new formal_parameters(new typed_parameters(idList, new lambda_inferred_type(new PascalABCCompiler.TreeRealization.lambda_any_type_node(), null), parametr_kind.none, null, LocationStack[LocationStack.Depth-7]), LexLocation.MergeAll(LocationStack[LocationStack.Depth-7],LocationStack[LocationStack.Depth-6],LocationStack[LocationStack.Depth-5]));
			for (int i = 0; i < (ValueStack[ValueStack.Depth-5].stn as formal_parameters).Count; i++)
				formalPars.Add((ValueStack[ValueStack.Depth-5].stn as formal_parameters).params_list[i]);
			CurrentSemanticValue.ex = new function_lambda_definition(lambdaHelper.CreateLambdaName(), formalPars, ValueStack[ValueStack.Depth-3].td, ValueStack[ValueStack.Depth-1].stn as statement_list, CurrentLocationSpan);
		}
        break;
      case 902: // func_decl_lambda -> tkRoundOpen, identifier, tkColon, fptype, tkSemiColon, 
                //                     full_lambda_fp_list, tkRoundClose, 
                //                     lambda_type_ref_noproctype, tkArrow, lambda_function_body
{
			var idList = new ident_list(ValueStack[ValueStack.Depth-9].id, LocationStack[LocationStack.Depth-9]);
            var loc = LexLocation.MergeAll(LocationStack[LocationStack.Depth-9],LocationStack[LocationStack.Depth-8],LocationStack[LocationStack.Depth-7]);
			var formalPars = new formal_parameters(new typed_parameters(idList, ValueStack[ValueStack.Depth-7].td, parametr_kind.none, null, loc), LexLocation.MergeAll(LocationStack[LocationStack.Depth-9],LocationStack[LocationStack.Depth-8],LocationStack[LocationStack.Depth-7],LocationStack[LocationStack.Depth-6],LocationStack[LocationStack.Depth-5]));
			for (int i = 0; i < (ValueStack[ValueStack.Depth-5].stn as formal_parameters).Count; i++)
				formalPars.Add((ValueStack[ValueStack.Depth-5].stn as formal_parameters).params_list[i]);
			CurrentSemanticValue.ex = new function_lambda_definition(lambdaHelper.CreateLambdaName(), formalPars, ValueStack[ValueStack.Depth-3].td, ValueStack[ValueStack.Depth-1].stn as statement_list, CurrentLocationSpan);
		}
        break;
      case 903: // func_decl_lambda -> tkRoundOpen, expr_l1, tkComma, expr_l1_list, 
                //                     lambda_type_ref, optional_full_lambda_fp_list, 
                //                     tkRoundClose, rem_lambda
{ 
			var pair = ValueStack[ValueStack.Depth-1].ob as pair_type_stlist;
			
			if (ValueStack[ValueStack.Depth-4].td is lambda_inferred_type)
			{
				var formal_pars = new formal_parameters();
				var idd = ValueStack[ValueStack.Depth-7].ex as ident;
				if (idd==null)
					parsertools.AddErrorFromResource("ONE_TKIDENTIFIER",LocationStack[LocationStack.Depth-7]);
				var lambda_inf_type = new lambda_inferred_type(new PascalABCCompiler.TreeRealization.lambda_any_type_node(), null);
				var new_typed_pars = new typed_parameters(new ident_list(idd, idd.source_context), lambda_inf_type, parametr_kind.none, null, idd.source_context);
				formal_pars.Add(new_typed_pars);
				foreach (var id in (ValueStack[ValueStack.Depth-5].stn as expression_list).expressions)
				{
					var idd1 = id as ident;
					if (idd1==null)
						parsertools.AddErrorFromResource("ONE_TKIDENTIFIER",id.source_context);
					
					lambda_inf_type = new lambda_inferred_type(new PascalABCCompiler.TreeRealization.lambda_any_type_node(), null);
					new_typed_pars = new typed_parameters(new ident_list(idd1, idd1.source_context), lambda_inf_type, parametr_kind.none, null, idd1.source_context);
					formal_pars.Add(new_typed_pars);
				}
				
				if (ValueStack[ValueStack.Depth-3].stn != null)
					for (int i = 0; i < (ValueStack[ValueStack.Depth-3].stn as formal_parameters).Count; i++)
						formal_pars.Add((ValueStack[ValueStack.Depth-3].stn as formal_parameters).params_list[i]);		
					
				formal_pars.source_context = LexLocation.MergeAll(LocationStack[LocationStack.Depth-7],LocationStack[LocationStack.Depth-6],LocationStack[LocationStack.Depth-5],LocationStack[LocationStack.Depth-4]);
				CurrentSemanticValue.ex = new function_lambda_definition(lambdaHelper.CreateLambdaName(), formal_pars, pair.tn, pair.exprs, CurrentLocationSpan);
			}
			else
			{			
				var loc = LexLocation.MergeAll(LocationStack[LocationStack.Depth-7],LocationStack[LocationStack.Depth-6],LocationStack[LocationStack.Depth-5]);
				var idd = ValueStack[ValueStack.Depth-7].ex as ident;
				if (idd==null)
					parsertools.AddErrorFromResource("ONE_TKIDENTIFIER",LocationStack[LocationStack.Depth-7]);
				
				var idList = new ident_list(idd, loc);
				
				var iddlist = (ValueStack[ValueStack.Depth-5].stn as expression_list).expressions;
				
				for (int j = 0; j < iddlist.Count; j++)
				{
					var idd2 = iddlist[j] as ident;
					if (idd2==null)
						parsertools.AddErrorFromResource("ONE_TKIDENTIFIER",idd2.source_context);
					idList.Add(idd2);
				}	
				var parsType = ValueStack[ValueStack.Depth-4].td;
				var formalPars = new formal_parameters(new typed_parameters(idList, parsType, parametr_kind.none, null, loc), LexLocation.MergeAll(LocationStack[LocationStack.Depth-7],LocationStack[LocationStack.Depth-6],LocationStack[LocationStack.Depth-5],LocationStack[LocationStack.Depth-4],LocationStack[LocationStack.Depth-3]));
				
				if (ValueStack[ValueStack.Depth-3].stn != null)
					for (int i = 0; i < (ValueStack[ValueStack.Depth-3].stn as formal_parameters).Count; i++)
						formalPars.Add((ValueStack[ValueStack.Depth-3].stn as formal_parameters).params_list[i]);
					
				CurrentSemanticValue.ex = new function_lambda_definition(lambdaHelper.CreateLambdaName(), formalPars, pair.tn, pair.exprs, CurrentLocationSpan);
			}
		}
        break;
      case 904: // func_decl_lambda -> expl_func_decl_lambda
{
			CurrentSemanticValue.ex = ValueStack[ValueStack.Depth-1].ex;
		}
        break;
      case 905: // optional_full_lambda_fp_list -> /* empty */
{ CurrentSemanticValue.stn = null; }
        break;
      case 906: // optional_full_lambda_fp_list -> tkSemiColon, full_lambda_fp_list
{
		CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn; 
	}
        break;
      case 907: // rem_lambda -> lambda_type_ref_noproctype, tkArrow, lambda_function_body
{ 
		    CurrentSemanticValue.ob = new pair_type_stlist(ValueStack[ValueStack.Depth-3].td,ValueStack[ValueStack.Depth-1].stn as statement_list);
		}
        break;
      case 908: // expl_func_decl_lambda -> tkFunction, lambda_type_ref, tkArrow, 
                //                          lambda_function_body
{
			CurrentSemanticValue.ex = new function_lambda_definition(lambdaHelper.CreateLambdaName(), null, ValueStack[ValueStack.Depth-3].td, ValueStack[ValueStack.Depth-1].stn as statement_list, 1, CurrentLocationSpan);
		}
        break;
      case 909: // expl_func_decl_lambda -> tkFunction, tkRoundOpen, tkRoundClose, lambda_type_ref, 
                //                          tkArrow, lambda_function_body
{
			CurrentSemanticValue.ex = new function_lambda_definition(lambdaHelper.CreateLambdaName(), null, ValueStack[ValueStack.Depth-3].td, ValueStack[ValueStack.Depth-1].stn as statement_list, 1, CurrentLocationSpan);
		}
        break;
      case 910: // expl_func_decl_lambda -> tkFunction, tkRoundOpen, full_lambda_fp_list, 
                //                          tkRoundClose, lambda_type_ref, tkArrow, 
                //                          lambda_function_body
{
			CurrentSemanticValue.ex = new function_lambda_definition(lambdaHelper.CreateLambdaName(), ValueStack[ValueStack.Depth-5].stn as formal_parameters, ValueStack[ValueStack.Depth-3].td, ValueStack[ValueStack.Depth-1].stn as statement_list, 1, CurrentLocationSpan);
		}
        break;
      case 911: // expl_func_decl_lambda -> tkProcedure, tkArrow, lambda_procedure_body
{
			CurrentSemanticValue.ex = new function_lambda_definition(lambdaHelper.CreateLambdaName(), null, null, ValueStack[ValueStack.Depth-1].stn as statement_list, 2, CurrentLocationSpan);
		}
        break;
      case 912: // expl_func_decl_lambda -> tkProcedure, tkRoundOpen, tkRoundClose, tkArrow, 
                //                          lambda_procedure_body
{
			CurrentSemanticValue.ex = new function_lambda_definition(lambdaHelper.CreateLambdaName(), null, null, ValueStack[ValueStack.Depth-1].stn as statement_list, 2, CurrentLocationSpan);
		}
        break;
      case 913: // expl_func_decl_lambda -> tkProcedure, tkRoundOpen, full_lambda_fp_list, 
                //                          tkRoundClose, tkArrow, lambda_procedure_body
{
			CurrentSemanticValue.ex = new function_lambda_definition(lambdaHelper.CreateLambdaName(), ValueStack[ValueStack.Depth-4].stn as formal_parameters, null, ValueStack[ValueStack.Depth-1].stn as statement_list, 2, CurrentLocationSpan);
		}
        break;
      case 914: // full_lambda_fp_list -> lambda_simple_fp_sect
{
			var typed_pars = ValueStack[ValueStack.Depth-1].stn as typed_parameters;
			if (typed_pars.vars_type is lambda_inferred_type)
			{
				CurrentSemanticValue.stn = new formal_parameters();
				foreach (var id in typed_pars.idents.idents)
				{
					var lambda_inf_type = new lambda_inferred_type(new PascalABCCompiler.TreeRealization.lambda_any_type_node(), null);
					var new_typed_pars = new typed_parameters(new ident_list(id, id.source_context), lambda_inf_type, parametr_kind.none, null, id.source_context);
					(CurrentSemanticValue.stn as formal_parameters).Add(new_typed_pars);
				}
				CurrentSemanticValue.stn.source_context = CurrentLocationSpan;
			}
			else
			{
				CurrentSemanticValue.stn = new formal_parameters(typed_pars, CurrentLocationSpan);
			}
		}
        break;
      case 915: // full_lambda_fp_list -> full_lambda_fp_list, tkSemiColon, lambda_simple_fp_sect
{
			CurrentSemanticValue.stn =(ValueStack[ValueStack.Depth-3].stn as formal_parameters).Add(ValueStack[ValueStack.Depth-1].stn as typed_parameters, CurrentLocationSpan);
		}
        break;
      case 916: // lambda_simple_fp_sect -> ident_list, lambda_type_ref
{
			CurrentSemanticValue.stn = new typed_parameters(ValueStack[ValueStack.Depth-2].stn as ident_list, ValueStack[ValueStack.Depth-1].td, parametr_kind.none, null, CurrentLocationSpan);
		}
        break;
      case 917: // lambda_type_ref -> /* empty */
{
			CurrentSemanticValue.td = new lambda_inferred_type(new PascalABCCompiler.TreeRealization.lambda_any_type_node(), null);
		}
        break;
      case 918: // lambda_type_ref -> tkColon, fptype
{
			CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td;
		}
        break;
      case 919: // lambda_type_ref_noproctype -> /* empty */
{
			CurrentSemanticValue.td = new lambda_inferred_type(new PascalABCCompiler.TreeRealization.lambda_any_type_node(), null);
		}
        break;
      case 920: // lambda_type_ref_noproctype -> tkColon, fptype_noproctype
{
			CurrentSemanticValue.td = ValueStack[ValueStack.Depth-1].td;
		}
        break;
      case 921: // common_lambda_body -> compound_stmt
{
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn;
		}
        break;
      case 922: // common_lambda_body -> if_stmt
{
			CurrentSemanticValue.stn = new statement_list(ValueStack[ValueStack.Depth-1].stn as statement, CurrentLocationSpan);
		}
        break;
      case 923: // common_lambda_body -> while_stmt
{
			CurrentSemanticValue.stn = new statement_list(ValueStack[ValueStack.Depth-1].stn as statement, CurrentLocationSpan);
		}
        break;
      case 924: // common_lambda_body -> repeat_stmt
{
			CurrentSemanticValue.stn = new statement_list(ValueStack[ValueStack.Depth-1].stn as statement, CurrentLocationSpan);
		}
        break;
      case 925: // common_lambda_body -> for_stmt
{
			CurrentSemanticValue.stn = new statement_list(ValueStack[ValueStack.Depth-1].stn as statement, CurrentLocationSpan);
		}
        break;
      case 926: // common_lambda_body -> foreach_stmt
{
			CurrentSemanticValue.stn = new statement_list(ValueStack[ValueStack.Depth-1].stn as statement, CurrentLocationSpan);
		}
        break;
      case 927: // common_lambda_body -> loop_stmt
{
			CurrentSemanticValue.stn = new statement_list(ValueStack[ValueStack.Depth-1].stn as statement, CurrentLocationSpan);
		}
        break;
      case 928: // common_lambda_body -> case_stmt
{
			CurrentSemanticValue.stn = new statement_list(ValueStack[ValueStack.Depth-1].stn as statement, CurrentLocationSpan);
		}
        break;
      case 929: // common_lambda_body -> try_stmt
{
			CurrentSemanticValue.stn = new statement_list(ValueStack[ValueStack.Depth-1].stn as statement, CurrentLocationSpan);
		}
        break;
      case 930: // common_lambda_body -> lock_stmt
{
			CurrentSemanticValue.stn = new statement_list(ValueStack[ValueStack.Depth-1].stn as statement, CurrentLocationSpan);
		}
        break;
      case 931: // common_lambda_body -> yield_stmt
{
			CurrentSemanticValue.stn = new statement_list(ValueStack[ValueStack.Depth-1].stn as statement, CurrentLocationSpan);
		}
        break;
      case 932: // common_lambda_body -> raise_stmt
{
			CurrentSemanticValue.stn = new statement_list(ValueStack[ValueStack.Depth-1].stn as statement, CurrentLocationSpan);
		}
        break;
      case 933: // lambda_function_body -> expr_l1
{
		    var id = SyntaxVisitors.ExprHasNameVisitor.HasName(ValueStack[ValueStack.Depth-1].ex, "Result"); 
            if (id != null)
            {
                 parsertools.AddErrorFromResource("RESULT_IDENT_NOT_EXPECTED_IN_THIS_CONTEXT", id.source_context);
            }
			var sl = new statement_list(new assign("result",ValueStack[ValueStack.Depth-1].ex,CurrentLocationSpan),CurrentLocationSpan); // ���� �������� ��� � assign ��� ������������������� ��� ������ - ����� ��������� ����� Result
			sl.expr_lambda_body = true;
			CurrentSemanticValue.stn = sl;
		}
        break;
      case 934: // lambda_function_body -> common_lambda_body
{
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn;
		}
        break;
      case 935: // lambda_procedure_body -> proc_call
{
			CurrentSemanticValue.stn = new statement_list(ValueStack[ValueStack.Depth-1].stn as statement, CurrentLocationSpan);
		}
        break;
      case 936: // lambda_procedure_body -> assignment
{
			CurrentSemanticValue.stn = new statement_list(ValueStack[ValueStack.Depth-1].stn as statement, CurrentLocationSpan);
		}
        break;
      case 937: // lambda_procedure_body -> common_lambda_body
{
			CurrentSemanticValue.stn = ValueStack[ValueStack.Depth-1].stn;
		}
        break;
    }
  }

  protected override string TerminalToString(int terminal)
  {
    if (aliasses != null && aliasses.ContainsKey(terminal))
        return aliasses[terminal];
    else if (((Tokens)terminal).ToString() != terminal.ToString(CultureInfo.InvariantCulture))
        return ((Tokens)terminal).ToString();
    else
        return CharToString((char)terminal);
  }

}
}
