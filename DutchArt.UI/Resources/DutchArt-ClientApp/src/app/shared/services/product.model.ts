export interface Product {
    links: Link[];
    id: number;
    category: string;
    size: string;
    price: number;
    title: string;
    art: Art;
}

export interface Link {
    method: string;
    rel: string;
    href: string;
}

export interface Art {
    artId: string;
    artDescription: string;
    artDating: string;
    artist: string;
    artistBirthDate: Date;
    artistDeathDate: Date;
    artistNationality: string;
}




