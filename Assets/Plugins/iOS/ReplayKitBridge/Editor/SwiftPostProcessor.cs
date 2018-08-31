using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;

using System.IO;
using System.Linq;

public static class SwiftPostProcessor {

	[PostProcessBuild]
	public static void OnPostProcessBuild(BuildTarget buildTarget, string buildPath) {
		if (buildTarget == BuildTarget.iOS) {
			var projPath = buildPath + "/Unity-iPhone.xcodeproj/project.pbxproj";

			PBXProject proj = new PBXProject ();
			proj.ReadFromFile (projPath);

			var targetGuid = proj.TargetGuidByName (PBXProject.GetUnityTargetName ());

			/// Configure build settings
			proj.SetBuildProperty (targetGuid, "ENABLE_BITCODE", "NO");
			proj.SetBuildProperty (targetGuid, "SWIFT_OBJC_BRIDGING_HEADER",
								   "Libraries/Plugins/iOS/ReplayKitBridge/Source/ReplayKitUnityBridge-Bridging-Header.h");
			proj.SetBuildProperty (targetGuid, "SWIFT_OBJC_INTERFACE_HEADER_NAME",
								   "ReplayKitUnityBridge-Swift.h");
			proj.AddBuildProperty (targetGuid, "LD_RUNPATH_SEARCH_PATHS", "@executable_path/Frameworks");
			proj.WriteToFile (projPath);
		}
	}
}
