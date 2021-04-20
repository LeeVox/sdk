package com.leevox.random.xoshiro.generator;

import java.io.*;
import java.util.*;
import it.unimi.dsi.util.XoShiRo256StarStarRandom;

public class generator
{
    final long[][] seeds = new long[][]
    {
        // default seed from Apache Commons RNG classes
        // https://gitbox.apache.org/repos/asf?p=commons-rng.git;a=blob;f=commons-rng-core/src/test/java/org/apache/commons/rng/core/source64/XoShiRo256StarStarTest.java;h=5c7abdf4afb860e16b10a0d92a873c7ae57805f7;hb=HEAD
        new long[] { 0x012de1babb3c4104L, 0xa5a818b8fc5aa503L, 0xb124ea2b701f4993L, 0x18e0374933d8c782L },

        // empty seed
        new long[] { 0x0000000000000000L, 0x0000000000000000L, 0x0000000000000000L, 0x0000000000000000L },

        // special seed
        new long[] { 0x1234567890abcdefL, 0xfedcba0987654321L, 0xabcdef1234567890L, 0x0987654321fedcbaL },
    };

    final int RANDOM_SIZE = 100;

    XoShiRo256StarStarRandom intRandom = new XoShiRo256StarStarRandom();
    XoShiRo256StarStarRandom longRandom = new XoShiRo256StarStarRandom();
    XoShiRo256StarStarRandom floatRandom = new XoShiRo256StarStarRandom();
    XoShiRo256StarStarRandom doubleRandom = new XoShiRo256StarStarRandom();
    XoShiRo256StarStarRandom bytesRandom = new XoShiRo256StarStarRandom();

    public void run()
    {
        for (long[] seed : seeds)
        {
            intRandom.setState(new long[] { seed[0], seed[1], seed[2], seed[3] });
            longRandom.setState(new long[] { seed[0], seed[1], seed[2], seed[3] });
            floatRandom.setState(new long[] { seed[0], seed[1], seed[2], seed[3] });
            doubleRandom.setState(new long[] { seed[0], seed[1], seed[2], seed[3] });
            bytesRandom.setState(new long[] { seed[0], seed[1], seed[2], seed[3] });

            System.out.println("Seed:");
            for (int i = 0; i < seed.length; i++)
                System.out.print("0x" + Long.toUnsignedString(seed[i], 16) + "L, ");

            System.out.println("\nIntegers:");
            for (int i = 0; i < RANDOM_SIZE; i++)
                System.out.print("0x" + Integer.toUnsignedString(intRandom.nextInt(), 16) + ", ");

            System.out.println("\nLongs:");
            for (int i = 0; i < RANDOM_SIZE; i++)
                System.out.print("0x" + Long.toUnsignedString(longRandom.nextLong(), 16) + "L, ");

            System.out.println("\nFloats:");
            for (int i = 0; i < RANDOM_SIZE; i++)
                System.out.print(intRandom.nextFloat() + ", ");

            System.out.println("\nDoubles:");
            for (int i = 0; i < RANDOM_SIZE; i++)
                System.out.print(intRandom.nextDouble() + ", ");

            System.out.println("\nBytes:");
            byte[] bytes = new byte[RANDOM_SIZE];
            bytesRandom.nextBytes(bytes);
            for (int i = 0; i < RANDOM_SIZE; i++)
                System.out.print("0x" + Integer.toUnsignedString(Byte.toUnsignedInt(bytes[i]), 16) + ", ");

            System.out.println("\n\n");
        }
        System.out.println("Done.");
    }
}
