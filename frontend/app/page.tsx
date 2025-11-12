import Image from "next/image";
import LandingBackground from "@/components/landing-background";
import LandingContent from "@/components/landing-content";

export default function Home() {
  return (
    <div>
      <p>THIS IS HOME</p>
      <LandingContent />
      <LandingBackground />
    </div>
  );
}
