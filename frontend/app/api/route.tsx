import { NextResponse } from "next/server";
import { getOrders } from "../src/APIHandling";

export async function GET()
{
    const data = await getOrders()

    return NextResponse.json(data);
}
