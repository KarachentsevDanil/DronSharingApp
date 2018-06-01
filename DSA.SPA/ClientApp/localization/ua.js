export const uaLocalization = {
    common: {
        language: "Мова",
        airTaxies: "Літаючі Таксі",
        name: "Им'я",
        country: "Країна",
        description: "Опис",
        add: "Додати",
        close: "Закрити",
        details: "Деталі",
        filter: "Фільтер",
        totalItems: "Всього",
        itemsPages: "записи / сторинка"
    },
    authorization: {
        email: "Електронна пошта",
        password: "Пароль",
        login: "Увійти",
        signUp: "Зареєструватися",
        createNewMessage: "Не маєте облікового запису?",
        loginToAccount: "Увійдіть до свого облікового запису",
        credentials: "Ваші облікові дані"
    },
    registration: {
        email: "Електронна пошта",
        password: "Пароль",
        fullName: "Повне ім'я",
        createAccount: "Створити обліковий запис",
        fieldsRequired: "Всі поля обов'язкові для заповнення",
        doYouHaveAnAccount: "У вас є обліковий запис?",
        singIn: "Увійти",
        registr: "Зареєструватися"
    },
    companies: {
        companyList: "Список Компаній",
        addCompany: "Додати Компанію",
        companyName: "Им'я...",
        country: "Країна...",
        description: "Опис...",
        companyAdded: "Компанія була успішно додана."
    },
    models: {
        addModel: "Додати Модель",
        modelName: "Ім'я...",
        company: "Компанія:",
        taxiType: "Тип Таксі:",
        modelDescription: "Опис...",
        modelCapacity: "Ємкість...",
        capacity: "Ємкість:",
        flightRange: "Максимальна відстань польоту:",
        modelFlightRange: "Максимальна відстань польоту...",
        uploadPhoto: "Загрузити фото:",
        taxiModelAdded: "Модель таксі була успішно додана.",
        taxiModelList: "Список Моделей Таксі"
    },
    taxi: {
        addAirTaxi: "Додати Літаюче Таксі",
        company: "Компанія:",
        taxiType: "Тип Таксі:",
        taxiModel: "Модель Таксі:",
        pricePerDay: "Ціна в День:",
        airTaxiList: "Список Літаючих Таксі",
        taxiAdded: "Таксі було успішно додана."
    },
    type: {
        addTaxiType: "Додати Тип Таксі",
        taxiTypeList: "Список Типів Таксі",
        typeName: "Ім'я...",
        typeDescription: "Опис...",
        taxiTypeAdded: "Тип таксі було успішно додана."
    },
    rent: {
        rents: "Оренди",
        rent: "Орендувати",
        rentList: "Список Оренд",
        from: "З:",
        to: "До:",
        totalCosts: "Загальна Вартість:",
        rentTaxi: "Орендувати Таксі",
        companies: "Компанії:",
        models: "Моделі Таксі:",
        types: "Типи Таксі:",
        startDate: "Дата Початку:",
        endDate: "Дата Кінця:",
        findTaxies: "Знайти Таксі",
        owner: "Власник:",
        taxi: "Таксі:",
        perDay: " за день.",
        company: "Компанія:",
        model: "Модель:",
        type: "Тип:",
        description: "Опис:",
        capacity: "Ємкість:",
        dailyCapacity: "Ціна в День:",
        taxiDetails: "Деталі Таксі",
        rentAdded: "Оренда була успішно додана.",
        rentError: "Спробуйте знайти іншу дату для оренди."
    },
    companyGrid: {
        nameTitle: "Назва Компанії",
        countryTitle: "Країна",
        descriptionTitle: "Опис",
        actionsTitle: "Команди"
    },
    modelGrid: {
        modelNameTitle: "Назва Моделі",
        companyTitle: "Компанія",
        typeTitle: "Тип",
        descriptionTitle: "Опис",
        actionsTitle: "Команди"
    },
    taxiGrid: {
        ownerTitle: "Власник",
        modelNameTitle: "Назва Моделі",
        companyTitle: "Компанія",
        typeTitle: "Тип",
        dailyCostsTitle: "Ціна в День",
        actionsTitle: "Команди"
    },
    typeGrid: {
        typeNameTitle: "Назва Типу",
        descriptionTitle: "Опис",
        actionsTitle: "Команди"
    },
    rentGrid: {
        taxiTitle: "Таксі",
        ownerTitle: "Власник",
        customerTitle: "Кліент",
        infoTitle: "Деталі",
        actionsTitle: "Команди"
    }
}

export const adminTaxiItems = [{
        title: "Літаючі Таксі",
        icon: "icon-users2",
        url: "",
        children: [{
                title: "Компанії",
                url: "/companies"
            },
            {
                title: "Типи Таксі",
                url: "/taxi-types"
            },
            {
                title: "Моделі Таксі",
                url: "/taxi-models"
            },
            {
                title: "Таксі",
                url: "/taxies"
            }
        ]
    },
    {
        title: "Оренди",
        icon: "icon-cog3",
        url: "",
        children: [{
            title: "Оренди",
            url: "/rent-list"
        }]
    }
];
export const userTaxiItems = [{
        title: "Літаючі Таксі",
        icon: "icon-users2",
        url: "",
        children: [{
                title: "Моделі Таксі",
                url: "/taxi-models"
            },
            {
                title: "Мої Таксі",
                url: "/taxies"
            }
        ]
    },
    {
        title: "Оренди",
        icon: "icon-cog3",
        url: "",
        children: [{
                title: "Орендувати Таксі",
                url: "/rent-taxi"
            },
            {
                title: "Мої Оренди",
                url: "/rent-list"
            }
        ]
    }
]
