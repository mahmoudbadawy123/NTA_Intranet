import { MatPaginatorIntl } from "@angular/material/paginator";



export function getArabicPaginatorIntl() {
    const paginatorIntl = new MatPaginatorIntl();
    
    paginatorIntl.itemsPerPageLabel = 'عدد النتائج في الصفحة';
    paginatorIntl.nextPageLabel = 'الصفحة التالية';
    paginatorIntl.previousPageLabel = 'الصفحة السابقة';
    
    return paginatorIntl;
  }