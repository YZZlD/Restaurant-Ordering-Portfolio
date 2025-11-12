import Image from "next/image";
import LandingBackground from "@/components/landing-background";
import LandingContent from "@/components/landing-content";

export default function Home() {
  return (
    <div className="h-3/4 w-full">
      <LandingContent />
      <LandingBackground />
    </div>
  );
}
