// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

//---------------------------------------------------------------------
// <autogenerated>
//
//     Generated by Message Compiler (mc.exe)
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </autogenerated>
//---------------------------------------------------------------------

#pragma warning disable 1591

namespace Microsoft.Protocols.TestTools
{
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Diagnostics.Eventing;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Security.Principal;

    public class TEST_SUITE_EVENTS : IDisposable
    {
        //
        // Provider Protocol-Test-Suite Event Count 2
        //

        internal EventProviderVersionTwo m_provider = new EventProviderVersionTwo(new Guid("acb7c4c9-a810-498e-887c-1c0e0372bb58"));
        //
        // Task :  eventGUIDs
        //

        //
        // Event Descriptors
        //
        protected EventDescriptor TestSuiteLog;
        protected EventDescriptor RawMessage;

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                m_provider.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public TEST_SUITE_EVENTS()
        {
            unchecked
            {
                TestSuiteLog = new EventDescriptor(0x1, 0x0, 0x9, 0x4, 0x0, 0x0, (long)0x8000000000000000);
                RawMessage = new EventDescriptor(0x2, 0x0, 0x9, 0x4, 0x0, 0x0, (long)0x8000000000000000);
            }
        }


        //
        // Event method for TestSuiteLog
        //
        public bool EventWriteTestSuiteLog(string TestSuite, string CaseName, string EntryKind, string Message)
        {

            if (!m_provider.IsEnabled())
            {
                return true;
            }

            return m_provider.TemplateTestSuiteLog(ref TestSuiteLog, TestSuite, CaseName, EntryKind, Message);
        }

        //
        // Event method for RawMessage
        //
        public bool EventWriteRawMessage(string TestSuite, string CaseName, string MessageName, ushort DumpLevel, string Comments, ushort Length, byte[] Payload)
        {

            if (!m_provider.IsEnabled())
            {
                return true;
            }

            return m_provider.TemplateRawMessage(ref RawMessage, TestSuite, CaseName, MessageName, DumpLevel, Comments, Length, Payload);
        }
    }

    internal class EventProviderVersionTwo : EventProvider
    {
         internal EventProviderVersionTwo(Guid id)
                : base(id)
         {}


        [StructLayout(LayoutKind.Explicit, Size = 16)]
        private struct EventData
        {
            [FieldOffset(0)]
            internal UInt64 DataPointer;
            [FieldOffset(8)]
            internal uint Size;
            [FieldOffset(12)]
            internal int Reserved;
        }



        internal unsafe bool TemplateTestSuiteLog(
            ref EventDescriptor eventDescriptor,
            string TestSuite,
            string CaseName,
            string EntryKind,
            string Message
            )
        {
            int argumentCount = 4;
            bool status = true;

            if (IsEnabled(eventDescriptor.Level, eventDescriptor.Keywords))
            {
                byte* userData = stackalloc byte[sizeof(EventData) * argumentCount];
                EventData* userDataPtr = (EventData*)userData;

                userDataPtr[0].Size = (uint)(TestSuite.Length + 1)*sizeof(char);

                userDataPtr[1].Size = (uint)(CaseName.Length + 1)*sizeof(char);

                userDataPtr[2].Size = (uint)(EntryKind.Length + 1)*sizeof(char);

                userDataPtr[3].Size = (uint)(Message.Length + 1)*sizeof(char);

                fixed (char* a0 = TestSuite, a1 = CaseName, a2 = EntryKind, a3 = Message)
                {
                    userDataPtr[0].DataPointer = (ulong)a0;
                    userDataPtr[1].DataPointer = (ulong)a1;
                    userDataPtr[2].DataPointer = (ulong)a2;
                    userDataPtr[3].DataPointer = (ulong)a3;
                    status = WriteEvent(ref eventDescriptor, argumentCount, (IntPtr)(userData));
                }
            }

            return status;

        }



        internal unsafe bool TemplateRawMessage(
            ref EventDescriptor eventDescriptor,
            string TestSuite,
            string CaseName,
            string MessageName,
            ushort DumpLevel,
            string Comments,
            ushort Length,
            byte[] Payload
            )
        {
            int argumentCount = 7;
            bool status = true;

            if (IsEnabled(eventDescriptor.Level, eventDescriptor.Keywords))
            {
                byte* userData = stackalloc byte[sizeof(EventData) * argumentCount];
                EventData* userDataPtr = (EventData*)userData;

                userDataPtr[0].Size = (uint)(TestSuite.Length + 1)*sizeof(char);

                userDataPtr[1].Size = (uint)(CaseName.Length + 1)*sizeof(char);

                userDataPtr[2].Size = (uint)(MessageName.Length + 1)*sizeof(char);

                userDataPtr[3].DataPointer = (UInt64)(&DumpLevel);
                userDataPtr[3].Size = (uint)(sizeof(short)  );

                userDataPtr[4].Size = (uint)(Comments.Length + 1)*sizeof(char);

                userDataPtr[5].DataPointer = (UInt64)(&Length);
                userDataPtr[5].Size = (uint)(sizeof(short)  );

                userDataPtr[6].Size = (uint)(sizeof(byte)*Length);

                fixed (char* a0 = TestSuite, a1 = CaseName, a2 = MessageName, a3 = Comments)
                {
                    userDataPtr[0].DataPointer = (ulong)a0;
                    userDataPtr[1].DataPointer = (ulong)a1;
                    userDataPtr[2].DataPointer = (ulong)a2;
                    userDataPtr[4].DataPointer = (ulong)a3;
                    fixed (byte* b0 = Payload)
                    {
                        userDataPtr[6].DataPointer = (ulong)b0;
                        status = WriteEvent(ref eventDescriptor, argumentCount, (IntPtr)(userData));
                    }
                }
            }

            return status;

        }

    }

}

#pragma warning restore 1591