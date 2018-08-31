//
//  ReplayKitNative.m
//  ReplayKitUnityBridge
//
//  Created by 王志江 on 2018/8/31.
//  Copyright © 2018年 Miaokids. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <ReplayKit/ReplayKit.h>
#include "ReplayKitUnityBridge-Swift.h"

#pragma mark - C interface

extern "C" {
    
    void _rp_startRecording() {
        [[ReplayKitNative shared] startScreenCapture];
    }
}
