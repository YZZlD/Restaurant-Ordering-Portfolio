export default async function getMenuItems(): Promise<object[]>{
    try{
        const res = await fetch('localhost:5223/api/menuItems');
        if(!res.ok) throw new Error(`${res.status}`);

        const menuItems = await res.json();
        return menuItems;
    } catch(err)
    {
        console.log(err)
    }
    return [];
}
