//
//  ReplayKitNative.swift
//  ReplayKitUnityBridge
//
//  Created by 王志江 on 2018/8/31.
//  Copyright © 2018年 Miaokids. All rights reserved.
//

import Foundation
import UIKit
import ReplayKit

let kCallbackTarget = "GameMain"

@objc public class ReplayKitNative: NSObject {
    
    @objc public static let shared = ReplayKitNative()
    private let screenRecorder = RPScreenRecorder.shared()
    
    @objc public func startScreenCapture() {
        print("ReplayKitNative: startScreenCapture")
        UnitySendMessage(kCallbackTarget, "SayHi", "hello, world!")
    }
}
