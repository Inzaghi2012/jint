﻿using System;
using Jint.Native.Function;
using Jint.Native.Object;
using Jint.Runtime.Descriptors;
using Jint.Runtime.Interop;

namespace Jint.Native.Array
{
    public sealed class ArrayConstructor : FunctionInstance, IConstructor
    {
        private readonly Engine _engine;

        public ArrayConstructor(Engine engine) :  base(engine, new ObjectInstance(engine.RootFunction), null, null)
        {
            _engine = engine;

            // the constructor is the function constructor of an object
            this.Prototype.DefineOwnProperty("constructor", new DataDescriptor(this) { Writable = true, Enumerable = false, Configurable = false }, false);
            this.Prototype.DefineOwnProperty("prototype", new DataDescriptor(this.Prototype) { Writable = true, Enumerable = false, Configurable = false }, false);

            // Array method
            this.Prototype.DefineOwnProperty("push", new DataDescriptor(new BuiltInPropertyWrapper(engine, (Action<ArrayInstance, object>)Push, engine.RootFunction)), false);
            this.Prototype.DefineOwnProperty("pop", new DataDescriptor(new BuiltInPropertyWrapper(engine, (Func<ArrayInstance, object>)Pop, engine.RootFunction)), false);
        }

        public override object Call(object thisObject, object[] arguments)
        {
            return Construct(arguments);
        }

        public ObjectInstance Construct(object[] arguments)
        {
            var instance = new ArrayInstance(Prototype);

            instance.DefineOwnProperty("length", new AccessorDescriptor(() => instance.Length, x => { }), false);

            foreach (var arg in arguments)
            {
                instance.Push(arg);
            }

            return instance;
        }

        private static void Push(ArrayInstance thisObject, object o)
        {
            thisObject.Push(o);
        }

        private static object Pop(ArrayInstance thisObject)
        {
            return thisObject.Pop();
        }
    }
}
