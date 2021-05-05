// Copyright (c) Traeger Industry Components GmbH. All Rights Reserved.

namespace Data
{
    using System;
    using Sinumerik.Advanced;

    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Main()
        {
            var device = new SinumerikDevice("192.168.0.131");
            device.Type = SinumerikDeviceType.SolutionLine;

            using (var connection = device.CreateConnection()) {
                connection.Open();

                for (int column = 1; column < 100; column++) {
                    try {
                        for (int line = 1; line < 100; line++) {
                            var address = new NckAddress(
                                    NckAreas.Nck.Module(NckModuleType.MachineData),
                                    new NckRange(unit: 1, column, line, count: 1));

                            var value = connection.ReadInt32(NckInt32Type.Of(address));
                            Console.WriteLine("{0} = {1:X4}", address, value);
                        }
                    }
                    catch {
                        // Ignore
                    }
                }
            }
        }
    }
}
