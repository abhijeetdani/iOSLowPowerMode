//
//  LowPowerModeDetector.mm
//  Unity-iPhone
//
//  Created by Abhijeet Dani on 7/23/16.
//
//

#import "LowPowerModeDetector.h"

@implementation LowPowerModeDetector

- (id) init {
    return self;
}

- (void) addObserverForLowPower {
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(lowPowerModeCallback) name:NSProcessInfoPowerStateDidChangeNotification object:nil];
}

- (void) removeObserverForLowPower {
    [[NSNotificationCenter defaultCenter] removeObserver:self name:NSProcessInfoPowerStateDidChangeNotification object:nil];
}

- (void) lowPowerModeCallback {
    bool isLowPowerMode = [[NSProcessInfo processInfo] isLowPowerModeEnabled];
    NSString *islowPowerModeString = (isLowPowerMode) ? @"YES" : @"NO";
    const char* cString = [islowPowerModeString cStringUsingEncoding:NSASCIIStringEncoding];
    UnitySendMessage("Game Manager", "lowPowerModeOn", cString);
}

@end

static LowPowerModeDetector *detector;

#ifdef __cplusplus
    extern "C" {
#endif
        bool _IsLowPowerModeOn() {
            return [[NSProcessInfo processInfo] isLowPowerModeEnabled];
        }
        
        void _AddObserverForLowPower() {
            if(detector == nil) {
                detector = [[LowPowerModeDetector alloc] init];
            }
            [detector addObserverForLowPower];
        }
        
        void _RemoveObserverForLowPower() {
            if(detector == nil) {
                detector = [[LowPowerModeDetector alloc] init];
            }
            [detector removeObserverForLowPower];
        }
        
#ifdef __cplusplus
    }
#endif
