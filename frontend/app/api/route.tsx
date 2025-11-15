import { NextResponse } from "next/server";
import { getOrders } from "../src/APIHandling";


//This is a dev route to demonstrate the orders going into the database and being retrived through the api.
export async function GET()
{
    const data = await getOrders()

    return NextResponse.json(data);
}
