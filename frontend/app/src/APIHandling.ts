export default async function GetMenuItems(){
    //This is for development api will be deployed and url will change.
    try{
        const response = await fetch('localhost:5223/api/menuItem');

        const result = await response.json();

        return result;
    } catch (err){

    }finally {

    }



}
