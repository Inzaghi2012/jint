// Copyright 2009 the Sputnik authors.  All rights reserved.
/**
 * When length of searchString less than length of ToString(this) -1 returns
 *
 * @path ch15/15.5/15.5.4/15.5.4.7/S15.5.4.7_A2_T1.js
 * @description Call "abcd".indexOf("abcdab") and check result
 */

//////////////////////////////////////////////////////////////////////////////
//CHECK#1
if ("abcd".indexOf("abcdab")!==-1) {
  $ERROR('#1: "abcd".indexOf("abcdab")===-1. Actual: '+("abcd".indexOf("abcdab"))); 
}
//
//////////////////////////////////////////////////////////////////////////////

