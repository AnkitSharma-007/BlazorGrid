#pragma checksum "C:\Users\asharma2\source\repos\BlazorGridComponent\BlazorGridComponent\BlazorGrid.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5bc6d96e73fb27aa05e9945ef6617c9a1865a7ad"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorGridComponent
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Blazor;
    using Microsoft.AspNetCore.Blazor.Components;
    public class BlazorGrid<TableItem> : Microsoft.AspNetCore.Blazor.Components.BlazorComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Blazor.RenderTree.RenderTreeBuilder builder)
        {
        }
        #pragma warning restore 1998
#line 34 "C:\Users\asharma2\source\repos\BlazorGridComponent\BlazorGridComponent\BlazorGrid.cshtml"
            
int totalPages;
int curPage;
int pagerSize;

int startPage;
int endPage;

/// <summary>
/// Header for BlazorGrid.
/// </summary>
[Parameter]
RenderFragment GridHeader { get; set; }

/// <summary>
/// Rows for BlazorGrid.
/// </summary>
[Parameter]
RenderFragment<TableItem> GridRow { get; set; }

/// <summary>
/// The list of item supplied to the BlazorGrid.
/// </summary>
[Parameter]
IEnumerable<TableItem> Items { get; set; }

/// <summary>
/// Size of each page of BlazorGrid. This is a required field.
/// </summary>
[Parameter]
int PageSize { get; set; }

IEnumerable<TableItem> ItemList { get; set; }

protected override async Task OnInitAsync()
{
    pagerSize = 5;
    curPage = 1;

    ItemList = Items.Skip((curPage - 1) * PageSize).Take(PageSize);
    totalPages = (int)Math.Ceiling(Items.Count() / (decimal)PageSize);

    SetPagerSize("forward");
}

public void updateList(int currentPage)
{
    ItemList = Items.Skip((currentPage - 1) * PageSize).Take(PageSize);
    curPage = currentPage;
    this.StateHasChanged();
}

public void SetPagerSize(string direction)
{
    if (direction == "forward" && endPage < totalPages)
    {
        startPage = endPage + 1;
        if (endPage + pagerSize < totalPages)
        {
            endPage = startPage + pagerSize - 1;
        }
        else
        {
            endPage = totalPages;
        }
        this.StateHasChanged();
    }
    else if (direction == "back" && startPage > 1)
    {
        endPage = startPage - 1;
        startPage = startPage - pagerSize;
    }
}

public void NavigateToPage(string direction)
{
    if (direction == "next")
    {
        if (curPage < totalPages)
        {
            if (curPage == endPage)
            {
                SetPagerSize("forward");
            }
            curPage += 1;
        }
    }
    else if (direction == "previous")
    {
        if (curPage > 1)
        {
            if (curPage == startPage)
            {
                SetPagerSize("back");
            }
            curPage -= 1;
        }
    }

    updateList(curPage);
}

#line default
#line hidden
    }
}
#pragma warning restore 1591
