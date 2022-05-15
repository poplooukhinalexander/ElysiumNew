import { useMemo } from "react";

export const useSortedTours = (tours, sortBy) => {
    const sortedTours = useMemo(() => {        
        if (sortBy)
          return [...tours].sort((a, b) => a[sortBy].localeCompare(b[sortBy]));
        return tours;
      }, [sortBy, tours]);
    
    return sortedTours;    
}

export const useSortedAndFilteredTours = (tours, sortBy, searchBy) => {
    const sortedTours = useSortedTours(tours, sortBy);
    const sortedAndFilteredTours = useMemo(() => {        
        if (searchBy)
          return sortedTours.filter(t => 
            t.title.toLowerCase().includes(searchBy.toLowerCase()) 
              || t.body.toLowerCase().includes(searchBy.toLowerCase()));
        return sortedTours;
      }, [searchBy, sortedTours]);

    return sortedAndFilteredTours;    
}