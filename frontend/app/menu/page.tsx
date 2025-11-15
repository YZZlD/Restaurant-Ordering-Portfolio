'use client'

import MenuItemCard from "@/components/menuItemCard";
import { useState, useEffect } from "react";
import {getMenuItems} from "../src/APIHandling";

export default function Page()
{
    const [loading, setLoading] = useState(true);
    const [menuItems, setMenuItems] = useState<any>([]);



    useEffect(() => {
            getMenuItems().then((result) => {
            setLoading(false);
            setMenuItems(result);
        })
    }, [])

    console.log(menuItems);

    //THIS IS TEST BEFORE I HOOK UP AND FIX THE API
    // const newMenuItems = [
    //     {id: 1, name: 'Standard Burger', src: '/burger-background.jpg', price: '$10.99', description: 'Canadian beef with onions and our signature sauce'},
    //     {id: 2, name: 'Standard Burger', src: '/burger-background.jpg', price: '$10.99', description: 'Canadian beef with onions and our signature sauce'},
    //     {id: 3, name: 'Standard Burger', src: '/burger-background.jpg', price: '$10.99', description: 'Canadian beef with onions and our signature sauce'},
    //     {id: 4, name: 'Standard Burger', src: '/burger-background.jpg', price: '$10.99', description: 'Canadian beef with onions and our signature sauce'},
    //     {id: 5, name: 'Standard Burger', src: '/burger-background.jpg', price: '$10.99', description: 'Canadian beef with onions and our signature sauce'},
    //     {id: 6, name: 'Standard Burger', src: '/burger-background.jpg', price: '$10.99', description: 'Canadian beef with onions and our signature sauce'}
    // ]

    if (loading) return <p>Loading...</p>
    console.log(menuItems[0]);

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
