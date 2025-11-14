import { lobster } from "../ui/fonts"

export default function Page()
{
    return (
        <div className="grid grid-cols-2 h-100 m-10">
            <div className="flex justify-center">
                <div className="m-auto space-y-10">
                    <h1 className={`${lobster.className} header text-black text-center`}>Email us:</h1>
                    <p className={`${lobster.className} header text-black text-center`}>[Email Goes Here]</p>
                </div>
            </div>
            <div className="flex justify-center">
                <div className="m-auto space-y-10">
                    <h1 className={`${lobster.className} header text-black text-center`}>Phone us:</h1>
                    <p className={`${lobster.className} header text-black text-center`}>[Phone Number Goes Here]</p>
                </div>
            </div>
        </div>
    )
}
