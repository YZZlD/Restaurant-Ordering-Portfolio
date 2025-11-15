//Declare all API handling functions in one place for easy access and reusability.

//I would like to have the api url within an environment variable in production but I could
//not get it to work with render and nextjs env so its hard coded.

export async function getMenuItems(): Promise<any[]>{
    try{
        const res = await fetch("https://restaurant-api-latest.onrender.com/api/menuItem");
        if(!res.ok) throw new Error(`${res.status}`);

        const menuItems = await res.json();
        return menuItems;
    } catch(err)
    {
        console.log(err)
    }
    return [];
}

export async function getOrders(): Promise<any[]> {
    try{
        const res = await fetch("https://restaurant-api-latest.onrender.com/api/order");
        if(!res.ok) throw new Error(`${res.status}`);

        const orders = await res.json();
        return orders;
    }catch(err)
    {
        console.log(err);
    }
    return [];
}

export async function postOrder(cart: any[]) : Promise<any>{
    try{
        const res = await fetch("https://restaurant-api-latest.onrender.com/api/order", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(postOrderHelper(cart))
        });
    } catch(err)
    {
        console.log(err)
    }
    console.log(cart);
}

function postOrderHelper(cart: any[]) {
    let menuItems:any[] = [];

    for(let i:number = 0; i < cart.length; i++)
    {
        for(let j:number = 0; j < cart[i].quantity; j++)
        {
            menuItems.push(cart[i].itemInfo);
        }
    }
    return {menuItems: menuItems};
}
