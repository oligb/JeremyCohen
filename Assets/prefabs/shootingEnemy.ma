//Maya ASCII 2015 scene
//Name: shootingEnemy.ma
//Last modified: Fri, Apr 24, 2015 10:35:18 PM
//Codeset: 1252
requires maya "2015";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2015";
fileInfo "version" "2015";
fileInfo "cutIdentifier" "201410051530-933320";
fileInfo "osv" "Microsoft Windows 8 Home Premium Edition, 64-bit  (Build 9200)\n";
fileInfo "license" "student";
createNode transform -n "pPyramid1";
	setAttr ".t" -type "double3" 0 -6.3704985217261197e-016 -2 ;
	setAttr ".r" -type "double3" 90 0 0 ;
	setAttr ".s" -type "double3" 0.69616339659627857 1 0.92812844642843251 ;
createNode transform -n "transform2" -p "pPyramid1";
	setAttr ".v" no;
createNode mesh -n "pPyramidShape1" -p "transform2";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr -s 2 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr -s 2 ".ciog[0].cog";
	setAttr ".pv" -type "double2" 0.5 0.25 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode transform -n "pPyramid2";
	setAttr ".t" -type "double3" 0 -6.3704985217261197e-016 2 ;
	setAttr ".r" -type "double3" 90 0 0 ;
	setAttr ".s" -type "double3" 0.69616339659627857 -1 0.92812844642843251 ;
createNode transform -n "transform1" -p "pPyramid2";
	setAttr ".v" no;
createNode mesh -n "pPyramidShape2" -p "transform1";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr -s 2 ".iog[0].og";
	setAttr ".iog[0].og[1].gcl" -type "componentList" 1 "f[0:4]";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr -s 2 ".ciog[0].cog";
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 10 ".uvst[0].uvsp[0:9]" -type "float2" 0.50000006 0 0.25
		 0.24999999 0.5 0.5 0.75 0.25 0.25 0.5 0.375 0.5 0.5 0.5 0.625 0.5 0.75 0.5 0.5 1;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 5 ".vt[0:4]"  7.1395669e-007 -2.72223759 -5.44447517 -5.44447517 -2.72223759 -4.7597115e-007
		 -2.3798557e-007 -2.72223759 5.44447517 5.44447517 -2.72223759 0 0 2.72223759 0;
	setAttr -s 8 ".ed[0:7]"  0 1 0 1 2 0 2 3 0 3 0 0 0 4 0 1 4 0 2 4 0
		 3 4 0;
	setAttr -s 5 -ch 16 ".fc[0:4]" -type "polyFaces" 
		f 4 -4 -3 -2 -1
		mu 0 4 0 3 2 1
		f 3 0 5 -5
		mu 0 3 4 5 9
		f 3 1 6 -6
		mu 0 3 5 6 9
		f 3 2 7 -7
		mu 0 3 6 7 9
		f 3 3 4 -8
		mu 0 3 7 8 9;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
createNode transform -n "pPyramid3";
	setAttr ".r" -type "double3" 0 90 0 ;
	setAttr ".s" -type "double3" 1 1 0.7800230624800143 ;
createNode mesh -n "pPyramid3Shape" -p "pPyramid3";
	setAttr -k off ".v";
	setAttr -s 2 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.4375 0.75 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode transform -n "pPyramid4";
	setAttr ".t" -type "double3" 0 0.82060169383011683 0 ;
	setAttr ".r" -type "double3" 0 90 0 ;
	setAttr ".s" -type "double3" 2.3136787146926223 1 0.61363420177506833 ;
createNode mesh -n "pPyramidShape3" -p "pPyramid4";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.6875 0.375 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 4 ".pt";
	setAttr ".pt[0]" -type "float3" 7.4505806e-009 0 0 ;
	setAttr ".pt[2]" -type "float3" 7.4505806e-009 0 0 ;
	setAttr ".pt[3]" -type "float3" -0.82033181 0 0 ;
createNode polyPyramid -n "polyPyramid2";
	setAttr ".w" 2.6727249446217405;
	setAttr ".cuv" 3;
