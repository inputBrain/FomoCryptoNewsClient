 const data = [
    { id: 1, title: "Bitcoin Surges", description: "Bitcoin price reaches new heights...", status: "Pending", createdAt: "2024-07-01 10:30" },
    { id: 2, title: "Ethereum 2.0 Update", description: "Ethereum completes major network upgrade...", status: "Approved", createdAt: "2024-06-30 15:45" },
    { id: 3, title: "Crypto Regulation News", description: "New regulations proposed for cryptocurrency exchanges...", status: "Pending", createdAt: "2024-07-02 09:15" },
    { id: 4, title: "DeFi Platform Launch", description: "New decentralized finance platform gains traction...", status: "Approved", createdAt: "2024-07-01 14:20" },
    { id: 5, title: "NFT Market Trends", description: "Analysis of recent trends in the NFT marketplace...", status: "Pending", createdAt: "2024-07-03 11:00" },
    { id: 6, title: "Blockchain in Supply Chain", description: "Major retailer adopts blockchain for supply chain management...", status: "Approved", createdAt: "2024-07-02 16:30" },
    { id: 7, title: "Crypto Mining Efficiency", description: "New mining hardware promises increased efficiency...", status: "Pending", createdAt: "2024-07-04 08:45" },
    { id: 8, title: "Stablecoin Developments", description: "Central banks considering stablecoin regulations...", status: "Approved", createdAt: "2024-07-03 13:10" },
    { id: 9, title: "Crypto Adoption in Retail", description: "Major coffee chain to accept cryptocurrency payments...", status: "Pending", createdAt: "2024-07-05 10:20" },
    { id: 10, title: "Blockchain Voting System", description: "Small country implements blockchain-based voting system...", status: "Approved", createdAt: "2024-07-04 15:55" },
    { id: 11, title: "Blockchain Voting System", description: "Small country implements blockchain-based voting system...", status: "Approved", createdAt: "2024-07-04 15:55" },
    { id: 12, title: "Blockchain Voting System", description: "Small country implements blockchain-based voting system...", status: "Approved", createdAt: "2024-07-04 15:55" }
    ];

    let currentPage = 1;
    let rowsPerPage = 10;
    let sortColumn = 'id';
    let sortDirection = 'asc';

    function renderTable() {
    const tableBody = document.getElementById('tableBody');
    const startIndex = (currentPage - 1) * rowsPerPage;
    const endIndex = startIndex + rowsPerPage;
    const paginatedData = data.slice(startIndex, endIndex);

    tableBody.innerHTML = paginatedData.map(item => `
                <tr>
                    <td>${item.id}</td>
                    <td><img src="/api/placeholder/50/50" alt="Cover" class="img-thumbnail" /></td>
                    <td>${item.title}</td>
                    <td>${item.description}</td>
                    <td><span class="badge bg-${item.status === 'Approved' ? 'success' : 'warning'}">${item.status}</span></td>
                    <td>${item.createdAt}</td>
                    <td>
                        <button class="btn btn-success btn-action" title="Approve" ${item.status === 'Approved' ? 'disabled' : ''}><i class="fas fa-check"></i></button>
                        <button class="btn btn-warning btn-action" title="Details"><i class="fas fa-eye"></i></button>
                        <button class="btn btn-danger btn-action" title="Delete"><i class="fas fa-trash"></i></button>
                    </td>
                </tr>
            `).join('');

    renderPagination();
}

    function renderPagination() {
    const totalPages = Math.ceil(data.length / rowsPerPage);
    const pagination = document.getElementById('pagination');
    pagination.innerHTML = `
                <li class="page-item ${currentPage === 1 ? 'disabled' : ''}">
                    <a class="page-link" href="#" data-page="${currentPage - 1}">&laquo;</a>
                </li>
                ${[...Array(totalPages).keys()].map(i => `
                    <li class="page-item ${currentPage === i + 1 ? 'active' : ''}">
                        <a class="page-link" href="#" data-page="${i + 1}">${i + 1}</a>
                    </li>
                `).join('')}
                <li class="page-item ${currentPage === totalPages ? 'disabled' : ''}">
                    <a class="page-link" href="#" data-page="${currentPage + 1}">&raquo;</a>
                </li>
            `;

    pagination.addEventListener('click', (e) => {
    e.preventDefault();
    if (e.target.tagName === 'A') {
    currentPage = parseInt(e.target.dataset.page);
    renderTable();
}
});
}

    function sortData(column) {
    if (column === sortColumn) {
    sortDirection = sortDirection === 'asc' ? 'desc' : 'asc';
} else {
    sortColumn = column;
    sortDirection = 'asc';
}

    data.sort((a, b) => {
    if (a[column] < b[column]) return sortDirection === 'asc' ? -1 : 1;
    if (a[column] > b[column]) return sortDirection === 'asc' ? 1 : -1;
    return 0;
});

    renderTable();
}

    document.querySelectorAll('.sortable').forEach(th => {
    th.addEventListener('click', () => {
        document.querySelectorAll('.sortable').forEach(el => {
            el.classList.remove('asc', 'desc');
        });
        th.classList.add(sortDirection);
        sortData(th.dataset.sort);
    });
});

    document.getElementById('rowsPerPage').addEventListener('change', (e) => {
    rowsPerPage = parseInt(e.target.value);
    currentPage = 1;
    renderTable();
});
    renderTable();