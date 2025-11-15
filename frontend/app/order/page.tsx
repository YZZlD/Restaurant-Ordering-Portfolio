'use client'

import { useState, useEffect } from "react";
import {getMenuItems} from "../src/APIHandling";
import OrderItemCard from "@/components/orderItemCard";
import OrderCart from "@/components/orderCart";

export default function Page()
{
    const orderItemArray: boolean[] = [];
    const [loading, setLoading] = useState(true);
    const [cart, setCart] = useState<any[]>([]);
    const [total, setTotal] = useState(0);
    const [inCart, setInCart] = useState(orderItemArray);
    const [menuItems, setMenuItems] = useState<any[]>([]);


    const setItemInCart = (index:number) => {
        const updatedInCart = [...inCart]
        updatedInCart[index] = !inCart[index]
        setInCart(updatedInCart);
    }

    const modifyTotal = (value:number) => {
        setTotal(total => total += value);
    }

    const addMenuItemToCart = (id:number) => {
        setCart([...cart, {itemInfo: menuItems.filter((item:any) => item.menuItemId === id)[0], quantity: 1}]);
    }

    const removeMenuItemFromCart = (id:number) => {
        const item = cart.filter((item:any) => item.itemInfo.menuItemId === id)[0];
        setTotal(total => total -= item.itemInfo.menuItemPrice * item.quantity);
        setCart(cart.filter((item:any) => item.itemInfo.menuItemId !== id));
    }

    const removeLastItem = (id:number) => {
        setCart(cart.filter((item:any) => item.itemInfo.menuItemId !== id));
    }

    useEffect(() => {
            getMenuItems().then((result) => {
            setLoading(false);
            setMenuItems(result);
        })
    }, [])

    for(let i:number = 0; i < menuItems.length; i++){
        orderItemArray.push(false);
    }

    if (loading) return <p>Loading...</p>;

    return (
        <div className="relative grid grid-cols-10 gap-x-4">
            <div className="relative grid grid-cols-1 col-start-1 col-span-6 gap-x-4 gap-y-10 m-10">
                {menuItems.map(item => (
                    <div key={item.menuItemId} className="">
                        <OrderItemCard inCart={inCart[item.menuItemId]} setItemInCart={() => setItemInCart(item.menuItemId)} onAdd={() => {addMenuItemToCart(item.menuItemId); modifyTotal(item.menuItemPrice)}} onRemove={() => removeMenuItemFromCart(item.menuItemId)} menuItem={item}/>
                    </div>
                ))}
            </div>
            <OrderCart setItemInCart={(id:number) => setItemInCart(id)} removeLastItem={(id:number) => removeLastItem(id)} total={total} modifyTotal={(value:number) => modifyTotal(value)} cart={cart}/>
        </div>

    )
}
