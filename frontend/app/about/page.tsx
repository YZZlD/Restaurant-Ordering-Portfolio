import { lobster } from "../ui/fonts"

export default function Page()
{
    return (
        <div className="grid grid-cols-2 m-10">
            <div className="w-3/4 h-3/4">
                <img src='/about-page-image.jpg' alt='Man making burger'/>
            </div>
            <div className="m-10 p-10 bg-red-500 rounded-md">
                <h1 className={`${lobster.className} dropshadow header text-center`}>Who We Are</h1>
                <p className={`${lobster.className} dropshadow header text-red-300 text-center`}>
                    Founded in 1910 by two men with a passion for cooking and a love for bringing smiles to patrons. We strive to uphold that legacy
                    by building community and producing the best possible product.
                </p>
            </div>
        </div>
    )
}
