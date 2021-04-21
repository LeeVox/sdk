package com.leevox.random.xoshiro.generator;

import java.io.*;
import java.lang.*;
import java.util.*;

public class generator
{
    final int RANDOM_STATES = 6;
    final int RANDOM_SIZE = 30;

    final List<long[]> seeds = new ArrayList<long[]>()
    {{
        // default seed from Apache Commons RNG classes
        // https://gitbox.apache.org/repos/asf?p=commons-rng.git;a=blob;f=commons-rng-core/src/test/java/org/apache/commons/rng/core/source64/MyXoShiRo256StarStarTest.java;h=5c7abdf4afb860e16b10a0d92a873c7ae57805f7;hb=HEAD
        add(new long[] { 0x012de1babb3c4104L, 0xa5a818b8fc5aa503L, 0xb124ea2b701f4993L, 0x18e0374933d8c782L });

        // empty seed
        add(new long[0]);
    }};

    public void run()
    {
        // add more random seeds
        long now = System.currentTimeMillis();
        MyXoShiRo256StarStar random = new MyXoShiRo256StarStar(now, Long.rotateLeft(now, 8), Long.rotateLeft(now, 16), Long.rotateLeft(now, 24));
        List<Long> seedList = new ArrayList<Long>();
        for (int i = 0; i < RANDOM_STATES; i++)
        {
            seedList.add(random.nextLong());
            seeds.add(toArray(seedList));
        }

        StringBuilder builder = new StringBuilder();
        final float FLOAT_MULTIPLIER = 0x1.0p-24f;
        final double DOUBLE_MULTIPLIER = 0x1.0p-53d;
        final int FLOAT_MULTIPLIER_INT = Float.floatToRawIntBits(FLOAT_MULTIPLIER);
        final long DOUBLE_MULTIPLIER_LONG = Double.doubleToRawLongBits(DOUBLE_MULTIPLIER);

        builder.append(String.format("\n# FLOAT_MULTIPLIER:\n\t0x%x\n\t%.036f", FLOAT_MULTIPLIER_INT, FLOAT_MULTIPLIER));
        builder.append(String.format("\n# DOUBLE_MULTIPLIER:\n\t0x%x\n\t%.036f", DOUBLE_MULTIPLIER_LONG, DOUBLE_MULTIPLIER));

        builder.append("\n\n\n");

        for (long[] seed : seeds)
        {
            builder.append(String.format("Seed:\n"));
            for (long num : seed)
            {
                builder.append(String.format("\t0x%016x\n", num));
            }

            builder.append(String.format("\n\n\t# State:\n"));
            long[] state = new MyXoShiRo256StarStar(seed).getState();
            for (int i = 0; i < 4; i++)
            {
                builder.append(String.format("\t#\t0x%016x\n", state[i]));
            }

            builder.append("\n\nIntegers:\n");
            for (int num : NextInts(new MyXoShiRo256StarStar(seed)))
            {
                builder.append(String.format("\t0x%08x\n", num));
            }

            builder.append("\n\nLongs:\n");
            for (long num : NextLongs(new MyXoShiRo256StarStar(seed)))
            {
                builder.append(String.format("\t0x%016x\n", num));
            }

            builder.append("\n\nFloats:\n");
            for (float num : NextFloats(new MyXoShiRo256StarStar(seed)))
            {
                builder.append(String.format("\t%.036f\n", num));
            }

            builder.append("\n\nDoubles:\n");
            for (double num : NextDoubles(new MyXoShiRo256StarStar(seed)))
            {
                builder.append(String.format("\t%.036f\n", num));
            }

            builder.append("\n\nBytes:\n");
            for (byte num : NextBytes(new MyXoShiRo256StarStar(seed)))
            {
                builder.append(String.format("\t0x%02x\n", num));
            }

            builder.append("\n\n######################################\n\n");
        }

        try
        {
            PrintWriter writer = new PrintWriter("../../../Fixtures/xoshiro256starstar.out");
            writer.println(builder.toString());
            writer.close();
        }
        catch (FileNotFoundException exception)
        {
            System.out.println("Cannot write output to file xoshiro256starstar.out");
        }

        System.out.println(builder.toString());
    }

    private int[] NextInts(MyXoShiRo256StarStar random)
    {
        int[] result = new int[RANDOM_SIZE];
        for (int i = 0; i < RANDOM_SIZE; i++)
        {
            result[i] = random.nextInt();
        }
        return result;
    }
    private long[] NextLongs(MyXoShiRo256StarStar random)
    {
        long[] result = new long[RANDOM_SIZE];
        for (int i = 0; i < RANDOM_SIZE; i++)
        {
            result[i] = random.nextLong();
        }
        return result;
    }
    private float[] NextFloats(MyXoShiRo256StarStar random)
    {
        float[] result = new float[RANDOM_SIZE];
        for (int i = 0; i < RANDOM_SIZE; i++)
        {
            result[i] = random.nextFloat();
        }
        return result;
    }
    private double[] NextDoubles(MyXoShiRo256StarStar random)
    {
        double[] result = new double[RANDOM_SIZE];
        for (int i = 0; i < RANDOM_SIZE; i++)
        {
            result[i] = random.nextDouble();
        }
        return result;
    }
    private byte[] NextBytes(MyXoShiRo256StarStar random)
    {
        byte[] result = new byte[RANDOM_SIZE];
        random.nextBytes(result);
        return result;
    }

    private long[] toArray(List<Long> list)
    {
        long[] result = new long[list.size()];
        for (int i = 0; i < result.length; i++)
            result[i] = list.get(i);
        return result;
    }
}
