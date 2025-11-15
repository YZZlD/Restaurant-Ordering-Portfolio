'use client'

import MenuItemCard from "@/components/menuItemCard";
import { useState, useEffect } from "react";
import {getMenuItems} from "../src/APIHandling";

export default function Page()
{
    //We declare state for loading to allow for a conditional loading display while waiting on fetch.
    //We put menuItems in state so we can dynamically update the menu display once we grab data.
    const [loading, setLoading] = useState(true);
    const [menuItems, setMenuItems] = useState<any>([]);

    useEffect(() => {
            getMenuItems().then((result) => {
            setLoading(false);
            setMenuItems(result);
        })
    }, [])

    if (loading) return <p>Loading...</p>

    return (
        <div className="grid grid-cols-1 gap-x-4 gap-y-10 m-10 lg:grid-cols-2 xl:grid-cols-3">
            {menuItems.map((item: any) => (
                <div key={item.menuItemId} className="flex justify-center">
                    <MenuItemCard menuItem={item}/>
                </div>
            ))}
        </div>

    )
}
