package com.leevox.random.xoshiro.generator;

import org.apache.commons.rng.core.source64.XoShiRo256StarStar;

public class MyXoShiRo256StarStar extends XoShiRo256StarStar
{
    public MyXoShiRo256StarStar(long[] seed)
    {
        super(seed);
    }
    public MyXoShiRo256StarStar(long seed0, long seed1, long seed2, long seed3)
    {
        super(seed0, seed1, seed2, seed3);
    }

    public long[] getState()
    {
        return new long[] { state0, state1, state2, state3 };
    }
}