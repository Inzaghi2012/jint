/// Copyright (c) 2012 Ecma International.  All rights reserved. 
/**
 * @path ch15/15.5/15.5.4/15.5.4.20/15.5.4.20-2-50.js
 * @description String.prototype.trim - 'this' is a Error Object that converts to a string
 */


function testcase() {
        var errObj = new Error("test");
        return String.prototype.trim.call(errObj) === "Error: test";
    }
runTestCase(testcase);
