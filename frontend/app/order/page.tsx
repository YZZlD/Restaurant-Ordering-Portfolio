'use client'

import { useState, useEffect } from "react";
import getMenuItems from "../src/APIHandling";
import OrderItemCard from "@/components/orderItemCard";
import OrderCart from "@/components/orderCart";

export default function Page()
{
    const orderItemArray: boolean[] = [];
    const [loading, setLoading] = useState(true);
    const [cart, setCart] = useState<any[]>([]);
    const [total, setTotal] = useState(0);
    const [inCart, setInCart] = useState(orderItemArray);

    let menuItems: any[] = [];

    // getMenuItems().then((result) => {
    //     setLoading(false);
    //     menuItems = result;
    // })
    const setItemInCart = (index:number) => {
        const updatedInCart = [...inCart]
        updatedInCart[index] = !inCart[index]
        setInCart(updatedInCart);
    }

    const modifyTotal = (value:number) => {
        setTotal(total => total += value);
    }

    const addMenuItemToCart = (id:number) => {
        setCart([...cart, {itemInfo: newMenuItems.filter((item:any) => item.id === id)[0], quantity: 1}]);
    }

    const removeMenuItemFromCart = (id:number) => {
        const item = cart.filter((item:any) => item.itemInfo.id === id)[0];
        setTotal(total => total -= item.itemInfo.price * item.quantity);
        setCart(cart.filter((item:any) => item.itemInfo.id !== id));
    }

    const removeLastItem = (id:number) => {
        setCart(cart.filter((item:any) => item.itemInfo.id !== id));
    }

    const newMenuItems = [
        {id: 1, name: 'Standard Burger', src: '/burger-background.jpg', price: 10.99, description: 'Canadian beef with onions and our signature sauce'},
        {id: 2, name: 'Deluxe Burger', src: '/burger-background.jpg', price: 12.99, description: 'Canadian beef with onions and our signature sauce'},
        {id: 3, name: 'Super Deluxe Burger', src: '/burger-background.jpg', price: 15.99, description: 'Canadian beef with onions and our signature sauce'},
        {id: 4, name: 'Mini Burger', src: '/burger-background.jpg', price: 5.99, description: 'Canadian beef with onions and our signature sauce'},
        {id: 5, name: 'Special Burger', src: '/burger-background.jpg', price: 13.99, description: 'Canadian beef with onions and our signature sauce'},
        {id: 6, name: 'Not A Burger', src: '/burger-background.jpg', price: 8.99, description: 'Canadian beef with onions and our signature sauce'}
    ]

    for(let i:number = 0; i < newMenuItems.length; i++){
        orderItemArray.push(false);
    }

    // if (loading) return <p>Loadingl...</p>;

    return (
        <div className="relative grid grid-cols-10 gap-x-4">
            <div className="relative grid grid-cols-1 col-start-1 col-span-6 gap-x-4 gap-y-10 m-10">
                {newMenuItems.map(item => (
                    <div key={item.id} className="">
                        <OrderItemCard inCart={inCart[item.id]} setItemInCart={() => setItemInCart(item.id)} onAdd={() => {addMenuItemToCart(item.id); modifyTotal(item.price)}} onRemove={() => removeMenuItemFromCart(item.id)} menuItem={item}/>
                    </div>
                ))}
            </div>
            <OrderCart setItemInCart={(id:number) => setItemInCart(id)} removeLastItem={(id:number) => removeLastItem(id)} total={total} modifyTotal={(value:number) => modifyTotal(value)} cart={cart}/>
        </div>

    )
}