createNode polyExtrudeFace -n "polyExtrudeFace1";
	setAttr ".ics" -type "componentList" 2 "f[0]" "f[5]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".rs" 51642;
	setAttr ".lt" -type "double3" -6.6174449004242214e-023 -2.8061974002217514e-023 
		1.6790776348273193 ;
	setAttr ".off" 2;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -3.7902443408966064 -5.0531721115112305 -4.7222375869750977 ;
	setAttr ".cbx" -type "double3" 3.7902443408966064 5.0531721115112305 4.7222375869750977 ;
createNode groupParts -n "groupParts2";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 1 "f[0:9]";
createNode polyUnite -n "polyUnite1";
	setAttr -s 2 ".ip";
	setAttr -s 2 ".im";
createNode groupId -n "groupId1";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts1";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 1 "f[0:4]";
createNode polyPyramid -n "polyPyramid1";
	setAttr ".w" 7.6996506353740806;
	setAttr ".cuv" 3;
createNode groupId -n "groupId2";
	setAttr ".ihi" 0;
createNode groupId -n "groupId3";
	setAttr ".ihi" 0;
createNode groupId -n "groupId4";
	setAttr ".ihi" 0;
createNode groupId -n "groupId5";
	setAttr ".ihi" 0;
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :renderPartition;
	setAttr -s 2 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 2 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderingList1;
select -ne :initialShadingGroup;
	setAttr -s 6 ".dsm";
	setAttr ".ro" yes;
	setAttr -s 5 ".gn";
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
select -ne :defaultHardwareRenderGlobals;
	setAttr ".res" -type "string" "ntsc_4d 646 485 1.333";
connectAttr "groupId1.id" "pPyramidShape1.iog.og[1].gid";
connectAttr ":initialShadingGroup.mwc" "pPyramidShape1.iog.og[1].gco";
connectAttr "groupParts1.og" "pPyramidShape1.i";
connectAttr "groupId2.id" "pPyramidShape1.ciog.cog[1].cgid";
connectAttr "groupId3.id" "pPyramidShape2.iog.og[1].gid";
connectAttr ":initialShadingGroup.mwc" "pPyramidShape2.iog.og[1].gco";
connectAttr "groupId4.id" "pPyramidShape2.ciog.cog[1].cgid";
connectAttr "polyExtrudeFace1.out" "pPyramid3Shape.i";
connectAttr "groupId5.id" "pPyramid3Shape.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "pPyramid3Shape.iog.og[0].gco";
connectAttr "polyPyramid2.out" "pPyramidShape3.i";
connectAttr "groupParts2.og" "polyExtrudeFace1.ip";
connectAttr "pPyramid3Shape.wm" "polyExtrudeFace1.mp";
connectAttr "polyUnite1.out" "groupParts2.ig";
connectAttr "groupId5.id" "groupParts2.gi";
connectAttr "pPyramidShape1.o" "polyUnite1.ip[0]";
connectAttr "pPyramidShape2.o" "polyUnite1.ip[1]";
connectAttr "pPyramidShape1.wm" "polyUnite1.im[0]";
connectAttr "pPyramidShape2.wm" "polyUnite1.im[1]";
connectAttr "polyPyramid1.out" "groupParts1.ig";
connectAttr "groupId1.id" "groupParts1.gi";
connectAttr "pPyramidShape1.iog.og[1]" ":initialShadingGroup.dsm" -na;
connectAttr "pPyramidShape1.ciog.cog[1]" ":initialShadingGroup.dsm" -na;
connectAttr "pPyramidShape2.iog.og[1]" ":initialShadingGroup.dsm" -na;
connectAttr "pPyramidShape2.ciog.cog[1]" ":initialShadingGroup.dsm" -na;
connectAttr "pPyramid3Shape.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pPyramidShape3.iog" ":initialShadingGroup.dsm" -na;
connectAttr "groupId1.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId2.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId3.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId4.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId5.msg" ":initialShadingGroup.gn" -na;
// End of shootingEnemy.ma
