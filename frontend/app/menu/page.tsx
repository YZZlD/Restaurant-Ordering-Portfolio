'use client'

import GetMenuItems from "../src/APIHandling"
import { useState } from "react";

export default function Page()
{
    const [loading, setLoading] = useState(true);

    const getMenuItems = async () => {
        try{
            const res = await fetch('localhost:5223/api/menuItems');
            if(!res.ok) throw new Error(`${res.status}`);

            const menuItems = await res.json();
        } catch(err)
        {
            console.log(err)
        } finally{
            setLoading(false);
        }
    }

    const menuItems = getMenuItems();

    if (loading) return <p>Loading...</p>



    // return (
    //     <p>This is the menu page.</p>
    // )
}
